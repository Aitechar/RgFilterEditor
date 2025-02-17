using FilterEditor.MyControl.AudioResouceBox;

namespace FilterEditor.TreeNodeBase.StyleBox
{
    public class StyleBoxBase(bool _isHide, Color _text, Color _backGround, Color _board, int _fontSize = 50, MiniMapIconEnum _mapIcon = MiniMapIconEnum.None, DrawSpColorEnum _mapColor = DrawSpColorEnum.None, DrawSpColorEnum _playColor = DrawSpColorEnum.None, string _soundName = "")
    {
        public bool isHide = _isHide;
        public Color textColor = _text;
        public Color backGroundColor = _backGround;
        public Color borderColor = _board;
        public int fontSize = _fontSize;
        public MiniMapIconEnum miniMapIcon = _mapIcon;         // С��ͼͼ��
        public DrawSpColorEnum miniMapColor = _mapColor;        // С��ͼͼ����ɫ
        public DrawSpColorEnum playEffectColor = _playColor;     // ������ɫ
        public string audioName = _soundName;           // ��Ч���·��

        public StyleBoxBase(StyleBoxBase other) : this(other.isHide, other.textColor, other.backGroundColor, other.borderColor, other.fontSize, other.miniMapIcon, other.miniMapColor, other.playEffectColor, other.audioName) { }

        public StyleBoxBase() : this(false, Color.Black, Color.Transparent, Color.Black) { }

        public IList<string> GetWrite(string filterName)
        {
            IList<string> res = [
                $"\tSetTextColor {textColor.R} {textColor.G} {textColor.B}",
                $"\tSetBorderColor {borderColor.R} {borderColor.G} {borderColor.B}",
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

            if (audioName != "")
            {
                try
                {
                    var audioFileName = AudioResouceManager.Instance.GetAudioFilePath(audioName);
                    audioFileName = Path.GetFileName(audioFileName);
                    res.Add("\tDisableDropSound True");
                    res.Add($"\tCustomAlertSound \"{filterName}\\{audioFileName}\"");
                }
                catch (Exception e)
                {
                    MessageBox.Show($"��д����Ч·��ʱ������һ������: {e}", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            return res;
        }

    }
}