
namespace FilterEditor.MyControl.AudioResouceBox
{
    public class AudioResouceManager
    {
        private static Lazy<AudioResouceManager> _instance = new(() => new AudioResouceManager());
        public static AudioResouceManager Instance => _instance.Value;


        private AudioResouceManager() { }

        public Dictionary<string, AudioResouceControl> audioMaps = [];

        public IList<string> GetAudioNames()
        {
            return [.. audioMaps.Keys];
        }

        public void DelectResource(string audioName)
        {
            audioMaps.Remove(audioName);
        }

        /// <summary>
        /// �����޸���Ƶ��Դ
        /// </summary>
        /// <returns>����¾�һ��, ���߲�����oldName����0; ����������ظ�����1;����޸ķ���2</returns>
        public int AlterResource(string oldName, string newName)
        {
            if (oldName == newName || !audioMaps.TryGetValue(oldName, out AudioResouceControl? resouce))
            {
                return 0;
            }

            if (audioMaps.ContainsKey(newName))
            {
                return 1;
            }

            audioMaps.Remove(oldName);
            audioMaps.Add(newName, resouce);
            return 2;
        }

        /// <summary>
        /// ������Ч����Ƶ����
        /// </summary>
        public string RestoreResouceName(string oldName)
        {
            int index = 0;
            string res = $"{oldName}";
            while (audioMaps.ContainsKey(res))
            {
                index++;
                res = $"{oldName}{index}";
            }
            return res;
        }

        /// <summary>
        /// �������ƴ���һ����Դ�ؼ�
        /// </summary>
        public AudioResouceControl CreateResouceByName(string audioName = "������Ч")
        {
            audioName = RestoreResouceName(audioName);
            AudioResouceControl audioResource = new()
            {
                AudioName = audioName,
            };

            audioMaps.Add(audioName, audioResource);
            return audioResource;
        }

        /// <summary>
        /// ����·������һ����Դ�ؼ�
        /// </summary>
        public AudioResouceControl CreateResouceByPath(string audioPath)
        {
            var audioName = RestoreResouceName(Path.GetFileNameWithoutExtension(audioPath));
            AudioResouceControl audioResource = new()
            {
                AudioName = audioName,
                AudioPath = audioPath,
            };
            audioMaps.Add(audioName, audioResource);
            return audioResource;
        }

        /// <summary>
        /// ��ȡ��Ч�ļ�·��
        /// </summary>
        public string? GetAudioFilePath(string audioName)
        {
            if (audioMaps.TryGetValue(audioName, out AudioResouceControl? value))
            {
                if (Path.Exists(value.AudioPath)) return value.AudioPath;
                MessageBox.Show($"����Ϊ:{audioName}��·����������Ч�ļ��������´������Ƶ�ļ�", "��Ч����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return null;
        }

        /// <summary>
        /// �����Ч�����Ƿ����
        /// </summary>
        public bool GetNameVaild(string audioName)
        {
            return audioMaps.ContainsKey(audioName);
        }
    }
}