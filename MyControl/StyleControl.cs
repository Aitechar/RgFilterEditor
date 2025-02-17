using System.ComponentModel;
using FilterEditor.TreeNodeBase.StyleBox;

namespace FilterEditor.MyControl
{
    public partial class StyleControl : UserControl
    {
        #region 成员
        private Color _textColor = Color.Black;
        private int _fontSize = 30;
        private string _styleText = "样式";
        private Color _backGroundColor = Color.SkyBlue;
        private Color _borderColor = Color.Black;
        private int _borderWidth = 2;
        private bool _isStrickOut = false;
        #endregion


        #region 属性
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color TextColor { get => _textColor; set { _textColor = value; Invalidate(); } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string StyleText { get => _styleText; set { _styleText = value; Invalidate(); } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int FontSize { get => _fontSize; set { if (value > 0 && value <= 50) _fontSize = value; Invalidate(); } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color BackGroundColor { get => _backGroundColor; set { _backGroundColor = value; Invalidate(); } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color BoarderColor { get => _borderColor; set { _borderColor = value; Invalidate(); } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int BorderWidth { get => _borderWidth; set { if (value > 0) _borderWidth = value; Invalidate(); } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsStrickOut { get => _isStrickOut; set { _isStrickOut = value; Invalidate(); } }
        #endregion

        public StyleControl()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // base.OnPaint(e);
            using Graphics g = e.Graphics;
            using Font font = new(Font.Name, _fontSize * 25.4f / 72f, _isStrickOut ? FontStyle.Strikeout : FontStyle.Regular);

            /// 单行显示，调整范围
            var size = g.MeasureString(_styleText, font);
            int rectWidth = (int)size.Width + 10;
            int rectHeight = (int)size.Height + 10;

            using SolidBrush backGroundBrush = new(_backGroundColor);
            using SolidBrush textBrush = new(_textColor);
            using Pen borderPen = new(_borderColor) { Width = _borderWidth };

            using StringFormat sf = new()
            {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Center,
            };

            int penOffset = (int)(borderPen.Width / 2);
            Rectangle borderRectangle = new(new Point((Width - rectWidth) / 2, (Height - rectHeight) / 2), new Size(rectWidth - penOffset, rectHeight - penOffset));

            g.FillRectangle(backGroundBrush, borderRectangle);
            g.DrawRectangle(borderPen, borderRectangle);
            g.DrawString(_styleText, font, textBrush, borderRectangle, sf);
        }

        public void UpdateValue(StyleBoxBase box, string text = "")
        {
            TextColor = box.textColor;
            FontSize = box.fontSize;
            BackGroundColor = box.backGroundColor;
            BoarderColor = box.borderColor;
            IsStrickOut = box.isHide;

            if (text.Length != 0)
            {
                _styleText = text;
            }
        }
    }
}
