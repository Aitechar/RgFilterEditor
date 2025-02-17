namespace FilterEditor
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            EditorTreeView = new TreeView();
            treeNodeDescLab = new Label();
            AddNewClassAttr_ComboBox = new ComboBox();
            AddNewClassAttr_GroupBox = new GroupBox();
            AddNewClassAttr_LayoutPanel = new FlowLayoutPanel();
            AddNewClassAttr_Labal = new Label();
            AddNewClassAttr_NumericUpDown = new NumericUpDown();
            AddNewClassAttr_Button = new Button();
            SplitClassAttr_GroupBox = new GroupBox();
            SplitClassAttr_LayoutPanel = new FlowLayoutPanel();
            SplitClassAttr_Label = new Label();
            SplitClassAttr_NumericUpDown = new NumericUpDown();
            SplitClassAttr_Button = new Button();
            MergeNode_groupBox = new GroupBox();
            MergeAttrBox_flowLayoutPanel = new FlowLayoutPanel();
            MergeLeft_button = new Button();
            MergeRight_button = new Button();
            TreeNode_groupBox = new GroupBox();
            flowLayoutPanel2 = new FlowLayoutPanel();
            NodeStyle_groupBox = new GroupBox();
            SceneShow_panel = new Panel();
            EditorStyleControl = new MyControl.StyleControl();
            ChangeScene_button = new Button();
            stylePrefabsPanel1 = new MyControl.StylePrefabsPanel.StylePrefabsPanel();
            StyleSound_groupBox = new GroupBox();
            AudiaoClear_button = new Button();
            CopyStyleAudio_checkBox = new CheckBox();
            CopyAudio_checkBox = new CheckBox();
            AudioShow_Label = new Label();
            AudioResouce_ComboBox = new ComboBox();
            StyleFontSize_flowLayoutPanel1 = new FlowLayoutPanel();
            StyleFontShow_label1 = new Label();
            StyleFontSize_trackBar = new TrackBar();
            StyleFontShow_label2 = new Label();
            flowLayoutPanel3 = new FlowLayoutPanel();
            StyleMapIcon_label = new Label();
            StyleMapIcon_comboBox = new ComboBox();
            StyleMapColor_comboBox = new ComboBox();
            StylePlayEffect_label = new Label();
            StylePlayEffect_comboBox = new ComboBox();
            StyleColorBox_LayoutPanel = new FlowLayoutPanel();
            StyleBoardColor_Button = new MyControl.ContrastButton();
            StyleBackGround_Button = new MyControl.ContrastButton();
            StyleTextColor_Button = new MyControl.ContrastButton();
            colorDialog1 = new ColorDialog();
            Expoprt_button = new Button();
            saveFileDialog1 = new SaveFileDialog();
            tabControl = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            audioResoucePanel = new MyControl.AudioResouceBox.AudioResoucePanel();
            AddNewClassAttr_GroupBox.SuspendLayout();
            AddNewClassAttr_LayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)AddNewClassAttr_NumericUpDown).BeginInit();
            SplitClassAttr_GroupBox.SuspendLayout();
            SplitClassAttr_LayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SplitClassAttr_NumericUpDown).BeginInit();
            MergeNode_groupBox.SuspendLayout();
            MergeAttrBox_flowLayoutPanel.SuspendLayout();
            TreeNode_groupBox.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            NodeStyle_groupBox.SuspendLayout();
            SceneShow_panel.SuspendLayout();
            StyleSound_groupBox.SuspendLayout();
            StyleFontSize_flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)StyleFontSize_trackBar).BeginInit();
            flowLayoutPanel3.SuspendLayout();
            StyleColorBox_LayoutPanel.SuspendLayout();
            tabControl.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // EditorTreeView
            // 
            EditorTreeView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            EditorTreeView.HotTracking = true;
            EditorTreeView.Location = new Point(6, 6);
            EditorTreeView.Name = "EditorTreeView";
            EditorTreeView.Size = new Size(304, 695);
            EditorTreeView.TabIndex = 0;
            EditorTreeView.NodeMouseClick += EditorTreeView_NodeMouseClick;
            EditorTreeView.NodeMouseDoubleClick += EditorTreeView_NodeMouseDoubleClick;
            // 
            // treeNodeDescLab
            // 
            treeNodeDescLab.Anchor = AnchorStyles.Left;
            treeNodeDescLab.BackColor = SystemColors.ActiveBorder;
            treeNodeDescLab.Location = new Point(5, 2);
            treeNodeDescLab.Name = "treeNodeDescLab";
            treeNodeDescLab.Size = new Size(705, 116);
            treeNodeDescLab.TabIndex = 1;
            treeNodeDescLab.Text = "选择一个过滤分配节点";
            treeNodeDescLab.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // AddNewClassAttr_ComboBox
            // 
            AddNewClassAttr_ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            AddNewClassAttr_ComboBox.FormattingEnabled = true;
            AddNewClassAttr_ComboBox.Location = new Point(77, 3);
            AddNewClassAttr_ComboBox.Name = "AddNewClassAttr_ComboBox";
            AddNewClassAttr_ComboBox.Size = new Size(120, 25);
            AddNewClassAttr_ComboBox.TabIndex = 2;
            AddNewClassAttr_ComboBox.SelectedIndexChanged += AddNewClassAttr_ComboBox_SelectedIndexChanged;
            AddNewClassAttr_ComboBox.Format += AddNewClassAttr_ComboBox_Format;
            // 
            // AddNewClassAttr_GroupBox
            // 
            AddNewClassAttr_GroupBox.AutoSize = true;
            AddNewClassAttr_GroupBox.Controls.Add(AddNewClassAttr_LayoutPanel);
            AddNewClassAttr_GroupBox.Location = new Point(5, 200);
            AddNewClassAttr_GroupBox.Name = "AddNewClassAttr_GroupBox";
            AddNewClassAttr_GroupBox.Size = new Size(420, 81);
            AddNewClassAttr_GroupBox.TabIndex = 3;
            AddNewClassAttr_GroupBox.TabStop = false;
            AddNewClassAttr_GroupBox.Text = "为当前选择节点添加下一级分类";
            // 
            // AddNewClassAttr_LayoutPanel
            // 
            AddNewClassAttr_LayoutPanel.AutoSize = true;
            AddNewClassAttr_LayoutPanel.Controls.Add(AddNewClassAttr_Labal);
            AddNewClassAttr_LayoutPanel.Controls.Add(AddNewClassAttr_ComboBox);
            AddNewClassAttr_LayoutPanel.Controls.Add(AddNewClassAttr_NumericUpDown);
            AddNewClassAttr_LayoutPanel.Controls.Add(AddNewClassAttr_Button);
            AddNewClassAttr_LayoutPanel.Location = new Point(6, 28);
            AddNewClassAttr_LayoutPanel.Name = "AddNewClassAttr_LayoutPanel";
            AddNewClassAttr_LayoutPanel.Size = new Size(408, 31);
            AddNewClassAttr_LayoutPanel.TabIndex = 4;
            // 
            // AddNewClassAttr_Labal
            // 
            AddNewClassAttr_Labal.Anchor = AnchorStyles.Left;
            AddNewClassAttr_Labal.AutoSize = true;
            AddNewClassAttr_Labal.Location = new Point(3, 7);
            AddNewClassAttr_Labal.Name = "AddNewClassAttr_Labal";
            AddNewClassAttr_Labal.Size = new Size(68, 17);
            AddNewClassAttr_Labal.TabIndex = 5;
            AddNewClassAttr_Labal.Text = "选择属性：";
            AddNewClassAttr_Labal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // AddNewClassAttr_NumericUpDown
            // 
            AddNewClassAttr_NumericUpDown.Anchor = AnchorStyles.Left;
            AddNewClassAttr_NumericUpDown.Location = new Point(203, 4);
            AddNewClassAttr_NumericUpDown.Name = "AddNewClassAttr_NumericUpDown";
            AddNewClassAttr_NumericUpDown.Size = new Size(120, 23);
            AddNewClassAttr_NumericUpDown.TabIndex = 4;
            // 
            // AddNewClassAttr_Button
            // 
            AddNewClassAttr_Button.Location = new Point(329, 3);
            AddNewClassAttr_Button.Name = "AddNewClassAttr_Button";
            AddNewClassAttr_Button.Size = new Size(75, 23);
            AddNewClassAttr_Button.TabIndex = 4;
            AddNewClassAttr_Button.Text = "划分";
            AddNewClassAttr_Button.UseVisualStyleBackColor = true;
            AddNewClassAttr_Button.Click += AddNewClassAttr_Button_Click;
            // 
            // SplitClassAttr_GroupBox
            // 
            SplitClassAttr_GroupBox.AutoSize = true;
            SplitClassAttr_GroupBox.Controls.Add(SplitClassAttr_LayoutPanel);
            SplitClassAttr_GroupBox.Location = new Point(5, 121);
            SplitClassAttr_GroupBox.Name = "SplitClassAttr_GroupBox";
            SplitClassAttr_GroupBox.Size = new Size(335, 73);
            SplitClassAttr_GroupBox.TabIndex = 4;
            SplitClassAttr_GroupBox.TabStop = false;
            SplitClassAttr_GroupBox.Text = "将当前过滤节点划分为为两个节点";
            // 
            // SplitClassAttr_LayoutPanel
            // 
            SplitClassAttr_LayoutPanel.AutoSize = true;
            SplitClassAttr_LayoutPanel.Controls.Add(SplitClassAttr_Label);
            SplitClassAttr_LayoutPanel.Controls.Add(SplitClassAttr_NumericUpDown);
            SplitClassAttr_LayoutPanel.Controls.Add(SplitClassAttr_Button);
            SplitClassAttr_LayoutPanel.Location = new Point(6, 22);
            SplitClassAttr_LayoutPanel.Name = "SplitClassAttr_LayoutPanel";
            SplitClassAttr_LayoutPanel.Size = new Size(323, 29);
            SplitClassAttr_LayoutPanel.TabIndex = 5;
            // 
            // SplitClassAttr_Label
            // 
            SplitClassAttr_Label.Anchor = AnchorStyles.Left;
            SplitClassAttr_Label.AutoSize = true;
            SplitClassAttr_Label.Location = new Point(3, 6);
            SplitClassAttr_Label.Name = "SplitClassAttr_Label";
            SplitClassAttr_Label.Size = new Size(104, 17);
            SplitClassAttr_Label.TabIndex = 0;
            SplitClassAttr_Label.Text = "选择第二个起点：";
            // 
            // SplitClassAttr_NumericUpDown
            // 
            SplitClassAttr_NumericUpDown.Location = new Point(113, 3);
            SplitClassAttr_NumericUpDown.Name = "SplitClassAttr_NumericUpDown";
            SplitClassAttr_NumericUpDown.Size = new Size(120, 23);
            SplitClassAttr_NumericUpDown.TabIndex = 2;
            // 
            // SplitClassAttr_Button
            // 
            SplitClassAttr_Button.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            SplitClassAttr_Button.Location = new Point(239, 3);
            SplitClassAttr_Button.Name = "SplitClassAttr_Button";
            SplitClassAttr_Button.Size = new Size(75, 23);
            SplitClassAttr_Button.TabIndex = 3;
            SplitClassAttr_Button.Text = "划分";
            SplitClassAttr_Button.UseVisualStyleBackColor = true;
            SplitClassAttr_Button.Click += SplitClassAttr_Button_Click;
            // 
            // MergeNode_groupBox
            // 
            MergeNode_groupBox.AutoSize = true;
            MergeNode_groupBox.Controls.Add(MergeAttrBox_flowLayoutPanel);
            MergeNode_groupBox.Location = new Point(346, 121);
            MergeNode_groupBox.Name = "MergeNode_groupBox";
            MergeNode_groupBox.Size = new Size(177, 73);
            MergeNode_groupBox.TabIndex = 5;
            MergeNode_groupBox.TabStop = false;
            MergeNode_groupBox.Text = "合并分类区间";
            // 
            // MergeAttrBox_flowLayoutPanel
            // 
            MergeAttrBox_flowLayoutPanel.AutoSize = true;
            MergeAttrBox_flowLayoutPanel.Controls.Add(MergeLeft_button);
            MergeAttrBox_flowLayoutPanel.Controls.Add(MergeRight_button);
            MergeAttrBox_flowLayoutPanel.Location = new Point(9, 22);
            MergeAttrBox_flowLayoutPanel.Name = "MergeAttrBox_flowLayoutPanel";
            MergeAttrBox_flowLayoutPanel.Size = new Size(162, 29);
            MergeAttrBox_flowLayoutPanel.TabIndex = 6;
            // 
            // MergeLeft_button
            // 
            MergeLeft_button.Location = new Point(3, 3);
            MergeLeft_button.Name = "MergeLeft_button";
            MergeLeft_button.Size = new Size(75, 23);
            MergeLeft_button.TabIndex = 0;
            MergeLeft_button.Text = "向前合并";
            MergeLeft_button.UseVisualStyleBackColor = true;
            MergeLeft_button.Click += MergeLeft_button_Click;
            // 
            // MergeRight_button
            // 
            MergeRight_button.Location = new Point(84, 3);
            MergeRight_button.Name = "MergeRight_button";
            MergeRight_button.Size = new Size(75, 23);
            MergeRight_button.TabIndex = 1;
            MergeRight_button.Text = "向后合并";
            MergeRight_button.UseVisualStyleBackColor = true;
            MergeRight_button.Click += MergeRight_button_Click;
            // 
            // TreeNode_groupBox
            // 
            TreeNode_groupBox.AutoSize = true;
            TreeNode_groupBox.Controls.Add(flowLayoutPanel2);
            TreeNode_groupBox.Location = new Point(319, 6);
            TreeNode_groupBox.Name = "TreeNode_groupBox";
            TreeNode_groupBox.Size = new Size(733, 336);
            TreeNode_groupBox.TabIndex = 6;
            TreeNode_groupBox.TabStop = false;
            TreeNode_groupBox.Text = "节点关系修改";
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(treeNodeDescLab);
            flowLayoutPanel2.Controls.Add(SplitClassAttr_GroupBox);
            flowLayoutPanel2.Controls.Add(MergeNode_groupBox);
            flowLayoutPanel2.Controls.Add(AddNewClassAttr_GroupBox);
            flowLayoutPanel2.Location = new Point(6, 22);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Padding = new Padding(2);
            flowLayoutPanel2.Size = new Size(721, 292);
            flowLayoutPanel2.TabIndex = 0;
            // 
            // NodeStyle_groupBox
            // 
            NodeStyle_groupBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            NodeStyle_groupBox.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            NodeStyle_groupBox.Controls.Add(SceneShow_panel);
            NodeStyle_groupBox.Controls.Add(ChangeScene_button);
            NodeStyle_groupBox.Controls.Add(stylePrefabsPanel1);
            NodeStyle_groupBox.Controls.Add(StyleSound_groupBox);
            NodeStyle_groupBox.Controls.Add(StyleFontSize_flowLayoutPanel1);
            NodeStyle_groupBox.Controls.Add(flowLayoutPanel3);
            NodeStyle_groupBox.Controls.Add(StyleColorBox_LayoutPanel);
            NodeStyle_groupBox.ForeColor = SystemColors.ControlText;
            NodeStyle_groupBox.Location = new Point(318, 326);
            NodeStyle_groupBox.Name = "NodeStyle_groupBox";
            NodeStyle_groupBox.Size = new Size(734, 415);
            NodeStyle_groupBox.TabIndex = 7;
            NodeStyle_groupBox.TabStop = false;
            NodeStyle_groupBox.Text = "编辑掉落样式";
            // 
            // SceneShow_panel
            // 
            SceneShow_panel.BackgroundImage = Properties.Resources.Daytime_rainforest;
            SceneShow_panel.BackgroundImageLayout = ImageLayout.Center;
            SceneShow_panel.BorderStyle = BorderStyle.FixedSingle;
            SceneShow_panel.Controls.Add(EditorStyleControl);
            SceneShow_panel.ForeColor = Color.Transparent;
            SceneShow_panel.Location = new Point(68, 22);
            SceneShow_panel.Name = "SceneShow_panel";
            SceneShow_panel.Size = new Size(350, 64);
            SceneShow_panel.TabIndex = 18;
            // 
            // EditorStyleControl
            // 
            EditorStyleControl.BackColor = Color.Transparent;
            EditorStyleControl.ForeColor = Color.Transparent;
            EditorStyleControl.Location = new Point(30, 11);
            EditorStyleControl.Name = "EditorStyleControl";
            EditorStyleControl.Size = new Size(291, 44);
            EditorStyleControl.TabIndex = 1;
            // 
            // ChangeScene_button
            // 
            ChangeScene_button.FlatStyle = FlatStyle.Flat;
            ChangeScene_button.Location = new Point(11, 22);
            ChangeScene_button.Name = "ChangeScene_button";
            ChangeScene_button.Size = new Size(51, 64);
            ChangeScene_button.TabIndex = 17;
            ChangeScene_button.Text = "更换场景";
            ChangeScene_button.UseVisualStyleBackColor = true;
            ChangeScene_button.Click += ChangeScene_button_Click;
            // 
            // stylePrefabsPanel1
            // 
            stylePrefabsPanel1.Location = new Point(434, 22);
            stylePrefabsPanel1.Name = "stylePrefabsPanel1";
            stylePrefabsPanel1.Size = new Size(285, 393);
            stylePrefabsPanel1.TabIndex = 16;
            // 
            // StyleSound_groupBox
            // 
            StyleSound_groupBox.Controls.Add(AudiaoClear_button);
            StyleSound_groupBox.Controls.Add(CopyStyleAudio_checkBox);
            StyleSound_groupBox.Controls.Add(CopyAudio_checkBox);
            StyleSound_groupBox.Controls.Add(AudioShow_Label);
            StyleSound_groupBox.Controls.Add(AudioResouce_ComboBox);
            StyleSound_groupBox.Location = new Point(6, 282);
            StyleSound_groupBox.Name = "StyleSound_groupBox";
            StyleSound_groupBox.Size = new Size(413, 127);
            StyleSound_groupBox.TabIndex = 15;
            StyleSound_groupBox.TabStop = false;
            StyleSound_groupBox.Text = "掉落音效编辑";
            // 
            // AudiaoClear_button
            // 
            AudiaoClear_button.Location = new Point(209, 22);
            AudiaoClear_button.Name = "AudiaoClear_button";
            AudiaoClear_button.Size = new Size(126, 25);
            AudiaoClear_button.TabIndex = 6;
            AudiaoClear_button.Text = "清除音效";
            AudiaoClear_button.UseVisualStyleBackColor = true;
            AudiaoClear_button.Click += AudiaoClear_button_Click;
            // 
            // CopyStyleAudio_checkBox
            // 
            CopyStyleAudio_checkBox.AutoSize = true;
            CopyStyleAudio_checkBox.Location = new Point(8, 80);
            CopyStyleAudio_checkBox.Name = "CopyStyleAudio_checkBox";
            CopyStyleAudio_checkBox.Size = new Size(195, 21);
            CopyStyleAudio_checkBox.TabIndex = 5;
            CopyStyleAudio_checkBox.Text = "将掉落音效一同添加到样式盘中";
            CopyStyleAudio_checkBox.UseVisualStyleBackColor = true;
            // 
            // CopyAudio_checkBox
            // 
            CopyAudio_checkBox.AutoSize = true;
            CopyAudio_checkBox.Location = new Point(8, 53);
            CopyAudio_checkBox.Name = "CopyAudio_checkBox";
            CopyAudio_checkBox.Size = new Size(291, 21);
            CopyAudio_checkBox.TabIndex = 0;
            CopyAudio_checkBox.Text = "导出过滤器时，将音效素材一同拷贝至新的目录下";
            CopyAudio_checkBox.UseVisualStyleBackColor = true;
            // 
            // AudioShow_Label
            // 
            AudioShow_Label.AutoSize = true;
            AudioShow_Label.Location = new Point(8, 25);
            AudioShow_Label.Name = "AudioShow_Label";
            AudioShow_Label.Size = new Size(59, 17);
            AudioShow_Label.TabIndex = 4;
            AudioShow_Label.Text = "更改音效:";
            // 
            // AudioResouce_ComboBox
            // 
            AudioResouce_ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            AudioResouce_ComboBox.FormattingEnabled = true;
            AudioResouce_ComboBox.Location = new Point(82, 22);
            AudioResouce_ComboBox.Name = "AudioResouce_ComboBox";
            AudioResouce_ComboBox.Size = new Size(121, 25);
            AudioResouce_ComboBox.TabIndex = 3;
            AudioResouce_ComboBox.DropDown += AudioResouce_ComboBox_DropDown;
            AudioResouce_ComboBox.SelectionChangeCommitted += AudioResouce_ComboBox_SelectionChangeCommitted;
            // 
            // StyleFontSize_flowLayoutPanel1
            // 
            StyleFontSize_flowLayoutPanel1.AutoSize = true;
            StyleFontSize_flowLayoutPanel1.Controls.Add(StyleFontShow_label1);
            StyleFontSize_flowLayoutPanel1.Controls.Add(StyleFontSize_trackBar);
            StyleFontSize_flowLayoutPanel1.Controls.Add(StyleFontShow_label2);
            StyleFontSize_flowLayoutPanel1.Location = new Point(11, 214);
            StyleFontSize_flowLayoutPanel1.Name = "StyleFontSize_flowLayoutPanel1";
            StyleFontSize_flowLayoutPanel1.Size = new Size(408, 51);
            StyleFontSize_flowLayoutPanel1.TabIndex = 14;
            // 
            // StyleFontShow_label1
            // 
            StyleFontShow_label1.Anchor = AnchorStyles.Left;
            StyleFontShow_label1.AutoSize = true;
            StyleFontShow_label1.Location = new Point(3, 17);
            StyleFontShow_label1.Name = "StyleFontShow_label1";
            StyleFontShow_label1.Size = new Size(32, 17);
            StyleFontShow_label1.TabIndex = 12;
            StyleFontShow_label1.Text = "隐藏";
            // 
            // StyleFontSize_trackBar
            // 
            StyleFontSize_trackBar.Location = new Point(41, 3);
            StyleFontSize_trackBar.Maximum = 50;
            StyleFontSize_trackBar.Name = "StyleFontSize_trackBar";
            StyleFontSize_trackBar.Size = new Size(324, 45);
            StyleFontSize_trackBar.TabIndex = 11;
            StyleFontSize_trackBar.TickStyle = TickStyle.None;
            StyleFontSize_trackBar.ValueChanged += StyleFontSize_trackBar_ValueChanged;
            // 
            // StyleFontShow_label2
            // 
            StyleFontShow_label2.Anchor = AnchorStyles.Left;
            StyleFontShow_label2.AutoSize = true;
            StyleFontShow_label2.Location = new Point(371, 17);
            StyleFontShow_label2.Name = "StyleFontShow_label2";
            StyleFontShow_label2.Size = new Size(22, 17);
            StyleFontShow_label2.TabIndex = 13;
            StyleFontShow_label2.Text = "50";
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.Controls.Add(StyleMapIcon_label);
            flowLayoutPanel3.Controls.Add(StyleMapIcon_comboBox);
            flowLayoutPanel3.Controls.Add(StyleMapColor_comboBox);
            flowLayoutPanel3.Controls.Add(StylePlayEffect_label);
            flowLayoutPanel3.Controls.Add(StylePlayEffect_comboBox);
            flowLayoutPanel3.Location = new Point(11, 143);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(336, 65);
            flowLayoutPanel3.TabIndex = 10;
            // 
            // StyleMapIcon_label
            // 
            StyleMapIcon_label.Anchor = AnchorStyles.Left;
            StyleMapIcon_label.AutoSize = true;
            StyleMapIcon_label.Location = new Point(3, 7);
            StyleMapIcon_label.Name = "StyleMapIcon_label";
            StyleMapIcon_label.Size = new Size(68, 17);
            StyleMapIcon_label.TabIndex = 5;
            StyleMapIcon_label.Text = "地图图标：";
            // 
            // StyleMapIcon_comboBox
            // 
            StyleMapIcon_comboBox.FormattingEnabled = true;
            StyleMapIcon_comboBox.Location = new Point(77, 3);
            StyleMapIcon_comboBox.Name = "StyleMapIcon_comboBox";
            StyleMapIcon_comboBox.Size = new Size(121, 25);
            StyleMapIcon_comboBox.TabIndex = 6;
            StyleMapIcon_comboBox.DropDownClosed += StyleMapIcon_comboBox_DropDownClosed;
            StyleMapIcon_comboBox.Format += StyleMapIcon_comboBox_Format;
            // 
            // StyleMapColor_comboBox
            // 
            StyleMapColor_comboBox.FormattingEnabled = true;
            StyleMapColor_comboBox.Location = new Point(204, 3);
            StyleMapColor_comboBox.Name = "StyleMapColor_comboBox";
            StyleMapColor_comboBox.Size = new Size(121, 25);
            StyleMapColor_comboBox.TabIndex = 7;
            StyleMapColor_comboBox.DropDownClosed += StyleMapColor_comboBox_DropDownClosed;
            StyleMapColor_comboBox.Format += StyleMapColor_comboBox_Format;
            // 
            // StylePlayEffect_label
            // 
            StylePlayEffect_label.Anchor = AnchorStyles.Left;
            StylePlayEffect_label.AutoSize = true;
            StylePlayEffect_label.Location = new Point(3, 38);
            StylePlayEffect_label.Name = "StylePlayEffect_label";
            StylePlayEffect_label.Size = new Size(68, 17);
            StylePlayEffect_label.TabIndex = 7;
            StylePlayEffect_label.Text = "地图光柱：";
            // 
            // StylePlayEffect_comboBox
            // 
            StylePlayEffect_comboBox.FormattingEnabled = true;
            StylePlayEffect_comboBox.Location = new Point(77, 34);
            StylePlayEffect_comboBox.Name = "StylePlayEffect_comboBox";
            StylePlayEffect_comboBox.Size = new Size(121, 25);
            StylePlayEffect_comboBox.TabIndex = 8;
            StylePlayEffect_comboBox.DropDownClosed += StylePlayEffect_comboBox_DropDownClosed;
            StylePlayEffect_comboBox.Format += StylePlayEffect_comboBox_Format;
            // 
            // StyleColorBox_LayoutPanel
            // 
            StyleColorBox_LayoutPanel.AutoSize = true;
            StyleColorBox_LayoutPanel.Controls.Add(StyleBoardColor_Button);
            StyleColorBox_LayoutPanel.Controls.Add(StyleBackGround_Button);
            StyleColorBox_LayoutPanel.Controls.Add(StyleTextColor_Button);
            StyleColorBox_LayoutPanel.Location = new Point(11, 92);
            StyleColorBox_LayoutPanel.Name = "StyleColorBox_LayoutPanel";
            StyleColorBox_LayoutPanel.Size = new Size(408, 50);
            StyleColorBox_LayoutPanel.TabIndex = 4;
            // 
            // StyleBoardColor_Button
            // 
            StyleBoardColor_Button.FlatStyle = FlatStyle.Flat;
            StyleBoardColor_Button.Location = new Point(3, 3);
            StyleBoardColor_Button.Name = "StyleBoardColor_Button";
            StyleBoardColor_Button.Size = new Size(130, 39);
            StyleBoardColor_Button.TabIndex = 0;
            StyleBoardColor_Button.Text = "边框颜色";
            StyleBoardColor_Button.UseVisualStyleBackColor = true;
            StyleBoardColor_Button.Click += StyleBoardColor_Button_Click;
            // 
            // StyleBackGround_Button
            // 
            StyleBackGround_Button.FlatStyle = FlatStyle.Flat;
            StyleBackGround_Button.Location = new Point(139, 3);
            StyleBackGround_Button.Name = "StyleBackGround_Button";
            StyleBackGround_Button.Size = new Size(130, 39);
            StyleBackGround_Button.TabIndex = 1;
            StyleBackGround_Button.Text = "背景颜色";
            StyleBackGround_Button.UseVisualStyleBackColor = true;
            StyleBackGround_Button.Click += StyleBackGround_Button_Click;
            // 
            // StyleTextColor_Button
            // 
            StyleTextColor_Button.FlatStyle = FlatStyle.Flat;
            StyleTextColor_Button.Location = new Point(275, 3);
            StyleTextColor_Button.Name = "StyleTextColor_Button";
            StyleTextColor_Button.Size = new Size(130, 39);
            StyleTextColor_Button.TabIndex = 2;
            StyleTextColor_Button.Text = "文本颜色";
            StyleTextColor_Button.UseVisualStyleBackColor = true;
            StyleTextColor_Button.Click += StyleTextColor_Button_Click;
            // 
            // Expoprt_button
            // 
            Expoprt_button.FlatStyle = FlatStyle.Flat;
            Expoprt_button.Location = new Point(6, 707);
            Expoprt_button.Name = "Expoprt_button";
            Expoprt_button.Size = new Size(304, 34);
            Expoprt_button.TabIndex = 8;
            Expoprt_button.Text = "导出";
            Expoprt_button.UseVisualStyleBackColor = true;
            Expoprt_button.Click += Export_button_Click;
            // 
            // saveFileDialog1
            // 
            saveFileDialog1.DefaultExt = "filter";
            saveFileDialog1.Filter = "过滤器配置文件|*.filter";
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPage1);
            tabControl.Controls.Add(tabPage2);
            tabControl.Location = new Point(12, 12);
            tabControl.Multiline = true;
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1091, 774);
            tabControl.TabIndex = 9;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(NodeStyle_groupBox);
            tabPage1.Controls.Add(Expoprt_button);
            tabPage1.Controls.Add(TreeNode_groupBox);
            tabPage1.Controls.Add(EditorTreeView);
            tabPage1.Location = new Point(4, 26);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1083, 744);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "过滤编辑";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(audioResoucePanel);
            tabPage2.Location = new Point(4, 26);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1083, 744);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "音效管理";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // audioResoucePanel
            // 
            audioResoucePanel.Location = new Point(3, 3);
            audioResoucePanel.Name = "audioResoucePanel";
            audioResoucePanel.Size = new Size(1070, 735);
            audioResoucePanel.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1109, 799);
            Controls.Add(tabControl);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            Text = "RgFilterEditor";
            AddNewClassAttr_GroupBox.ResumeLayout(false);
            AddNewClassAttr_GroupBox.PerformLayout();
            AddNewClassAttr_LayoutPanel.ResumeLayout(false);
            AddNewClassAttr_LayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)AddNewClassAttr_NumericUpDown).EndInit();
            SplitClassAttr_GroupBox.ResumeLayout(false);
            SplitClassAttr_GroupBox.PerformLayout();
            SplitClassAttr_LayoutPanel.ResumeLayout(false);
            SplitClassAttr_LayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)SplitClassAttr_NumericUpDown).EndInit();
            MergeNode_groupBox.ResumeLayout(false);
            MergeNode_groupBox.PerformLayout();
            MergeAttrBox_flowLayoutPanel.ResumeLayout(false);
            TreeNode_groupBox.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            NodeStyle_groupBox.ResumeLayout(false);
            NodeStyle_groupBox.PerformLayout();
            SceneShow_panel.ResumeLayout(false);
            StyleSound_groupBox.ResumeLayout(false);
            StyleSound_groupBox.PerformLayout();
            StyleFontSize_flowLayoutPanel1.ResumeLayout(false);
            StyleFontSize_flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)StyleFontSize_trackBar).EndInit();
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel3.PerformLayout();
            StyleColorBox_LayoutPanel.ResumeLayout(false);
            tabControl.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TreeView EditorTreeView;
        private Label treeNodeDescLab;
        private ComboBox AddNewClassAttr_ComboBox;
        private GroupBox AddNewClassAttr_GroupBox;
        private NumericUpDown AddNewClassAttr_NumericUpDown;
        private Button AddNewClassAttr_Button;
        private Label AddNewClassAttr_Labal;
        private FlowLayoutPanel AddNewClassAttr_LayoutPanel;
        private GroupBox SplitClassAttr_GroupBox;
        private FlowLayoutPanel SplitClassAttr_LayoutPanel;
        private Label SplitClassAttr_Label;
        private NumericUpDown SplitClassAttr_NumericUpDown;
        private Button SplitClassAttr_Button;
        private GroupBox MergeNode_groupBox;
        private FlowLayoutPanel MergeAttrBox_flowLayoutPanel;
        private Button MergeLeft_button;
        private Button MergeRight_button;
        private GroupBox TreeNode_groupBox;
        private FlowLayoutPanel flowLayoutPanel2;
        private GroupBox NodeStyle_groupBox;
        private MyControl.StyleControl EditorStyleControl;
        private FlowLayoutPanel StyleColorBox_LayoutPanel;
        private ComboBox StyleMapIcon_comboBox;
        private Label StyleMapIcon_label;
        private ColorDialog colorDialog1;
        private MyControl.ContrastButton StyleBoardColor_Button;
        private MyControl.ContrastButton StyleBackGround_Button;
        private MyControl.ContrastButton StyleTextColor_Button;
        private Label StylePlayEffect_label;
        private ComboBox StylePlayEffect_comboBox;
        private FlowLayoutPanel flowLayoutPanel3;
        private ComboBox StyleMapColor_comboBox;
        private TrackBar StyleFontSize_trackBar;
        private Label StyleFontShow_label1;
        private FlowLayoutPanel StyleFontSize_flowLayoutPanel1;
        private Label StyleFontShow_label2;
        private GroupBox StyleSound_groupBox;
        private Button Expoprt_button;
        private SaveFileDialog saveFileDialog1;
        private TabControl tabControl;
        private TabPage tabPage1;
        private ComboBox AudioResouce_ComboBox;
        private Label AudioShow_Label;
        private TabPage tabPage2;
        private MyControl.AudioResouceBox.AudioResoucePanel audioResoucePanel;
        private CheckBox CopyAudio_checkBox;
        private MyControl.StylePrefabsPanel.StylePrefabsPanel stylePrefabsPanel1;
        private CheckBox CopyStyleAudio_checkBox;
        private Button AudiaoClear_button;
        private Button ChangeScene_button;
        private Panel SceneShow_panel;
    }
}
