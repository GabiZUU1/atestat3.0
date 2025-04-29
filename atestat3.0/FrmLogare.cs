using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace atestat3._0
{
    public partial class FrmLogare : Form
    {
        public FrmLogare()
        {
            InitializeComponent();

            this.FormClosed += (se, ar) =>
            {
                Important.ferestreDeschise.Remove(this);
            };

            Important.ferestreDeschise.Add(this);
            TemaManager.SeteazaTema(TemaManager.temaEnumCurenta);
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

        private void btnLogare_Click(object sender, EventArgs e)
        {
            if(!Utilizator.EmailCorect(txtEmail.Text.Trim()))
            {
                new CustomMessageBox().ShowDialog("Adresa de email nu este valida!", ButoaneCustomMessageBox.Ok);
            }

            if(txtEmail.Text.Trim() == string.Empty || txtParola.Text.Trim() == string.Empty)
            {
                new CustomMessageBox(TipuriCustomMessageBox.Eroare).ShowDialog("Completeaza toate campurile!", ButoaneCustomMessageBox.Ok);
                return;
            }

            Important.utilizatorCurent = DBManager.CautaUtilizator(txtEmail.Text.Trim(), Utilizator.EncripteazaText(txtParola.Text.Trim()));
            if (Important.utilizatorCurent == null)
            {
                new CustomMessageBox(TipuriCustomMessageBox.Eroare).ShowDialog("Date incorecte!", ButoaneCustomMessageBox.Ok);
                return;
            }

            Important.temaAleasa = (Teme)DBManager.GetIndexTemaSelectata();
            TemaManager.SeteazaTema(Important.temaAleasa);

            this.Hide();
            Important.ferestreDeschise.Remove(this);
            new FrmJoc().Show();
        }

        private void lnkCreazaCont_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new FrmInregistrare().ShowDialog();
        }

        private void FrmLogare_Load(object sender, EventArgs e)
        {
            btnVisibility.BackgroundImage = Important.imgPassNotVisible;
        }

        private void btnVisibility_Click(object sender, EventArgs e)
        {
            txtParola.UseSystemPasswordChar = !txtParola.UseSystemPasswordChar;
            if (txtParola.UseSystemPasswordChar) btnVisibility.BackgroundImage = Important.imgPassNotVisible;
            else btnVisibility.BackgroundImage = Important.imgPassVisible;
        }
    }
}
