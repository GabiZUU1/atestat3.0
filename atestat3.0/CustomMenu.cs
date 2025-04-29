using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace atestat3._0
{
    public class CustomMenu : Panel
    {
        public static Button _btnParent { get; set; }
        public Control _parent { get; set; }
        private List<MenuButton> Butoane { get; set; } = new List<MenuButton>();

        public CustomMenu(Control parent, Button butonActiune)
        {
            _parent = parent;
            _btnParent = butonActiune;

            InitializeComponent();
        }

        private void InitializeComponent()
        {
            _parent.Controls.Add(this);
            this.Location = new Point(_btnParent.Location.X, _btnParent.Location.Y + _btnParent.Height + 7);
            this.Size = new Size(_btnParent.Width, _btnParent.Height * 7);
            this.BackColor = TemaManager.temaCurenta.culoareTaskBar;
            this.Visible = false;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.AutoScroll = true;

            this.BringToFront();
        }

        public void AdaugaButon(MenuButton Buton)
        {
            Butoane.Add(Buton);
            this.Controls.Add(Buton);
        }

        public List<MenuButton> GetButoane() => Butoane;
    }

    public class MenuButton : Button
    {
        public override string Text { get; set; } = string.Empty;

        public MenuButton()
        {
            InitializeComponent();
        }

        public MenuButton(string text)
        {
            Text = text;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Dock = DockStyle.Top;
            this.Height = CustomMenu._btnParent.Height;
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 1;
            this.Text = Text;
            this.Font = new Font("Microsoft Sans Serif", 15f);
            this.BackColor = TemaManager.temaCurenta.culoareButoane;
        }
    }
}
