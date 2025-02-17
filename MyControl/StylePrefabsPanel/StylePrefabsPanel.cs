using FilterEditor.TreeNodeBase.StyleBox;
using System.ComponentModel;

namespace FilterEditor.MyControl.StylePrefabsPanel
{
    public partial class StylePrefabsPanel : UserControl
    {
        public event Action? OnCopyStyleButtonClicked;
        public event Action<StyleBoxBase>? OnStyleApply;

        private readonly Size _styleButtonSize = new(125, 47);
        private readonly int _buttonCount = 12;

        private readonly IList<StylePrefabButton> _buttons = [];
        private int _index = 0;

        public StylePrefabsPanel()
        {
            InitializeComponent();

            for (int _ = 0; _ < _buttonCount; _++)
                CreateStyleButton();

        }
        /// <summary>
        /// 创建一个颜色按钮
        /// </summary>
        private void CreateStyleButton(StyleBoxBase? styleBox = null)
        {
            styleBox ??= new();
            var btn = new StylePrefabButton
            {
                BackColor = styleBox.backGroundColor,
                ForeColor = styleBox.textColor,
                BorderColor = styleBox.borderColor,
                IsStrikeOut = styleBox.isHide,
                Size = _styleButtonSize,
                Font = new(Font.Name, 10),
                Tag = styleBox,
                Text = "样式"
            };

            btn.Click += (s, e) =>
            {
                if (s is Control { Tag: StyleBoxBase selectPreset })
                    OnStyleApply?.Invoke(selectPreset);
            };

            flowLayoutPanel1.Controls.Add(btn);
            _buttons.Add(btn);
        }

        /// <summary>
        /// 将样式覆盖index下的一个按钮
        /// </summary>
        public void CopyStyle(StyleBoxBase styleBox, bool isCopyAudio = true)
        {
            var btn = _buttons[_index];
            var style = new StyleBoxBase(styleBox);
            if (!isCopyAudio) style.audioName = "";
            btn.ApplyStyle(style);
            _index = (_index + 1) % _buttonCount;
        }

        private void StyleAdd_button_Click(object sender, EventArgs e)
        {
            OnCopyStyleButtonClicked?.Invoke();
        }
    }
}
