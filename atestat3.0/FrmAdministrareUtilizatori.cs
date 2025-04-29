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
    public partial class FrmAdministrareUtilizatori : Form
    {
        public FrmAdministrareUtilizatori()
        {
            InitializeComponent();

            this.FormClosed += (se, ar) =>
            {
                Important.ferestreDeschise.Remove(this);
            };

            Important.ferestreDeschise.Add(this);

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

        private List<Utilizator> utilizatori;
        private void FrmAdministrareUtilizatori_Load(object sender, EventArgs e)
        {
            foreach (Teme t in Enum.GetValues(typeof(Teme)))
            {
                cmbTeme.Items.Add(t);
            }

            dgv.Font = new Font("Microsoft Sans Serif", 12f);

            utilizatori = DBManager.GetUtilizatori();
            foreach (Utilizator u in utilizatori)
            {
                dgv.Rows.Add(u.Id, u.NumeUtilizator, u.Email, u.TemaAleasa, u.TipUtilizator == TipUtilizator.Admin);
            }
        }

        private Utilizator uCurent = null;
        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            uCurent = utilizatori[e.RowIndex];
            IncarcaDate();
        }

        private void IncarcaDate()
        {
            txtNume.Text = uCurent.NumeUtilizator;
            txtEmail.Text = uCurent.Email;
            cmbTeme.SelectedIndex = (int)uCurent.TemaAleasa;
            cmbTip.SelectedIndex = uCurent.TipUtilizator == TipUtilizator.Utilizator ? 0 : 1;
        }

        private void btnModifica_Click(object sender, EventArgs e)
        {
            uCurent.ModificaDate(txtNume.Text.Trim(), txtEmail.Text.Trim(), cmbTeme.SelectedIndex, (TipUtilizator)cmbTip.SelectedIndex);
        }
    }
}
