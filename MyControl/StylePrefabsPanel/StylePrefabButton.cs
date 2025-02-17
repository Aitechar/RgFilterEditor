using System.ComponentModel;
using FilterEditor.TreeNodeBase.StyleBox;

namespace FilterEditor.MyControl.StylePrefabsPanel
{
    public class StylePrefabButton : Button
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color BorderColor { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsStrikeOut { get; set; }

        private readonly int _boardLen = 4;

        public StylePrefabButton()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using Pen borderPen = new(BorderColor, _boardLen);
            int penOffset = (int)(borderPen.Width / 2);
            e.Graphics.DrawRectangle(borderPen, penOffset, penOffset, Width - penOffset * 2, Height - penOffset * 2);

            if (IsStrikeOut && Text != "")
            {
                using Pen pen = new(ForeColor, 1);
                var textSize = TextRenderer.MeasureText(Text, Font);
                var strikeY = Height / 2;
                e.Graphics.DrawLine(
                    pen,
                    (Width - textSize.Width) / 2, strikeY,
                    (Width + textSize.Width) / 2, strikeY
                );
            }
        }

        /// <summary>
        /// 将样式应用在当前的按钮上
        /// </summary>
        /// <param name="styleBox"></param>
        public void ApplyStyle(StyleBoxBase styleBox)
        {
            BorderColor = styleBox.borderColor;
            ForeColor = styleBox.textColor;
            BackColor = styleBox.backGroundColor;
            IsStrikeOut = styleBox.isHide;
            Tag = styleBox;

            Text = $"{(styleBox.miniMapColor != TreeNodeBase.DrawSpColorEnum.None && styleBox.miniMapIcon != TreeNodeBase.MiniMapIconEnum.None ? '■' : "")} 样式 {(styleBox.audioName == "" ? "" : '♩')}";

            Invalidate();
        }
    }
}
