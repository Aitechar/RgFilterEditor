using Newtonsoft.Json;
using FilterEditor.TreeNodeBase.StyleBox;
using FilterEditor.MyControl.AudioResouceBox;

namespace FilterEditor.TreeNodeBase
{
    /// <summary>
    /// ���ڹ���Ĭ�ϵ�����
    /// </summary>
    public static class TreeFactory
    {
        /// <summary>
        /// TODO ����һ��Ĭ�ϵ���
        /// </summary>
        public static IList<(string, IList<Tree>)> BuildNormlTrees()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// ����json����һ����
        /// </summary>
        public static IList<(string, IList<Tree>)> BuildTreesBy(string jsonPath)
        {
            try
            {
                string textAsset = File.ReadAllText(jsonPath);
                JsonSerializerSettings settings = new() { StringEscapeHandling = StringEscapeHandling.EscapeNonAscii };
                var treeMaps = JsonConvert.DeserializeObject<List<TreeMapGreat>>(textAsset, settings)
                    ?? throw new Exception($"Load {jsonPath} Error, û����ȷ�Ľ�����json");

                IList<(string, IList<Tree>)> res = [];
                foreach (var treeMap in treeMaps)
                {
                    var title = treeMap.ClassShowName;
                    IList<Tree> tress = [];
                    foreach (var tree in treeMap.SeqTrees)
                    {
                        Tree tmpTree = new(tree.ClassShowName, tree.ClassName, tree.BaseTypeName, GetStyleBox(title));
                        tmpTree.SetClassAttr(tree.AttrEnum);
                        tress.Add(tmpTree);
                    }
                    res.Add((title, tress));
                }
                return res;
            }
            catch (Exception e)
            {
                MessageBox.Show($"Load {jsonPath} Error: {e}");
            }
            return [];
        }

        /// <summary>
        /// ����������
        /// </summary>
        public static void OutPutFilter(string outputPath, IList<(string, IList<Tree>)> treeMaps, bool IsCopyAudio = false)
        {
            using StreamWriter sw = new(outputPath);
            HashSet<string> audioNames = [];
            var filterName = Path.GetFileNameWithoutExtension(outputPath);

            void dfs(ClassTreeNode node, IList<ClassAttrBase> attrs)
            {
                if (node.children.Count == 0)
                {
                    WriteSimple(sw, node.tree, node.styleBox, attrs, filterName);
                    if (IsCopyAudio) audioNames.Add(node.styleBox.audioName);
                    return;
                }
                foreach (var child in node.children)
                {
                    attrs.Add(child.attr);
                    dfs(child, attrs);
                    attrs.Remove(child.attr);
                }
            }

            foreach (var trees in treeMaps)
            {
                foreach (var tree in trees.Item2)
                {
                    var root = tree.Root;
                    dfs(root, []);
                }
            }

            if (IsCopyAudio && audioNames.Count != 0)
            {
                var rootPath = Path.GetDirectoryName(outputPath) ?? "";
                var audioDirPath = Path.Combine(rootPath, Path.GetFileNameWithoutExtension(outputPath)) + Path.DirectorySeparatorChar;
                // ����ͬ�����ļ���
                if (!Directory.Exists(audioDirPath))
                    Directory.CreateDirectory(audioDirPath);

                var audioManger = AudioResouceManager.Instance;
                foreach (var audioName in audioNames)
                {
                    string? audioOriginFileName = audioManger.GetAudioFilePath(audioName);

                    if (audioOriginFileName != null)
                    {
                        string destinationFilePath = Path.Combine(audioDirPath, Path.GetFileName(audioOriginFileName));
                        File.Copy(audioOriginFileName, destinationFilePath, overwrite: true);
                    }
                }
            }
        }

        /// <summary>
        /// дͨ����Ʒ
        /// </summary>
        private static void WriteSimple(StreamWriter sw, Tree tree, StyleBoxBase styleBox, IList<ClassAttrBase> attrs, string filterName)
        {
            var classNames = tree.className;
            var baseTypes = tree.baseTypeName;

            sw.Write($"{(styleBox.isHide ? "Hide" : "Show")}  # {tree.classShowName}");
            foreach (var attr in attrs) sw.WriteLine($"-->{attr.classEnum}:[{attr.MinValue}, {attr.MaxValue}]");
            sw.WriteLine();

            if (classNames.Count != 0)
            {
                sw.Write("\tClass");
                foreach (var className in classNames) sw.Write($" \"{className}\"");
                sw.WriteLine();
            }

            if (baseTypes.Count != 0)
            {
                sw.Write("\tBaseType");
                foreach (var baseType in baseTypes) sw.Write($" \"{baseType}\"");
                sw.WriteLine();
            }


            /// дҪ��
            foreach (var attr in attrs)
            {
                var (top, down) = attr.GetWrite();
                if (top != "") sw.WriteLine(top);
                if (down != "") sw.WriteLine(down);
            }

            /// д��ʽ
            foreach (string style in styleBox.GetWrite(filterName))
                sw.WriteLine(style);

            sw.WriteLine();
        }

        private static StyleBoxBase GetStyleBox(string typeName)
        {
            return typeName switch
            {
                "�淨���ͼ" => new(false, Color.Black, Color.Yellow, Color.Gold),
                "���ܱ�ʯ" => new(false, Color.SkyBlue, Color.Transparent, Color.SkyBlue),
                "��������" or "˫������" or "����" or "����" => new(false, Color.Black, Color.Yellow, Color.Gold),
                "��Ʒ" => new(false, Color.Black, Color.Transparent, Color.Blue),
                "ҩ���뻤��" => new(false, Color.Blue, Color.Transparent, Color.Blue),
                "�߼�ֵͨ��" => new(false, Color.Red, Color.White, Color.Red),
                "���ϼ�ֵͨ��" or "Ʒ��ǿ��ͨ��" or "ʥ��Կ��" => new(false, Color.Blue, Color.Yellow, Color.Blue),
                "���¼�ֵͨ��" or "ͨ����Ƭ" or "����ͨ��" => new(false, Color.DeepSkyBlue, Color.Yellow, Color.DeepSkyBlue),
                "�ͼ�ֵͨ��" => new(false, Color.Blue, Color.Transparent, Color.Blue),
                "�鱦" => new(false, Color.Green, Color.Transparent, Color.Green),
                _ => new(false, Color.SkyBlue, Color.Transparent, Color.SkyBlue),
            };
        }

    }

    public class TreeMapGreat
    {
        public string ClassShowName { get; set; } = "UNKNOWN";  // ������������   
        public List<TreeMap> SeqTrees { get; set; } = [];
    }

    public class TreeMap
    {
        public string ClassShowName { get; set; } = "UNKNOWN";         // ��ʾ��������
        public IList<string> ClassName { get; set; } = [];             // ���� "Class" ɸѡ
        public IList<string> BaseTypeName { get; set; } = [];          // ���� "BaseType" ɸѡ
        public List<ClassAttrEnum> AttrEnum { get; set; } = [];
    }
}