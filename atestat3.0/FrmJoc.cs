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
    public partial class FrmJoc : Form
    {
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Right || keyData == Keys.Left || keyData == Keys.Up || keyData == Keys.Down)
            {
                FrmJoc_KeyDown(this, new KeyEventArgs(keyData));
                return true;
            }
            else if (keyData == Keys.Enter && gj != null && !gj.tbActiv)
            {
                gj.IncarcaTextBox();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private CustomMenu cmRebus;
        private CustomMenu cmSetari;
        private CustomMenu cmAdmin;
        public FrmJoc()
        {
            InitializeComponent();

            this.components = new Container();

            this.FormClosed += (se, ar) =>
            {
                Important.ferestreDeschise.Remove(this);
                Application.Exit();
            };
            Important.ferestreDeschise.Add(this);

            if (Important.utilizatorCurent.TipUtilizator == TipUtilizator.Admin)
            {
                cmAdmin = new CustomMenu(pnl, btnAdministrare);
            }
            else
            {
                btnSetari.Location = btnAdministrare.Location;
                btnAdministrare.Visible = false;
            }
            cmRebus = new CustomMenu(pnl, btnRebus);
            cmSetari = new CustomMenu(pnl, btnSetari);
            cmAdmin = new CustomMenu(pnl, btnAdministrare);

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

        public Timer TimerJoc = null;
        private GridJoc gj = null;
        private RezolvariManager rm = null;
        private void FrmJoc_Load(object sender, EventArgs e)
        {
            MenuButton rMb1 = new MenuButton();
            rMb1.Text = "Alege un rebus";
            rMb1.Click += (se, ar) =>
            {
                if (new FrmAlegeRebus().ShowDialog() == DialogResult.OK)
                {
                    cmRebus.Visible = false;
                    cmSetari.Visible = false;
                    cmAdmin.Visible = false;
                    IncarcaJoc();
                    pnlJoc.Focus();
                }
            };
            cmRebus.AdaugaButon(rMb1);

            /////////////////////////
            MenuButton aMb1 = new MenuButton();
            aMb1.Text = "Administreaza utilizatori";
            aMb1.Font = new Font("Microsoft Sans Serif", 11f);
            aMb1.Click += (se, ar) =>
            {
                new FrmAdministrareUtilizatori().ShowDialog();
                cmRebus.Visible = false;
                cmSetari.Visible = false;
                cmAdmin.Visible = false;

                if (gj != null && gj.tbActiv)
                {
                    gj.tb.Focus();
                }
            };

            cmAdmin.AdaugaButon(aMb1);

            /////////////////////////
            MenuButton sMb1 = new MenuButton();
            sMb1.Text = "Setari joc";
            sMb1.Click += (se, ar) =>
            {
                new FrmSetari(FrmSetari.TipSetari.Joc).ShowDialog();
                cmRebus.Visible = false;
                cmSetari.Visible = false;
                cmAdmin.Visible = false;

                AplicaSetariJoc(Important.utilizatorCurent.SetariJoc);
                gj?.AplicaSetari(); //DACA NU ESTE NULL FACE FUNCTIA ("?" => != NULL)

                if(gj != null && gj.tbActiv)
                {
                    gj.tb.Focus();
                }
            };

            MenuButton sMb2 = new MenuButton();
            sMb2.Text = "Setari utilizator";
            sMb2.Click += (se, ar) =>
            {
                new FrmSetari(FrmSetari.TipSetari.Utilizator).ShowDialog();
                cmRebus.Visible = false;
                cmSetari.Visible = false;
                cmAdmin.Visible = false;

                if (gj != null && gj.tbActiv)
                {
                    gj.tb.Focus();
                }
            };

            cmSetari.AdaugaButon(sMb2);
            cmSetari.AdaugaButon(sMb1);
        }

        public void SeteazaTitlu()
        {
            if (Important.rebusSelectat == null) return;
            lblTitlu.Text = $"Utilizator: {Important.utilizatorCurent.NumeUtilizator} - Rebus: {Important.rebusSelectat.Denumire}";
        }

        public void StopTimer()
        {
            TimerJoc.Stop();
            return;
        }

        private void IncarcaJoc()
        {
            if (Important.rebusSelectat != null)
            {
                gj = new GridJoc(pnlJoc, Important.rebusSelectat);
                rm = new RezolvariManager(dgv, gj.Rebus.Rezolvari);
                SeteazaTitlu();
                grDef.Enabled = true;
                rm.IncarcaRezolvari();
                grDef.Text = "Definitii - Orizontal";

                if (!Important.utilizatorCurent.SetariJoc["DezTimp"])
                {
                    lblTimer.Visible = true;

                    if (TimerJoc != null) // daca exista deja un timer
                    {
                        TimerJoc.Stop();
                        secunde = 0;
                    }
                    TimerJoc = new Timer(this.components);
                    TimerJoc.Interval = 1000;
                    TimerJoc.Tick += TimerTick;
                    TimerJoc.Start();
                }
                else
                {
                    lblTimer.Visible = false;
                }
            }
        }

        private int secunde = 0;
        private void TimerTick(object sender, EventArgs args)
        {
            secunde++;
            lblTimer.Text = $"Timp scurs: {secunde / 60 / 60 % 24:D2}:{secunde / 60 % 60:D2}:{secunde % 60:D2}";
        }

        private void btnOrizontal_Click(object sender, EventArgs e)
        {
            rm.IncarcaRezolvari(OrientareRezolvare.Orizontal);
            grDef.Text = "Definitii - Orizontal";
        }

        private void btnVertical_Click(object sender, EventArgs e)
        {
            rm.IncarcaRezolvari(OrientareRezolvare.Vertical);
            grDef.Text = "Definitii - Vertical";
        }

        private void btnRebus_Click(object sender, EventArgs e)
        {
            cmRebus.Visible = !cmRebus.Visible;
        }

        private void btnAdministrare_Click(object sender, EventArgs e)
        {
            cmAdmin.Visible = !cmAdmin.Visible;
        }

        private void btnSetari_Click(object sender, EventArgs e)
        {
            cmSetari.Visible = !cmSetari.Visible;
        }

        private void FrmJoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (gj == null) return;
            if (gj != null && gj.tbActiv) return;

            if (e.KeyValue == (char)Keys.A || e.KeyValue == (char)Keys.Left)
            {
                gj.MutaCelula(gj.celulaSelectataPoz.Item1, gj.celulaSelectataPoz.Item2 - 1);
            }
            else if (e.KeyValue == (char)Keys.D || e.KeyValue == (char)Keys.Right)
            {
                gj.MutaCelula(gj.celulaSelectataPoz.Item1, gj.celulaSelectataPoz.Item2 + 1);
            }
            else if (e.KeyValue == (char)Keys.W || e.KeyValue == (char)Keys.Up)
            {
                gj.MutaCelula(gj.celulaSelectataPoz.Item1 - 1, gj.celulaSelectataPoz.Item2);
            }
            else if (e.KeyValue == (char)Keys.S || e.KeyValue == (char)Keys.Down)
            {
                gj.MutaCelula(gj.celulaSelectataPoz.Item1 + 1, gj.celulaSelectataPoz.Item2);
            }
        }

        private void AplicaSetariJoc(Dictionary<string, bool> setari)
        {
            if (gj == null) return;

            if (setari["DezTimp"])
            {
                if (TimerJoc != null)
                {
                    TimerJoc.Stop();
                    lblTimer.Visible = false;
                }
            }
            else
            {
                if (TimerJoc == null)
                {
                    TimerJoc = new Timer(this.components);
                    TimerJoc.Interval = 1000;
                    TimerJoc.Tick += TimerTick;
                    TimerJoc.Start();
                }
                else
                {
                    TimerJoc.Start();
                }
                lblTimer.Visible = true;
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dgr = dgv.Rows[e.RowIndex];

            Rezolvare r = rm.GasesteRezolvare(dgr);
            gj.SelecteazaMaiMulteCelule(r);
        }
    }
}
