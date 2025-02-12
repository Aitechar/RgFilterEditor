/// 
/// ��ȡ��ͬ�����µ�ֵ��������
///     ����GemLevel: [1, 20]
///     

namespace FilterEditor.TreeNodeBase
{
    /// <summary>
    /// ��������
    /// </summary>
    public enum ClassAttrEnum
    {
        Root,               // ��
        GemLevel,           // ��ʯ�ȼ�
        SupportLevel,       // ������ʯ�ȼ�
        Rarity,             // ϡ�ж�
        ItemLevel,          // ��Ʒ�ȼ�
        StackCount,         // �ѵ��ȼ� 
        Quality,            // Ʒ��
        WayStoneLevel,      // ��ͼ�ȼ�

        // StrNeed,            // ��������
        // AgiNeed,            // ��������
        // IntNeed,            // ��������

        Armour,             // ����
        Evasion,            // ����
        EnergyShield,       // ��������

        Spirit,             // ����

    }

    /// <summary>
    /// С��ͼͼ����ʽ
    /// </summary>
    public enum MiniMapIconEnum
    {
        None,
        Circle,
        Diamond,
        Hexagon,
        Square,
        Star,
        Triangle
    }

    /// <summary>
    /// С��ͼͼ����ɫ
    /// </summary>
    public enum DrawSpColorEnum
    {
        None,
        Red,
        Green,
        Blue,
        Brown,
        White,
        Yellow
    }

    public static class EnumExtensionMethos
    {
        public static string GetDescription(this ClassAttrEnum attrEnum)
        {
            return attrEnum switch
            {
                ClassAttrEnum.Root => "��",
                ClassAttrEnum.GemLevel => "���ܱ�ʯ�ȼ�",
                ClassAttrEnum.SupportLevel => "������ʯ�ȼ�",
                ClassAttrEnum.Quality => "Ʒ��",
                ClassAttrEnum.Rarity => "ϡ�ж�",
                ClassAttrEnum.ItemLevel => "��Ʒ�ȼ�",
                ClassAttrEnum.StackCount => "�ѵ�����",
                ClassAttrEnum.WayStoneLevel => "����ʯ�ȼ�",

                // ClassAttrEnum.StrNeed => "����Ҫ��",
                // ClassAttrEnum.AgiNeed => "����Ҫ��",
                // ClassAttrEnum.IntNeed => "����Ҫ��",

                ClassAttrEnum.Armour => "����",
                ClassAttrEnum.Evasion => "����",
                ClassAttrEnum.EnergyShield => "��������",

                ClassAttrEnum.Spirit => "����",

                _ => throw new ArgumentException($"invaild Enum: {nameof(attrEnum)}"),
            };
        }

        public static (int, int) GetLimit(this ClassAttrEnum attrEnum)
        {
            return attrEnum switch
            {
                ClassAttrEnum.Root => (0, 0),
                ClassAttrEnum.GemLevel => (1, 20),
                ClassAttrEnum.SupportLevel => (1, 3),
                ClassAttrEnum.Quality => (1, 20),
                ClassAttrEnum.Rarity => (1, 4),
                ClassAttrEnum.ItemLevel => (1, 100),
                ClassAttrEnum.StackCount => (1, 100),
                ClassAttrEnum.WayStoneLevel => (1, 16),

                // ClassAttrEnum.StrNeed => (1, 300),
                // ClassAttrEnum.AgiNeed => (1, 300),
                // ClassAttrEnum.IntNeed => (1, 300),

                ClassAttrEnum.Armour => (1, 1000),
                ClassAttrEnum.Evasion => (1, 3000),
                ClassAttrEnum.EnergyShield => (1, 3000),
                ClassAttrEnum.Spirit => (1, 200),
                
                _ => throw new ArgumentException($"invaild Enum: {nameof(attrEnum)}"),
            };
        }

        public static string GetDescription(this MiniMapIconEnum miniMapIconEnum)
        {
            return miniMapIconEnum switch
            {
                MiniMapIconEnum.None => "��",
                MiniMapIconEnum.Circle => "Բ",
                MiniMapIconEnum.Diamond => "��ʯ",
                MiniMapIconEnum.Hexagon => "����",
                MiniMapIconEnum.Square => "����",
                MiniMapIconEnum.Star => "��",
                MiniMapIconEnum.Triangle => "����",
                _ => throw new ArgumentException($"invaild Enum: {nameof(miniMapIconEnum)}"),
            };
        }

        public static string GetDescription(this DrawSpColorEnum colorEnum)
        {
            return colorEnum switch
            {
                DrawSpColorEnum.None => "��",
                DrawSpColorEnum.Red => "��",
                DrawSpColorEnum.Green => "��",
                DrawSpColorEnum.Blue => "��",
                DrawSpColorEnum.Brown => "��",
                DrawSpColorEnum.White => "��",
                DrawSpColorEnum.Yellow => "��",
                _ => throw new ArgumentException($"invaild Enum: {nameof(colorEnum)}"),
            };
        }
    }
}