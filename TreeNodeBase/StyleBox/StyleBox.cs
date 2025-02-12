namespace FilterEditor.TreeNodeBase.StyleBox
{
    public class StyleBoxBase(bool _isHide, Color _text, Color _backGround, Color _board, int _fontSize = 30, MiniMapIconEnum _mapIcon = MiniMapIconEnum.None, DrawSpColorEnum _mapColor = DrawSpColorEnum.None, DrawSpColorEnum _playColor = DrawSpColorEnum.None, string _soundPath = "")
    {
        public bool isHide = _isHide;
        public Color textColor = _text;
        public Color backGroundColor = _backGround;
        public Color boarderColor = _board;
        public int fontSize = _fontSize;
        public MiniMapIconEnum miniMapIcon = _mapIcon;         // 小地图图标
        public DrawSpColorEnum miniMapColor = _mapColor;        // 小地图图标颜色
        public DrawSpColorEnum playEffectColor = _playColor;     // 光柱颜色
        public string dropSoundPath = _soundPath;           // 音效相对路径

        public StyleBoxBase(StyleBoxBase other) : this(other.isHide, other.textColor, other.backGroundColor, other.boarderColor, other.fontSize, other.miniMapIcon, other.miniMapColor, other.playEffectColor, other.dropSoundPath) { }

        public IList<string> GetWrite()
        {
            IList<string> res = [
                $"\tSetTextColor {textColor.R} {textColor.G} {textColor.B}",
                $"\tSetBorderColor {boarderColor.R} {boarderColor.G} {boarderColor.B}",
                $"\tSetBackgroundColor {backGroundColor.R} {backGroundColor.G} {backGroundColor.B}",
                $"\tSetFontSize {fontSize}",
            ];

            if (miniMapColor != DrawSpColorEnum.None && miniMapIcon != MiniMapIconEnum.None)
            {
                res.Add($"\tMinimapIcon {1} {miniMapColor} {miniMapIcon}");
            }

            if (playEffectColor != DrawSpColorEnum.None)
            {
                res.Add($"\tPlayEffect {playEffectColor}");
            }

            if (dropSoundPath != "")
            {
                res.Add("\tDisableDropSound True");
                res.Add($"\tCustomAlertSound \"{dropSoundPath}\"");
            }
            return res;
        }

    }
}