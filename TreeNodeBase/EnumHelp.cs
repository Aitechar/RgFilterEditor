/// 
/// 获取不同分类下的值的上下限
///     例如GemLevel: [1, 20]
///     

namespace FilterEditor.TreeNodeBase
{
    /// <summary>
    /// 分类属性
    /// </summary>
    public enum ClassAttrEnum
    {
        Root,               // 根
        GemLevel,           // 宝石等级
        SupportLevel,       // 辅助宝石等级
        Rarity,             // 稀有度
        ItemLevel,          // 物品等级
        StackCount,         // 堆叠等级 
        Quality,            // 品质
        WayStoneLevel,      // 地图等级

        // StrNeed,            // 力量需求
        // AgiNeed,            // 敏捷需求
        // IntNeed,            // 智力需求

        Armour,             // 护甲
        Evasion,            // 闪避
        EnergyShield,       // 能量护盾

        Spirit,             // 精魂

    }

    /// <summary>
    /// 小地图图标样式
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
    /// 小地图图标颜色
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
                ClassAttrEnum.Root => "根",
                ClassAttrEnum.GemLevel => "技能宝石等级",
                ClassAttrEnum.SupportLevel => "辅助宝石等级",
                ClassAttrEnum.Quality => "品质",
                ClassAttrEnum.Rarity => "稀有度",
                ClassAttrEnum.ItemLevel => "物品等级",
                ClassAttrEnum.StackCount => "堆叠数量",
                ClassAttrEnum.WayStoneLevel => "换界石等级",

                // ClassAttrEnum.StrNeed => "力量要求",
                // ClassAttrEnum.AgiNeed => "敏捷要求",
                // ClassAttrEnum.IntNeed => "智力要求",

                ClassAttrEnum.Armour => "护甲",
                ClassAttrEnum.Evasion => "闪避",
                ClassAttrEnum.EnergyShield => "能量护盾",

                ClassAttrEnum.Spirit => "精魂",

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
                MiniMapIconEnum.None => "无",
                MiniMapIconEnum.Circle => "圆",
                MiniMapIconEnum.Diamond => "宝石",
                MiniMapIconEnum.Hexagon => "六边",
                MiniMapIconEnum.Square => "正方",
                MiniMapIconEnum.Star => "星",
                MiniMapIconEnum.Triangle => "三角",
                _ => throw new ArgumentException($"invaild Enum: {nameof(miniMapIconEnum)}"),
            };
        }

        public static string GetDescription(this DrawSpColorEnum colorEnum)
        {
            return colorEnum switch
            {
                DrawSpColorEnum.None => "无",
                DrawSpColorEnum.Red => "红",
                DrawSpColorEnum.Green => "绿",
                DrawSpColorEnum.Blue => "蓝",
                DrawSpColorEnum.Brown => "棕",
                DrawSpColorEnum.White => "白",
                DrawSpColorEnum.Yellow => "黄",
                _ => throw new ArgumentException($"invaild Enum: {nameof(colorEnum)}"),
            };
        }
    }
}