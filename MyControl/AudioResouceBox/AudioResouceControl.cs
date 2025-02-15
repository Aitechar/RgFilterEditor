using System.ComponentModel;

namespace FilterEditor.MyControl.AudioResouceBox
{
    public partial class AudioResouceControl : UserControl
    {
        public AudioResoucePanel? audioResoucePanel = null;

        private Color _borderColor = Color.Black;
        private string _originText = "";

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color BorderColor { get => _borderColor; set { _borderColor = value; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string AudioName { get => AudioName_TextBox.Text; set { AudioName_TextBox.Text = value; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string AudioPath { get => AudioPath_Label.Text; set { AudioPath_Label.Text = value; } }

        public AudioResouceControl()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using Graphics g = e.Graphics;
            using Pen pen = new(_borderColor);
            g.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
        }

        private void Delete_Button_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否删除", "确定删除", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (Parent != null)
                {
                    Parent.Controls.Remove(this);
                    AudioResouceManager.Instance.DelectResource(AudioName);
                    Dispose();
                }
            }
        }

        // 检查音频路径
        public static bool CheckAudioPath(string path)
        {
            return Path.Exists(path);
        }

        # region 修改名称

        private void AudioName_TextBox_Leave(object sender, EventArgs e)
        {
            AlertName(_originText, AudioName);
        }

        private void AlertName(string old, string now)
        {
            var res = AudioResouceManager.Instance.AlterResource(old, now);

            if (res == 0)
            {
                AudioName = old;
            }
            else if (res == 1)
            {
                AudioName = old;
                MessageBox.Show($"重复的音效名称");
            }
            else
            {
                AudioName = now;
            }
        }

        private void AudioName_TextBox_Enter(object sender, EventArgs e)
        {
            _originText = AudioName;
        }

        #endregion

        # region 修改路径

        private void AlterPath_Button_Click(object sender, EventArgs e)
        {
            Thread thread = new(new ThreadStart(AlterPath));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void AlterPath()
        {
            if (audioResoucePanel != null && audioResoucePanel.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                AudioPath = audioResoucePanel.openFileDialog.FileName;
                var newName = AudioResouceManager.Instance.RestoreResouceName(Path.GetFileNameWithoutExtension(AudioPath));
                AlertName(AudioName, newName);
            }
        }

        # endregion

        private void AudioPlay_Button_Click(object sender, EventArgs e)
        {
            if (audioResoucePanel != null && CheckAudioPath(AudioPath))
            {
                audioResoucePanel.PlayAudio(AudioPath);
            }
        }
    }
}
