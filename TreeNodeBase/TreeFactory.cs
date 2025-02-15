using Newtonsoft.Json;
using FilterEditor.TreeNodeBase.StyleBox;
using FilterEditor.MyControl.AudioResouceBox;

namespace FilterEditor.TreeNodeBase
{
    /// <summary>
    /// 用于构建默认的树组
    /// </summary>
    public static class TreeFactory
    {
        /// <summary>
        /// TODO 构建一堆默认的树
        /// </summary>
        public static IList<(string, IList<Tree>)> BuildNormlTrees()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据json构建一颗树
        /// </summary>
        public static IList<(string, IList<Tree>)> BuildTreesBy(string jsonPath)
        {
            try
            {
                string textAsset = File.ReadAllText(jsonPath);
                JsonSerializerSettings settings = new() { StringEscapeHandling = StringEscapeHandling.EscapeNonAscii };
                var treeMaps = JsonConvert.DeserializeObject<List<TreeMapGreat>>(textAsset, settings)
                    ?? throw new Exception($"Load {jsonPath} Error, 没有正确的解析到json");

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
        /// 导出过滤器
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
                // 创建同名的文件夹
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
        /// 写通常物品
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


            /// 写要求
            foreach (var attr in attrs)
            {
                var (top, down) = attr.GetWrite();
                if (top != "") sw.WriteLine(top);
                if (down != "") sw.WriteLine(down);
            }

            /// 写样式
            foreach (string style in styleBox.GetWrite(filterName))
                sw.WriteLine(style);

            sw.WriteLine();
        }

        private static StyleBoxBase GetStyleBox(string typeName)
        {
            return typeName switch
            {
                "玩法与地图" => new(false, Color.Black, Color.Yellow, Color.Gold),
                "技能宝石" => new(false, Color.SkyBlue, Color.Transparent, Color.SkyBlue),
                "单手武器" or "双手武器" or "副手" or "防具" => new(false, Color.Black, Color.Yellow, Color.Gold),
                "饰品" => new(false, Color.Black, Color.Transparent, Color.Blue),
                "药剂与护符" => new(false, Color.Blue, Color.Transparent, Color.Blue),
                "高价值通货" => new(false, Color.Red, Color.White, Color.Red),
                "中上价值通货" or "品质强化通货" or "圣所钥匙" => new(false, Color.Blue, Color.Yellow, Color.Blue),
                "中下价值通货" or "通货碎片" or "异域通货" => new(false, Color.DeepSkyBlue, Color.Yellow, Color.DeepSkyBlue),
                "低价值通货" => new(false, Color.Blue, Color.Transparent, Color.Blue),
                "珠宝" => new(false, Color.Green, Color.Transparent, Color.Green),
                _ => new(false, Color.SkyBlue, Color.Transparent, Color.SkyBlue),
            };
        }

    }

    public class TreeMapGreat
    {
        public string ClassShowName { get; set; } = "UNKNOWN";  // 界面分类的名称   
        public List<TreeMap> SeqTrees { get; set; } = [];
    }

    public class TreeMap
    {
        public string ClassShowName { get; set; } = "UNKNOWN";         // 显示的中文名
        public IList<string> ClassName { get; set; } = [];             // 过滤 "Class" 筛选
        public IList<string> BaseTypeName { get; set; } = [];          // 过滤 "BaseType" 筛选
        public List<ClassAttrEnum> AttrEnum { get; set; } = [];
    }
}