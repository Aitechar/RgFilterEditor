using static FilterEditor.TreeNodeBase.ClassAttrEnum;
using Newtonsoft.Json;
using System.Text;
using FilterEditor.TreeNodeBase.StyleBox;

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
        /// TODO ����json����һ����
        /// </summary>
        public static IList<(string, IList<Tree>)> BuildTreesBy(string jsonPath)
        {
            try
            {
                string textAsset = File.ReadAllText(jsonPath);
                JsonSerializerSettings settings = new() { StringEscapeHandling = StringEscapeHandling.EscapeNonAscii }; // ���ı���
                var treeMaps = JsonConvert.DeserializeObject<List<TreeMapGreat>>(textAsset, settings)
                    ?? throw new Exception($"Load {jsonPath} Error, û����ȷ�Ľ�����json");

                IList<(string, IList<Tree>)> res = [];
                foreach (var treeMap in treeMaps)
                {
                    var title = treeMap.ClassShowName;
                    IList<Tree> tress = [];
                    foreach (var tree in treeMap.SeqTrees)
                    {
                        Tree tmpTree = new(tree.ClassShowName, tree.ClassName, tree.BaseTypeName);
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
        /// TODO �����ı�
        /// </summary>
        /// <param name="trees"></param>
        public async static void SummonFilter(IList<Tree> trees, string path)
        {
            await Task.Run(() => 0);
            throw new NotImplementedException();
        }

        public static void OutPutFilter(string outputPath, IList<(string, IList<Tree>)> treeMaps)
        {
            using StreamWriter sw = new(outputPath);

            void dfs(ClassTreeNode node, IList<ClassAttrBase> attrs)
            {
                if (node.children.Count == 0)
                {
                    WriteSimple(sw, node.tree, node.styleBox, attrs);
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
        }
        /// <summary>
        /// дͨ����Ʒ TODO
        /// </summary>
        private static void WriteSimple(StreamWriter sw, Tree tree, StyleBoxBase styleBox, IList<ClassAttrBase> attrs)
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
            foreach (string style in styleBox.GetWrite())
                sw.WriteLine(style);

            sw.WriteLine();
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