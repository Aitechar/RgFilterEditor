using System.ComponentModel;

namespace FilterEditor.MyControl
{
    public class ContrastButton : Button
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                base.BackColor = value;
                ForeColor = GetContrastingColor(value);
            }
        }

        private static Color GetContrastingColor(Color bgColor)
        {
            int r = 255 - bgColor.R;
            int g = 255 - bgColor.G;
            int b = 255 - bgColor.B;
            return Color.FromArgb(r, g, b);
        }
    }
}

