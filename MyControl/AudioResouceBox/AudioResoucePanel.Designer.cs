namespace FilterEditor.MyControl.AudioResouceBox
{
    partial class AudioResoucePanel
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
            AudioResouce_FlowLayoutPanel = new FlowLayoutPanel();
            panel1 = new Panel();
            AddResouce_Button = new Button();
            CreateAudioResouces_Button = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // AudioResouce_FlowLayoutPanel
            // 
            AudioResouce_FlowLayoutPanel.AutoSize = true;
            AudioResouce_FlowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            AudioResouce_FlowLayoutPanel.Location = new Point(3, 3);
            AudioResouce_FlowLayoutPanel.Name = "AudioResouce_FlowLayoutPanel";
            AudioResouce_FlowLayoutPanel.Size = new Size(1006, 647);
            AudioResouce_FlowLayoutPanel.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.AutoScroll = true;
            panel1.Controls.Add(AudioResouce_FlowLayoutPanel);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1064, 653);
            panel1.TabIndex = 1;
            // 
            // AddResouce_Button
            // 
            AddResouce_Button.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            AddResouce_Button.FlatStyle = FlatStyle.Flat;
            AddResouce_Button.Location = new Point(6, 662);
            AddResouce_Button.Name = "AddResouce_Button";
            AddResouce_Button.Size = new Size(505, 47);
            AddResouce_Button.TabIndex = 2;
            AddResouce_Button.Text = "创建空白占位";
            AddResouce_Button.UseVisualStyleBackColor = true;
            AddResouce_Button.Click += AddResouce_Button_Click;
            // 
            // CreateAudioResouces_Button
            // 
            CreateAudioResouces_Button.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            CreateAudioResouces_Button.FlatStyle = FlatStyle.Flat;
            CreateAudioResouces_Button.Location = new Point(517, 662);
            CreateAudioResouces_Button.Name = "CreateAudioResouces_Button";
            CreateAudioResouces_Button.Size = new Size(550, 47);
            CreateAudioResouces_Button.TabIndex = 3;
            CreateAudioResouces_Button.Text = "批量导入音效";
            CreateAudioResouces_Button.UseVisualStyleBackColor = true;
            CreateAudioResouces_Button.Click += CreateAudioResouces_Button_Click;
            // 
            // AudioResoucePanel
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(CreateAudioResouces_Button);
            Controls.Add(AddResouce_Button);
            Controls.Add(panel1);
            Name = "AudioResoucePanel";
            Size = new Size(1070, 712);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel AudioResouce_FlowLayoutPanel;
        private Panel panel1;
        private Button AddResouce_Button;
        private Button CreateAudioResouces_Button;
    }
}
