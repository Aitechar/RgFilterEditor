using FilterEditor.TreeNodeBase;
using FilterEditor.TreeNodeBase.StyleBox;

namespace FilterEditor
{
    public partial class Form1 : Form
    {
        private Dictionary<TreeNode, ClassTreeNode> _viewToData = [];   // TODO ����Ϊ<string, Dic<view, data>>
        private Dictionary<ClassTreeNode, TreeNode> _dataToView = [];   // TODO ����Ϊ<string, Dic<data, view>>
        private TreeNode? _nowSelectNode = null;
        private readonly IList<(string, IList<Tree>)> _treeMaps = [];

        public Form1()
        {
            InitializeComponent();
            _treeMaps = TreeFactory.BuildTreesBy(@"TreeNodeBase\StyleBox\NormalTree.json");

            /// ��ʽCombo��ѡ�����Դ
            StyleMapIcon_comboBox.DataSource = Enum.GetValues<MiniMapIconEnum>();
            StyleMapColor_comboBox.DataSource = Enum.GetValues<DrawSpColorEnum>();
            StylePlayEffect_comboBox.DataSource = Enum.GetValues<DrawSpColorEnum>();

            /// ͬ��������� ��չ��
            (_viewToData, _dataToView) = UpdateTreeViews(EditorTreeView, _treeMaps);
            SelectTreeNode(_dataToView[_treeMaps[0].Item2[0].Root]);
            EditorTreeView.ExpandAll();
        }
        /// <summary>
        /// �������е���
        /// </summary>
        private static (Dictionary<TreeNode, ClassTreeNode>, Dictionary<ClassTreeNode, TreeNode>) UpdateTreeViews(TreeView treeView, IList<(string, IList<Tree>)> trees)
        {
            treeView.Nodes.Clear();
            Dictionary<TreeNode, ClassTreeNode> viewToData = [];
            Dictionary<ClassTreeNode, TreeNode> dataToView = [];

            foreach (var tokens in trees)
            {
                var (classStr, treeList) = tokens;
                var treeNode = new TreeNode(classStr);
                foreach (var tree in treeList)
                {
                    UpdateTreeView(treeNode, tree, ref viewToData, ref dataToView);
                }

                treeView.Nodes.Add(treeNode);
            }

            /// ˢ��
            treeView.Refresh();
            treeView.ExpandAll();
            return (viewToData, dataToView);
        }

        /// <summary>
        /// ��ͷ��ʼ���ص����ṹ�����������봰���໥ӳ��
        /// </summary>
        private static void UpdateTreeView(TreeNode treeNode, Tree tree, ref Dictionary<TreeNode, ClassTreeNode> viewToData, ref Dictionary<ClassTreeNode, TreeNode> dataToView)
        {
            var root = tree.Root;
            dataToView.Add(root, new TreeNode(tree.classShowName));
            viewToData.Add(dataToView[root], root);
            treeNode.Nodes.Add(dataToView[root]);

            Queue<ClassTreeNode> que = [];
            que.Enqueue(root);
            while (que.Count != 0)
            {
                var node = que.Dequeue();
                if (node.parent != null && dataToView.TryGetValue(node.parent, out TreeNode? parentNode))
                    parentNode.Nodes.Add(dataToView[node]);

                foreach (var child in node.children)
                {
                    if (!dataToView.ContainsKey(child))
                    {
                        dataToView.Add(child, new TreeNode(child.Display));
                        // TODO �޸�treeView�ڵ�Ļ��ƣ���IsHide�Ľڵ��ϼ���ɾ����
                        viewToData.Add(dataToView[child], child);
                        que.Enqueue(child);
                    }
                }
            }
        }

        private void EditorTreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            SelectTreeNode(e.Node);
        }

        private void EditorTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            SelectTreeNode(e.Node);
        }

        /// <summary>
        /// ѡ�񵽽ڵ���߼�
        /// </summary>
        private void SelectTreeNode(TreeNode? node = null)
        {
            if (node == null || !_viewToData.ContainsKey(node))
            {
                _nowSelectNode = null;

                /// �ڵ�༭��
                treeNodeDescLab.Text = "˫��ѡ��һ���ڵ���б༭";
                AddNewClassAttr_ComboBox.Enabled = false;
                SplitClassAttr_NumericUpDown.Enabled = false;

                MergeLeft_button.Enabled = false;
                MergeRight_button.Enabled = false;

                /// ��ʽ�༭��
                StyleBackGround_Button.Enabled = false;
                StyleBoardColor_Button.Enabled = false;
                StyleTextColor_Button.Enabled = false;
                return;
            }

            // ���õ�ǰѡ��Ľڵ�
            var treenode = node;
            var datanode = _viewToData[treenode];
            var tree = datanode.tree;

            _nowSelectNode = treenode;
            treeNodeDescLab.Text = tree.GenerateNodeDescription(datanode);

            // �������ӷ������Ե�Combo��Ŀ
            AddNewClassAttr_ComboBox.Enabled = true;
            var enumCollection = tree.GetClassAttr(datanode);
            AddNewClassAttr_ComboBox.DataSource = enumCollection;

            // ������������Ĺ������ֿ��������
            var (left, right) = datanode.attr.classEnum.GetLimit();
            left = Math.Max(left, datanode.attr.MinValue);
            right = Math.Min(right, datanode.attr.MaxValue);

            if (right - left >= 1)
            {
                int pastVal = (int)AddNewClassAttr_NumericUpDown.Value;
                int curVal = Math.Clamp(pastVal, left + 1, right);

                SplitClassAttr_NumericUpDown.Minimum = left + 1;
                SplitClassAttr_NumericUpDown.Maximum = right;
                SplitClassAttr_NumericUpDown.Value = curVal;

                SplitClassAttr_NumericUpDown.Enabled = true;
            }
            else
                SplitClassAttr_NumericUpDown.Enabled = false;

            // ���úϲ��ڵ�Ŀ���״̬
            var (canMergeLeft, canMergeRight) = datanode.CanMerge();
            MergeLeft_button.Enabled = canMergeLeft;
            MergeRight_button.Enabled = canMergeRight;

            /// +�������������������� ��ʽ�༭��
            UpdateStyleControls(datanode.styleBox);
            EditorStyleControl.UpdateValue(datanode.styleBox, tree.classShowName);

            /// �ø��ڵ�ɼ�
            var rootData = datanode.tree.Root;
            var rootview = _dataToView[rootData];
            rootview.EnsureVisible();
        }

        #region �ڵ�༭�ص�
        private void AddNewClassAttr_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = AddNewClassAttr_ComboBox.SelectedItem;
            if (_nowSelectNode != null && item is ClassAttrEnum enumValue)
            {
                var (left, right) = enumValue.GetLimit();

                int pastVal = (int)AddNewClassAttr_NumericUpDown.Value;
                int curVal = Math.Clamp(pastVal, left + 1, right);

                AddNewClassAttr_NumericUpDown.Minimum = left + 1;
                AddNewClassAttr_NumericUpDown.Maximum = right;
                AddNewClassAttr_NumericUpDown.Value = curVal;

                AddNewClassAttr_NumericUpDown.Enabled = true;
            }
            else AddNewClassAttr_NumericUpDown.Enabled = false;
        }

        // TODO ��������߼��ƶ���TreeNode ����
        private void AddNewClassAttr_Button_Click(object sender, EventArgs e)
        {
            if (_nowSelectNode != null && AddNewClassAttr_ComboBox.SelectedItem is ClassAttrEnum classEnum)
            {
                var classNode = _viewToData[_nowSelectNode];
                var splitValue = (int)AddNewClassAttr_NumericUpDown.Value;
                var (left, right) = classEnum.GetLimit();

                var leftNode = new ClassTreeNode(new ClassAttrBase(left, splitValue - 1, classEnum), classNode.tree);
                var rightNode = new ClassTreeNode(new ClassAttrBase(splitValue, right, classEnum), classNode.tree);

                classNode.AddClassifiedAttr([leftNode, rightNode]);

                /// ������ͼ // TODO ֻ������һ��������ͼ
                (_viewToData, _dataToView) = UpdateTreeViews(EditorTreeView, _treeMaps);
                SelectTreeNode(_dataToView[leftNode]);
            }
        }

        private void SplitClassAttr_Button_Click(object sender, EventArgs e)
        {
            if (_nowSelectNode != null && _viewToData[_nowSelectNode].attr.classEnum != ClassAttrEnum.Root)
            {
                var splitValue = (int)SplitClassAttr_NumericUpDown.Value;
                var dataNode = _viewToData[_nowSelectNode];
                var leftDataNode = dataNode.SplitTreeNode(splitValue);

                /// ������ͼ
                (_viewToData, _dataToView) = UpdateTreeViews(EditorTreeView, _treeMaps);
                SelectTreeNode(leftDataNode != null ? _dataToView[leftDataNode] : null);
            }
        }

        private void MergeLeft_button_Click(object sender, EventArgs e)
        {
            if (_nowSelectNode != null)
            {
                var dataNode = _viewToData[_nowSelectNode];
                var mergeNode = dataNode.MergeNode(true);

                /// ������ͼ
                (_viewToData, _dataToView) = UpdateTreeViews(EditorTreeView, _treeMaps);
                SelectTreeNode(mergeNode == null ? null : _dataToView[mergeNode]);
            }

        }

        private void MergeRight_button_Click(object sender, EventArgs e)
        {
            if (_nowSelectNode != null)
            {
                var dataNode = _viewToData[_nowSelectNode];
                var mergeNode = dataNode.MergeNode(false);

                /// ������ͼ
                (_viewToData, _dataToView) = UpdateTreeViews(EditorTreeView, _treeMaps);
                SelectTreeNode(mergeNode == null ? null : _dataToView[mergeNode]);
            }
        }
        #endregion

        #region -- ��ʽ���߿�+����+���ְ�ť�ص�

        private void UpdateStyleControls(StyleBoxBase box)
        {
            StyleTextColor_Button.BackColor = box.textColor;
            StyleBackGround_Button.BackColor = box.backGroundColor;
            StyleBoardColor_Button.BackColor = box.boarderColor;

            StyleMapIcon_comboBox.SelectedItem = box.miniMapIcon;
            StyleMapColor_comboBox.SelectedItem = box.miniMapColor;

            StylePlayEffect_comboBox.SelectedItem = box.playEffectColor;

            StyleFontSize_trackBar.Value = box.isHide ? 0 : box.fontSize;

            StyleBackGround_Button.Enabled = true;
            StyleBoardColor_Button.Enabled = true;
            StyleTextColor_Button.Enabled = true;
        }

        private void StyleBoardColor_Button_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                var targetColor = colorDialog1.Color;
                StyleBoardColor_Button.BackColor = targetColor;
                EditorStyleControl.BoarderColor = targetColor;

                if (_nowSelectNode != null)
                {
                    _viewToData[_nowSelectNode].styleBox.boarderColor = targetColor;
                }
            }
        }

        private void StyleBackGround_Button_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                var targetColor = colorDialog1.Color;
                StyleBackGround_Button.BackColor = colorDialog1.Color;
                EditorStyleControl.BackGroundColor = colorDialog1.Color;

                if (_nowSelectNode != null)
                {
                    _viewToData[_nowSelectNode].styleBox.backGroundColor = targetColor;
                }
            }
        }

        private void StyleTextColor_Button_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                var targetColor = colorDialog1.Color;
                StyleTextColor_Button.BackColor = colorDialog1.Color;
                EditorStyleControl.TextColor = colorDialog1.Color;
                if (_nowSelectNode != null)
                {
                    _viewToData[_nowSelectNode].styleBox.textColor = targetColor;
                }
            }
        }

        private void StyleMapIcon_comboBox_DropDownClosed(object sender, EventArgs e)
        {
            if (_nowSelectNode != null && StyleMapIcon_comboBox.SelectedItem is MiniMapIconEnum target)
            {
                var dateNode = _viewToData[_nowSelectNode];
                dateNode.styleBox.miniMapIcon = target;
            }
            else
                MessageBox.Show($"���һ������ڵ��ٱ༭��ʽ");
        }

        private void StyleMapColor_comboBox_DropDownClosed(object sender, EventArgs e)
        {
            if (_nowSelectNode != null && StyleMapColor_comboBox.SelectedItem is DrawSpColorEnum target)
            {
                var dateNode = _viewToData[_nowSelectNode];
                dateNode.styleBox.miniMapColor = target;
            }
            else
                MessageBox.Show($"���һ������ڵ��ٱ༭��ʽ");
        }

        private void StylePlayEffect_comboBox_DropDownClosed(object sender, EventArgs e)
        {
            if (_nowSelectNode != null && StylePlayEffect_comboBox.SelectedItem is DrawSpColorEnum target)
            {
                var dateNode = _viewToData[_nowSelectNode];
                dateNode.styleBox.playEffectColor = target;
            }
            else
                MessageBox.Show($"���һ������ڵ��ٱ༭��ʽ");
        }

        private void StyleFontSize_trackBar_ValueChanged(object sender, EventArgs e)
        {
            if (_nowSelectNode != null)
            {
                var dateNode = _viewToData[_nowSelectNode];
                dateNode.styleBox.fontSize = StyleFontSize_trackBar.Value;
                dateNode.styleBox.isHide = StyleFontSize_trackBar.Value == 0;

                EditorStyleControl.FontSize = StyleFontSize_trackBar.Value;
                EditorStyleControl.IsStrickOut = StyleFontSize_trackBar.Value == 0;
                EditorStyleControl.Visible = StyleFontSize_trackBar.Value != 0;
            }
            else
                MessageBox.Show($"���һ������ڵ��ٱ༭��ʽ");
        }

        #endregion


        #region --- ComboBox ö�ٷ���
        /// <summary>
        /// ���÷������ԵĴ�ӡ��ʽ
        /// </summary>
        private void AddNewClassAttr_ComboBox_Format(object sender, ListControlConvertEventArgs e)
        {
            if (e.ListItem is ClassAttrEnum enumValue)
            {
                e.Value = enumValue.GetDescription();
            }
        }

        private void StyleMapIcon_comboBox_Format(object sender, ListControlConvertEventArgs e)
        {
            if (e.ListItem is MiniMapIconEnum value)
                e.Value = value.GetDescription();
        }

        private void StyleMapColor_comboBox_Format(object sender, ListControlConvertEventArgs e)
        {
            if (e.ListItem is DrawSpColorEnum value)
                e.Value = value.GetDescription();
        }

        private void StylePlayEffect_comboBox_Format(object sender, ListControlConvertEventArgs e)
        {
            if (e.ListItem is DrawSpColorEnum value)
                e.Value = value.GetDescription();
        }
        #endregion

        private void Expoprt_button_Click(object sender, EventArgs e)
        {
            Thread thread = new(new ThreadStart(ExportFilter));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void ExportFilter()
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var path = saveFileDialog1.FileName;
                TreeFactory.OutPutFilter(path, _treeMaps);

                // ����
                MessageBox.Show("�����ɹ�", "��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
        }
    }
}
