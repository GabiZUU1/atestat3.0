using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace atestat3._0
{
    public partial class FrmInregistrare : Form
    {
        public FrmInregistrare()
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
            this.Close();
        }
        #endregion

        private void btnInregistrare_Click(object sender, EventArgs e)
        {
            if(DBManager.CheckNameExists(txtNume.Text.Trim()))
            {
                new CustomMessageBox(TipuriCustomMessageBox.Atentie).ShowDialog("Exista un utilizator cu acest nume deja!\nAlege unul nou!", ButoaneCustomMessageBox.Ok);
                txtNume.Focus();
                return;
            }

            if(DBManager.CheckEmailExists(txtEmail.Text.Trim()))
            {
                new CustomMessageBox(TipuriCustomMessageBox.Atentie).ShowDialog("Exista deja un cont cu aceasta adresa de email!", ButoaneCustomMessageBox.Ok);
                txtEmail.Focus();
                return;
            }

            foreach(TextBox t in this.Controls.OfType<TextBox>())
            {
                if(t.Text.Trim() == string.Empty)
                {
                    new CustomMessageBox(TipuriCustomMessageBox.Atentie).ShowDialog("Completeaza toate campurile!", ButoaneCustomMessageBox.Ok);
                    t.Focus();
                    return;
                }
            }

            if(txtParola1.Text.Trim() != txtParola2.Text.Trim())
            {
                new CustomMessageBox(TipuriCustomMessageBox.Atentie).ShowDialog("Parolele nu coincid!", ButoaneCustomMessageBox.Ok);
                txtParola2.Focus();
                return;
            }

            if(!Utilizator.EmailCorect(txtEmail.Text.Trim()))
            {
                txtEmail.Focus();
                return;
            }

            Utilizator utili = new Utilizator(
                DBManager.GetLastUserId(), 
                txtNume.Text.Trim(), txtEmail.Text.Trim(),
                Utilizator.EncripteazaText(txtParola1.Text.Trim()), 
                TemaManager.temaEnumCurenta, TipUtilizator.Utilizator);

            DBManager.AdaugaUtilizator(utili);
            new CustomMessageBox().ShowDialog("Contul a fost creat cu succes!", ButoaneCustomMessageBox.Ok);
            this.Close();
        }

        private void btnAnuleaza_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            TemaManager.SeteazaTema(Teme.Tema1);
        }

        private void FrmInregistrare_Load(object sender, EventArgs e)
        {
            btnVisibility.BackgroundImage = Important.imgPassNotVisible;
        }

        private void btnVisibility_Click(object sender, EventArgs e)
        {
            txtParola1.UseSystemPasswordChar = txtParola2.UseSystemPasswordChar = !txtParola1.UseSystemPasswordChar;
            if (txtParola1.UseSystemPasswordChar) btnVisibility.BackgroundImage = Important.imgPassNotVisible;
            else btnVisibility.BackgroundImage = Important.imgPassVisible;
        }
    }
}
