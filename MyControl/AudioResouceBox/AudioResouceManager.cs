
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
        /// 尝试修改音频资源
        /// </summary>
        /// <returns>如果新旧一致, 或者不存在oldName返回0; 如果新名称重复返回1;完成修改返回2</returns>
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
        /// 生成有效的音频名称
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
        /// 根据名称创建一个资源控件
        /// </summary>
        public AudioResouceControl CreateResouceByName(string audioName = "掉落音效")
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
        /// 根据路径创建一个资源控件
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
        /// 获取音效文件路径
        /// </summary>
        public string? GetAudioFilePath(string audioName)
        {
            if (audioMaps.TryGetValue(audioName, out AudioResouceControl? value))
            {
                if (Path.Exists(value.AudioPath)) return value.AudioPath;
                MessageBox.Show($"名称为:{audioName}的路径不存在音效文件，将不会拷贝此音频文件", "音效导出", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return null;
        }

        /// <summary>
        /// 检查音效名称是否存在
        /// </summary>
        public bool GetNameVaild(string audioName)
        {
            return audioMaps.ContainsKey(audioName);
        }
    }
}