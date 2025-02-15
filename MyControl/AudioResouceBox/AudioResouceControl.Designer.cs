namespace FilterEditor.MyControl.AudioResouceBox
{
    partial class AudioResouceControl
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
            AudioPath_Label = new Label();
            AlterPath_Button = new Button();
            Delete_Button = new Button();
            AudioName_TextBox = new TextBox();
            AudioPlay_Button = new Button();
            SuspendLayout();
            // 
            // AudioPath_Label
            // 
            AudioPath_Label.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            AudioPath_Label.Location = new Point(108, 11);
            AudioPath_Label.Name = "AudioPath_Label";
            AudioPath_Label.Size = new Size(728, 24);
            AudioPath_Label.TabIndex = 0;
            AudioPath_Label.Text = "音效路径";
            AudioPath_Label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // AlterPath_Button
            // 
            AlterPath_Button.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            AlterPath_Button.Location = new Point(842, 11);
            AlterPath_Button.Name = "AlterPath_Button";
            AlterPath_Button.Size = new Size(75, 24);
            AlterPath_Button.TabIndex = 1;
            AlterPath_Button.Text = "路径修改";
            AlterPath_Button.UseVisualStyleBackColor = true;
            AlterPath_Button.Click += AlterPath_Button_Click;
            // 
            // Delete_Button
            // 
            Delete_Button.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            Delete_Button.Location = new Point(979, 11);
            Delete_Button.Name = "Delete_Button";
            Delete_Button.Size = new Size(50, 24);
            Delete_Button.TabIndex = 2;
            Delete_Button.Text = "删除";
            Delete_Button.UseVisualStyleBackColor = true;
            Delete_Button.Click += Delete_Button_Click;
            // 
            // AudioName_TextBox
            // 
            AudioName_TextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            AudioName_TextBox.Location = new Point(14, 11);
            AudioName_TextBox.Name = "AudioName_TextBox";
            AudioName_TextBox.Size = new Size(88, 23);
            AudioName_TextBox.TabIndex = 3;
            AudioName_TextBox.Enter += AudioName_TextBox_Enter;
            AudioName_TextBox.Leave += AudioName_TextBox_Leave;
            // 
            // AudioPlay_Button
            // 
            AudioPlay_Button.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            AudioPlay_Button.Location = new Point(923, 11);
            AudioPlay_Button.Name = "AudioPlay_Button";
            AudioPlay_Button.Size = new Size(50, 24);
            AudioPlay_Button.TabIndex = 4;
            AudioPlay_Button.Text = "试听";
            AudioPlay_Button.UseVisualStyleBackColor = true;
            AudioPlay_Button.Click += AudioPlay_Button_Click;
            // 
            // AudioResouceControl
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(AudioPlay_Button);
            Controls.Add(AudioName_TextBox);
            Controls.Add(Delete_Button);
            Controls.Add(AlterPath_Button);
            Controls.Add(AudioPath_Label);
            Name = "AudioResouceControl";
            Size = new Size(1040, 45);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label AudioPath_Label;
        private Button AlterPath_Button;
        private Button Delete_Button;
        private TextBox AudioName_TextBox;
        private Button AudioPlay_Button;
    }
}
