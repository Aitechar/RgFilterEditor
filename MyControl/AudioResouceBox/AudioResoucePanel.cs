using NAudio.Wave;

namespace FilterEditor.MyControl.AudioResouceBox
{
    public partial class AudioResoucePanel : UserControl
    {
        public AudioResouceManager resouceManager = AudioResouceManager.Instance;
        public readonly OpenFileDialog openFileDialog;
        private readonly WaveOutEvent waveOut;

        public AudioResoucePanel()
        {
            InitializeComponent();

            openFileDialog = new()
            {
                InitialDirectory = "C:\\",
                Filter = "音频文件|*.mp3",
                RestoreDirectory = true
            };

            waveOut = new();
        }

        #region --- 增加音效资源

        private void AddResouce_Button_Click(object sender, EventArgs e)
        {
            CreateAudioResouceControlByName();
        }

        /// <summary>
        /// 创建一个音效占位符
        /// </summary>
        private void CreateAudioResouceControlByName(string audioName = "掉落音效")
        {
            var audioResource = resouceManager.CreateResouceByName(audioName);
            audioResource.audioResoucePanel = this;
            AudioResouce_FlowLayoutPanel.Controls.Add(audioResource);
        }

        /// <summary>
        /// 创建一个音效资源，根据路径
        /// </summary>
        /// <param name="path"></param>
        private void CreateAudioResouceControlByPath(string path)
        {
            var audioResource = resouceManager.CreateResouceByPath(path);
            audioResource.audioResoucePanel = this;
            AudioResouce_FlowLayoutPanel.Controls.Add(audioResource);
        }

        private void CreateAudioResouces_Button_Click(object sender, EventArgs e)
        {
            Thread thread = new(new ThreadStart(CreateAudioResouceControls));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        /// <summary>
        /// 批量导入音频资源
        /// </summary>
        private void CreateAudioResouceControls()
        {
            openFileDialog.Multiselect = true;
            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var files = openFileDialog.FileNames;

                    Invoke(() =>
                    {
                        foreach (var path in files) CreateAudioResouceControlByPath(path);
                    });
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"批量导入遇到了一个错误: {e}");
            }
            finally
            {
                openFileDialog.Multiselect = false;
            }
        }

        #endregion

        public void PlayAudio(string path)
        {
            if (waveOut.PlaybackState == PlaybackState.Playing) waveOut.Stop();

            using var reader = new AudioFileReader(path);
            waveOut.Init(reader);
            waveOut.Play();
        }
    }
}
