using System.Reflection;
using System.Resources;
using FilterEditor.TreeNodeBase;
using FilterEditor.TreeNodeBase.StyleBox;

namespace FilterEditor
{
    public partial class Form1 : Form
    {
        private Dictionary<TreeNode, ClassTreeNode> _viewToData = [];   // TODO 更改为<string, Dic<view, data>>
        private Dictionary<ClassTreeNode, TreeNode> _dataToView = [];   // TODO 更改为<string, Dic<data, view>>
        private TreeNode? _nowSelectNode = null;
        private readonly IList<(string, IList<Tree>)> _treeMaps = [];
        private readonly string _sceneImageFolder = Path.Combine(Application.StartupPath, "SceneImages");
        private readonly IList<string> _sceneImagePaths = [];
        private readonly Random random = new();

        public bool IsCopyAudio => CopyAudio_checkBox.Checked;
        public bool IsCopyStyleAudio => CopyStyleAudio_checkBox.Checked;

        public Form1()
        {
            InitializeComponent();
            try
            {
                string jsonPath = GetNormalTreePath();
                _treeMaps = TreeFactory.BuildTreesBy(jsonPath);

                /// 样式Combo框选择的来源
                StyleMapIcon_comboBox.DataSource = Enum.GetValues<MiniMapIconEnum>();
                StyleMapColor_comboBox.DataSource = Enum.GetValues<DrawSpColorEnum>();
                StylePlayEffect_comboBox.DataSource = Enum.GetValues<DrawSpColorEnum>();

                /// 同步树窗组件 并展开
                (_viewToData, _dataToView) = UpdateTreeViews(EditorTreeView, _treeMaps);
                SelectTreeNode(_dataToView[_treeMaps[0].Item2[0].Root]);
                EditorTreeView.ExpandAll();

                /// 样式盘的事件绑定
                stylePrefabsPanel1.OnStyleApply += ApplyeStylePrefab;
                stylePrefabsPanel1.OnCopyStyleButtonClicked += CopyStyleToPanel;
                EditorStyleControl.BackColor = Color.Transparent;

                /// 场景背景图
                CheckSceneFolder();
                SelectRandomSceneImage();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }

        /// <summary>
        /// 加载所有的树
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

            /// 刷新
            treeView.Refresh();
            treeView.ExpandAll();
            return (viewToData, dataToView);
        }

        /// <summary>
        /// 从头开始加载单树结构，返回数据与窗口相互映射
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
                        // TODO 修改treeView节点的绘制，在IsHide的节点上加入删除线
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
        /// 选择并展示过滤节点信息
        /// </summary>
        private void SelectTreeNode(TreeNode? node = null)
        {
            if (node == null || !_viewToData.ContainsKey(node))
            {
                _nowSelectNode = null;

                /// 节点编辑器
                treeNodeDescLab.Text = "双击选择一个节点进行编辑";
                AddNewClassAttr_ComboBox.Enabled = false;
                SplitClassAttr_NumericUpDown.Enabled = false;

                MergeLeft_button.Enabled = false;
                MergeRight_button.Enabled = false;

                /// 样式编辑器
                StyleBackGround_Button.Enabled = false;
                StyleBoardColor_Button.Enabled = false;
                StyleTextColor_Button.Enabled = false;
                return;
            }

            // 设置当前选择的节点
            var treenode = node;
            var datanode = _viewToData[treenode];
            var tree = datanode.tree;

            _nowSelectNode = treenode;
            treeNodeDescLab.Text = tree.GenerateNodeDescription(datanode);

            // 设置增加分类属性的Combo项目
            AddNewClassAttr_ComboBox.Enabled = true;
            var enumCollection = tree.GetClassAttr(datanode);
            AddNewClassAttr_ComboBox.DataSource = enumCollection;

            // 设置孪生分类的滚动数字框的上下限
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

            // 设置合并节点的开启状态
            var (canMergeLeft, canMergeRight) = datanode.CanMerge();
            MergeLeft_button.Enabled = canMergeLeft;
            MergeRight_button.Enabled = canMergeRight;

            /// +—————————— 样式编辑器
            UpdateStyleControls(datanode.styleBox);
            EditorStyleControl.UpdateValue(datanode.styleBox, tree.classShowName);

            if (audioResoucePanel.resouceManager.GetNameVaild(datanode.styleBox.audioName))
            {
                AudioResouce_ComboBox.SelectedItem = datanode.styleBox.audioName;
            }
            else
            {
                datanode.styleBox.audioName = "";
                AudioResouce_ComboBox.SelectedItem = null;
            }


            /// 让根节点可见
            var rootData = datanode.tree.Root;
            var rootview = _dataToView[rootData];
            rootview.EnsureVisible();
        }

        #region --- 节点编辑回调
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

        // TODO 将这里的逻辑移动到TreeNode 解耦
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

                /// 更新视图 // TODO 只更新这一颗树的视图
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

                /// 更新视图
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

                /// 更新视图
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

                /// 更新视图
                (_viewToData, _dataToView) = UpdateTreeViews(EditorTreeView, _treeMaps);
                SelectTreeNode(mergeNode == null ? null : _dataToView[mergeNode]);
            }
        }
        #endregion

        #region --- 样式：边框+背景+文字按钮回调

        private void UpdateStyleControls(StyleBoxBase box)
        {
            StyleTextColor_Button.BackColor = box.textColor;
            StyleBackGround_Button.BackColor = box.backGroundColor;
            StyleBoardColor_Button.BackColor = box.borderColor;

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
                    _viewToData[_nowSelectNode].styleBox.borderColor = targetColor;
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
                MessageBox.Show($"点击一个掉落节点再编辑样式");
        }

        private void StyleMapColor_comboBox_DropDownClosed(object sender, EventArgs e)
        {
            if (_nowSelectNode != null && StyleMapColor_comboBox.SelectedItem is DrawSpColorEnum target)
            {
                var dateNode = _viewToData[_nowSelectNode];
                dateNode.styleBox.miniMapColor = target;
            }
            else
                MessageBox.Show($"点击一个掉落节点再编辑样式");
        }

        private void StylePlayEffect_comboBox_DropDownClosed(object sender, EventArgs e)
        {
            if (_nowSelectNode != null && StylePlayEffect_comboBox.SelectedItem is DrawSpColorEnum target)
            {
                var dateNode = _viewToData[_nowSelectNode];
                dateNode.styleBox.playEffectColor = target;
            }
            else
                MessageBox.Show($"点击一个掉落节点再编辑样式");
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
                MessageBox.Show($"点击一个掉落节点再编辑样式");
        }

        #endregion

        #region --- ComboBox 枚举翻译
        /// <summary>
        /// 设置分类属性的打印格式
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

        #region --- 导出

        private void Export_button_Click(object sender, EventArgs e)
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
                TreeFactory.OutPutFilter(path, _treeMaps, IsCopyAudio);

                // 提醒
                MessageBox.Show("导出成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        # endregion

        # region --- 音效管理

        private void AudioResouce_ComboBox_DropDown(object sender, EventArgs e)
        {
            AudioResouce_ComboBox.Items.Clear();
            foreach (var name in audioResoucePanel.resouceManager.GetAudioNames()) AudioResouce_ComboBox.Items.Add(name);
            AudioResouce_ComboBox.Refresh();
        }

        private void AudioResouce_ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (_nowSelectNode == null) return;
            var dataNode = _viewToData[_nowSelectNode];
            if (AudioResouce_ComboBox.SelectedItem is string audioName)
                dataNode.styleBox.audioName = audioName;
        }

        private void AudiaoClear_button_Click(object sender, EventArgs e)
        {
            if (_nowSelectNode == null) return;
            var dataNode = _viewToData[_nowSelectNode];
            AudioResouce_ComboBox.SelectedItem = null;
            dataNode.styleBox.audioName = "";
        }

        #endregion

        # region --- 样式盘

        /// <summary>
        /// 将指定的样式赋予当前选择的节点
        /// </summary>
        private void ApplyeStylePrefab(StyleBoxBase styleBox)
        {
            if (_nowSelectNode == null) return;
            var dataNode = _viewToData[_nowSelectNode];
            dataNode.styleBox = new(styleBox);
            SelectTreeNode(_nowSelectNode);
        }

        private void CopyStyleToPanel()
        {
            if (_nowSelectNode == null) return;
            var dataNode = _viewToData[_nowSelectNode];
            stylePrefabsPanel1.CopyStyle(dataNode.styleBox, IsCopyStyleAudio);
        }

        #endregion

        # region --- 样式背景

        private void CheckSceneFolder()
        {
            if (!Directory.Exists(_sceneImageFolder))
            {
                Directory.CreateDirectory(_sceneImageFolder);
                ExportSceneImage(_sceneImageFolder);
            }

            _sceneImagePaths.Clear();
            foreach (var path in Directory.GetFiles(_sceneImageFolder))
            {
                if (path.EndsWith(".jpg") || path.EndsWith(".png"))
                {
                    _sceneImagePaths.Add(path);
                }
            }
        }

        private static void ExportSceneImage(string dirPath)
        {
            // MessageBox.Show($"在 {dirPath} 下创建了文件夹!");
            Dictionary<string, Image> maps = new()
            {
                {"Daylight_city.png", Properties.Resources.Daylight_city},
                {"Daytime_rainforest.png", Properties.Resources.Daytime_rainforest},
                {"Night_Forest.png", Properties.Resources.Night_Forest},
                {"Pitch_black_chamber.png", Properties.Resources.Pitch_black_chamber},
                {"Red_sand_sea.png", Properties.Resources.Red_sand_sea},
            };

            foreach (var kv in maps)
            {
                string filePath = Path.Combine(dirPath, kv.Key);
                kv.Value.Save(filePath);
            }
        }
        /// <summary>
        /// 使用随机的场景图填充pictureBox
        /// </summary>
        private void SelectRandomSceneImage()
        {
            if (_sceneImagePaths.Count == 0) return;
            var index = random.Next(_sceneImagePaths.Count);
            SceneShow_panel.BackgroundImage = Image.FromFile(_sceneImagePaths[index]);
        }

        private void ChangeScene_button_Click(object sender, EventArgs e)
        {
            SelectRandomSceneImage();
        }

        #endregion

        #region --- 默认树

        /// <summary>
        /// 获取树的路径，如果没有则会创建一个
        /// </summary>
        private static string GetNormalTreePath()
        {
            string jsonPath = Path.Combine(Application.StartupPath, "NormalTree.json");
            if (!Path.Exists(jsonPath))
            {
                // MessageBox.Show($"Find Not, Try Create");
                ExportResourceToFile(jsonPath);
            }
            return jsonPath;
        }

        /// <summary>
        /// 在指定路径下创建树
        /// </summary>
        private static void ExportResourceToFile(string targetPath)
        {
            var jsonData = Properties.Resources.NormalTree;
            File.WriteAllBytes(targetPath, jsonData);
            // MessageBox.Show($"Create At {targetPath}");
        }

        # endregion

        /// <summary>
        /// 注销事件
        /// </summary>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            stylePrefabsPanel1.OnStyleApply -= ApplyeStylePrefab;
            stylePrefabsPanel1.OnCopyStyleButtonClicked -= CopyStyleToPanel;
            base.OnFormClosing(e);
        }
    }
}
