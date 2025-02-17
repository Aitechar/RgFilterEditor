namespace FilterEditor.MyControl.StylePrefabsPanel
{
    partial class StylePrefabsPanel
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            StyleAdd_button = new Button();
            groupBox1 = new GroupBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // StyleAdd_button
            // 
            StyleAdd_button.FlatStyle = FlatStyle.Flat;
            StyleAdd_button.Location = new Point(9, 22);
            StyleAdd_button.Name = "StyleAdd_button";
            StyleAdd_button.Size = new Size(256, 32);
            StyleAdd_button.TabIndex = 0;
            StyleAdd_button.Text = "将当前样式添加到盘中";
            StyleAdd_button.UseVisualStyleBackColor = true;
            StyleAdd_button.Click += StyleAdd_button_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(flowLayoutPanel1);
            groupBox1.Controls.Add(StyleAdd_button);
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(279, 382);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "样式盘";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(6, 60);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(267, 316);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // StylePrefabsPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox1);
            Name = "StylePrefabsPanel";
            Size = new Size(285, 388);
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button StyleAdd_button;
        private GroupBox groupBox1;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}
