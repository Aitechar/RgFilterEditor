using FilterEditor.TreeNodeBase.StyleBox;

namespace FilterEditor.TreeNodeBase
{
    public class Tree
    {
        public string classShowName;
        public IList<string> className;
        public IList<string> baseTypeName;
        public readonly ClassTreeNode Root;
        public readonly HashSet<ClassAttrEnum> AllowClassAttrSet;

        public Tree(string _classShowName, IList<string> _classNames, IList<string> _baseTypeNames)
        {
            // baseClass = ""; //TODO ��json�����ú�BaseClass�����ص�ʵ����

            classShowName = _classShowName;
            className = _classNames;
            baseTypeName = _baseTypeNames;

            Root = new(new ClassAttrBase(0, 0, ClassAttrEnum.Root), this);
            AllowClassAttrSet = [];
        }

        /// <summary>
        /// ����Ŀ��ڵ��¿�����ӵķ���ö�� [.. ClassifiedAttrEnum] 
        /// </summary>
        public IList<ClassAttrEnum> GetClassAttr(ClassTreeNode node)
        {
            if (node.children.Count != 0) return [];

            IList<ClassAttrEnum> res = [.. AllowClassAttrSet];
            ClassTreeNode cur = node;
            while (cur.parent != null)
            {
                res.Remove(cur.attr.classEnum);
                cur = cur.parent;
            }
            return res;
        }

        public string GenerateNodeDescription(ClassTreeNode node)
        {
            ClassTreeNode cur = node;
            IList<string> attrDesc = [];

            while (cur.parent != null)
            {
                attrDesc.Add(" --" + cur.attr.Display);
                cur = cur.parent;
            }
            return $"{classShowName}:\n" + string.Join('\n', attrDesc);
        }

        public void SetClassAttr(IList<ClassAttrEnum> classAttrs)
        {
            foreach (var enumValue in classAttrs)
            {
                AllowClassAttrSet.Add(enumValue);
            }
        }
    }

    public class ClassTreeNode(ClassAttrBase _classifiedAttrBase, Tree _tree)
    {
        public Tree tree = _tree;
        public ClassTreeNode? parent;                       // ��Ϊ��
        public ClassAttrBase attr = _classifiedAttrBase;    // ���������
        public string Display => attr.Display;              // ��ȡ�ڵ���������
        public StyleBoxBase styleBox = new(false, Color.Red, Color.White, Color.Red);   // �ڵ���ʽ

        public readonly List<ClassTreeNode> children = [];

        /// <summary>
        /// ���
        /// </summary>
        public ClassTreeNode(ClassTreeNode copy)
            : this(new ClassAttrBase(copy.attr.MinValue, copy.attr.MaxValue, copy.attr.classEnum), copy.tree)
        {
            foreach (var child in copy.children)
            {
                var copyChild = new ClassTreeNode(child);
                children.Add(copyChild);
                copyChild.parent = this;
            }
            SortChildren();

            /// ������ʽ��
            styleBox = new(copy.styleBox);
        }

        /// <summary>
        /// Ϊ����ڵ����������������, ǰ��û���ӽڵ�
        /// </summary>
        /// <returns>��������ڵ�</returns>
        public ClassTreeNode? AddClassifiedAttr(IList<ClassTreeNode> nodes)
        {
            if (children.Count != 0) return null;
            foreach (var node in nodes)
            {
                children.Add(node);
                node.styleBox = new(styleBox);
                node.parent = this;
            }
            return this;
        }

        /// <summary>
        /// ������ڵ���һ�������ڵ㣬Ȼ�����ӻظ��ڵ�
        /// </summary>
        /// <returns>���ص�һ���ڵ�</returns>
        public ClassTreeNode? SplitTreeNode(int splitValue)
        {
            if (!attr.CanSplit(splitValue)) return null;

            // ���
            var (leftAttr, rightAttr) = attr.Split(splitValue);
            var (leftNode, rightNode) = (new ClassTreeNode(leftAttr, tree), new ClassTreeNode(rightAttr, tree));
            leftNode.styleBox = new(styleBox);
            rightNode.styleBox = new(styleBox);

            foreach (var child in children)
            {
                leftNode.children.Add(new(child));
                rightNode.children.Add(new(child));
            }

            // ���ڵ����
            if (parent != null)
            {
                parent.children.Remove(this);
                parent.children.Add(leftNode);
                parent.children.Add(rightNode);

                leftNode.parent = parent;
                rightNode.parent = parent;

                parent.SortChildren();
            }
            return leftNode;
        }

        /// <summary>
        /// ����Ƿ������ǰ, ��ڵ�ϲ�
        /// ֻ�зǸ��ڵ��Ҷ�ӽڵ���ܺϲ�
        /// </summary>
        public (bool, bool) CanMerge()
        {
            if (parent == null || children.Count != 0) return (false, false);
            var index = parent.children.IndexOf(this);
            return (index > 0 && parent.children[index - 1].children.Count == 0,
                    index + 1 < parent.children.Count && parent.children[index + 1].children.Count == 0);
        }
        /// <summary>
        /// ��������ұߺϲ��ڵ㣬ֻ�ܺϲ��Ǹ��ڵ��Ҷ�ӽڵ�
        /// ����ϲ���ͬ�����ֻ��һ���ڵ㣬��ֱ����������ڵ�
        /// </summary>
        /// <returns>�ϲ���Ľڵ�</returns>
        public ClassTreeNode? MergeNode(bool isLeft)
        {
            if (parent == null) return null;
            var (canLeft, canRight) = CanMerge();

            var index = parent.children.IndexOf(this);
            var enumType = attr.classEnum;

            if (isLeft && canLeft)
            {
                var otherNode = parent.children[index - 1];

                var left = otherNode.attr.MinValue;
                var right = attr.MaxValue;
                var mergeAttr = new ClassAttrBase(left, right, enumType);
                var mergeNode = new ClassTreeNode(mergeAttr, tree);

                parent.children.Remove(this);
                parent.children.Remove(otherNode);
                if (parent.children.Count == 0) return null;

                mergeNode.parent = parent;
                parent.children.Add(mergeNode);
                parent.SortChildren();
                return mergeNode;
            }
            else if (!isLeft && canRight)
            {
                var otherNode = parent.children[index + 1];

                var left = attr.MinValue;
                var right = otherNode.attr.MaxValue;
                var mergeAttr = new ClassAttrBase(left, right, enumType);
                var mergeNode = new ClassTreeNode(mergeAttr, tree);

                parent.children.Remove(this);
                parent.children.Remove(otherNode);
                if (parent.children.Count == 0) return null;

                mergeNode.parent = parent;
                parent.children.Add(mergeNode);
                parent.SortChildren();
                return mergeNode;
            }
            return null;
        }

        /// <summary>
        /// �����ӽڵ��Attr.MinValue��С��������
        /// </summary>
        private void SortChildren()
        {
            if (children.Count == 0) return;
            children.Sort((a, b) => a.attr.MinValue.CompareTo(b.attr.MinValue));
        }
    }

    public class ClassAttrBase(int minValue, int maxValue, ClassAttrEnum attrEnum)
    {
        public int MinValue { get; private set; } = minValue;
        public int MaxValue { get; private set; } = maxValue;

        public string Display => $"{classEnum.GetDescription()}: [{MinValue}, {MaxValue}]";
        public ClassAttrEnum classEnum = attrEnum;

        /// <summary>
        /// ���ڵ�һ��Ϊ��
        /// </summary>
        public bool CanSplit(int splitValue) { return splitValue > MinValue && splitValue <= MaxValue; }
        public (ClassAttrBase, ClassAttrBase) Split(int splitValue)
        {
            if (!CanSplit(splitValue)) throw new Exception($"���ֳܷ������ڵ㣬 ��Ϊֵ���ڷ�Χ��");
            return (new(MinValue, splitValue - 1, classEnum), new(splitValue, MaxValue, classEnum));
        }
        
        public (string, string) GetWrite()
        {
            if (classEnum == ClassAttrEnum.WayStoneLevel) return ("", "");
            return classEnum switch
            {
                ClassAttrEnum.WayStoneLevel => ("", ""),
                ClassAttrEnum.Rarity => ($"Rarity >= {GetRarity(MinValue)}", $"Rarity <= {GetRarity(MaxValue)}"),
                _ => ($"{classEnum.ToString()} >= {MinValue}", $"{classEnum.ToString()} <= {MaxValue}"),
            };
        }

        private static string GetRarity(int i)
        {
            return i switch
            {
                1 => "Normal",
                2 => "Magic",
                3 => "Rare",
                4 => "Unique",
                _ => throw new ArgumentException($"ϡ�ж���Ŵ���"),
            };
        }
    }
}