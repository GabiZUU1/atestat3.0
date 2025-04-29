using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace atestat3._0
{
    public partial class CustomMessageBox : Form
    {
        public CustomMessageBox(TipuriCustomMessageBox tip = TipuriCustomMessageBox.Atentie)
        {
            InitializeComponent();

            if (tip == TipuriCustomMessageBox.Atentie)
            {
                lblTitlu.Text = "Atentie!";
            }
            else if (tip == TipuriCustomMessageBox.Eroare)
            {
                lblTitlu.Text = "Eroare";
            }
        }

        #region Butoane
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Miscarea ferestrei
        private bool moving = false;
        private Point offset;
        private void label3_MouseDown(object sender, MouseEventArgs e)
        {
            moving = true;
            this.Opacity = 0.75;
            offset = e.Location;
        }

        private void label3_MouseMove(object sender, MouseEventArgs e)
        {
            if (moving)
            {
                this.Location = new Point(MousePosition.X - offset.X - 2, MousePosition.Y - offset.Y - 2);
            }
        }

        private void label3_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
            this.Opacity = 1;
        }
        #endregion

        public DialogResult ShowDialog(string text, ButoaneCustomMessageBox tipButoane = ButoaneCustomMessageBox.None)
        {
            lblText.Text = text;

            switch (tipButoane)
            {
                case ButoaneCustomMessageBox.None:
                    btn1.Enabled = btn2.Enabled = false;
                    btn1.Visible = btn2.Visible = false;
                    break;

                case ButoaneCustomMessageBox.DaNu:
                    btn1.Text = "Da";
                    btn1.Click += (se, ar) => { this.DialogResult = DialogResult.Yes; };

                    btn2.Text = "Nu";
                    btn2.Click += (se, ar) => { this.DialogResult = DialogResult.No; };
                    break;

                case ButoaneCustomMessageBox.OKCancel:
                    btn1.Text = "Ok";
                    btn1.Click += (se, ar) => { this.DialogResult = DialogResult.OK; };

                    btn2.Text = "Anuleaza";
                    btn2.Click += (se, ar) => { this.DialogResult = DialogResult.Cancel; };
                    break;

                case ButoaneCustomMessageBox.Ok:
                    btn1.Text = "Ok";
                    btn1.Location = new Point((this.Width - btn1.Width) / 2, btn1.Location.Y);
                    btn1.Click += (se, ar) => { this.DialogResult = DialogResult.OK; };
                    
                    btn2.Enabled = btn2.Visible = false;
                    break;
            }
            return base.ShowDialog();
        }
    }

    public enum TipuriCustomMessageBox
    {
        Atentie,
        Eroare
    }

    public enum ButoaneCustomMessageBox
    {
        Ok,
        None,
        DaNu,
        OKCancel
    }
}
