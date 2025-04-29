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
    public partial class FrmAlegeRebus: Form
    {
        private CustomMenu cm;
        public FrmAlegeRebus()
        {
            InitializeComponent();

            this.FormClosed += (se, ar) =>
            {
                Important.ferestreDeschise.Remove(this);
            };
            Important.ferestreDeschise.Add(this);

            cm = new CustomMenu(this, btnRebusuri);

            TemaManager.SeteazaTema(Important.temaAleasa);
        }

        #region Functii fereastra
        private bool movingWindow = false;
        private Point offset;
        private void lblTitlu_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                movingWindow = true;
                offset = e.Location;
                this.Opacity = 0.75;
            }
        }

        private void lblTitlu_MouseMove(object sender, MouseEventArgs e)
        {
            if (movingWindow)
            {
                this.Location = new Point(MousePosition.X - offset.X - 3, MousePosition.Y - offset.Y - 3);
            }
        }

        private void lblTitlu_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && movingWindow)
            {
                movingWindow = false;
                this.Opacity = 1;
            }
        }

        private void btnMinimise_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnInchide_Click(object sender, EventArgs e)
        {
            Important.ferestreDeschise.Remove(this);
            this.Close();
        }
        #endregion

        private Rebus rebusAles = null;
        private void FrmAlegeRebus_Load(object sender, EventArgs e)
        {
            foreach(Rebus r in Important.rebusuri.Reverse<Rebus>())
            {
                MenuButton mb = new MenuButton(r.Denumire);
                mb.Tag = r;
                mb.MouseEnter += (se, ar) =>
                {
                    lblDenumire.Visible = lblLinii.Visible = lblColoane.Visible = lblTimp.Visible = true;

                    Rebus reb = (se as MenuButton).Tag as Rebus;
                    lblDenumire.Text = "Denumire: " + reb.Denumire;
                    lblLinii.Text = "Numar linii: " + reb.NrLinii.ToString();
                    lblColoane.Text = "Numar coloane: " + reb.NrColoane.ToString();
                    lblTimp.Text = "Timp estimat: " + reb.TimpEstimat.ToString();
                };
                mb.MouseLeave += (se, ar) =>
                {
                    if(rebusAles != null)
                    {
                        lblDenumire.Text = "Denumire: " + rebusAles.Denumire;
                        lblLinii.Text = "Numar linii: " + rebusAles.NrLinii.ToString();
                        lblColoane.Text = "Numar coloane: " + rebusAles.NrColoane.ToString();
                        lblTimp.Text = "Timp estimat: " + rebusAles.TimpEstimat.ToString();


                        lblDenumire.Visible = lblLinii.Visible = lblColoane.Visible = lblTimp.Visible = btnAlege.Visible =  true;
                    }
                    else
                    {
                        lblDenumire.Text = lblLinii.Text = lblColoane.Text = lblTimp.Text = string.Empty;
                        lblDenumire.Visible = lblLinii.Visible = lblColoane.Visible = lblTimp.Visible = false;
                    }
                };
                mb.Click += (se, ar) =>
                {
                    rebusAles = (se as MenuButton).Tag as Rebus;
                    btnAlege.Visible = true;

                    cm.Visible = false;
                    btnRebusuri.BackgroundImage = Important.imgSageataJos;
                    this.Focus();
                };

                cm.AdaugaButon(mb);
            }
        }   

        private void btnAlege_Click(object sender, EventArgs e)
        {
            if (rebusAles == null) return;

            Important.rebusSelectat = rebusAles;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnRebusuri_Click(object sender, EventArgs e)
        {
            btnRebusuri.BackgroundImage = null;
            cm.Visible = !cm.Visible;
        }
    }
}
