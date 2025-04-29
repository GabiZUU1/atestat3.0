using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace atestat3._0
{
    public partial class FrmSetari: Form
    {
        public enum TipSetari
        {
            Joc,
            Utilizator
        }

        public FrmSetari(TipSetari tipSetari)
        {
            InitializeComponent();

            this.FormClosed += (se, ar) =>
            {
                Important.ferestreDeschise.Remove(this);

                if (setariJocSchimbate && tip == TipSetari.Joc) DBManager.SalveazaSetariJoc(Important.utilizatorCurent.SetariJoc);
                if (temaSchimbata && tip == TipSetari.Joc) DBManager.SalveazaTemaUtilizator(cmbTeme.SelectedIndex);
                if (dateSchimbate && tip == TipSetari.Utilizator) DBManager.SalveazaSetariUtilizator(txtNume.Text, txtEmail.Text, Utilizator.EncripteazaText(txtParola.Text));
            };
            Important.ferestreDeschise.Add(this);

            TemaManager.SeteazaTema(Important.temaAleasa);

            tip = tipSetari;
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

        private void btnInchide_Click(object sender, EventArgs e)
        {
            Important.ferestreDeschise.Remove(this);
            this.Close();
        }
        #endregion

        private TipSetari tip;

        private void FrmSetari_Load(object sender, EventArgs e)
        {
            if (tip == TipSetari.Joc) IncarcaSetariJoc();
            else IncarcaSetariUtilizator();
        }

        private Font fnt = new Font("Microsoft Sans Serif", 19f);
        private List<Button> setari;

        private ComboBox cmbTeme;

        private void IncarcaSetariJoc()
        {
            setari = new List<Button>();

            int i = 1;
            foreach(var s in Important.utilizatorCurent.SetariJoc)
            {
                Label l = new Label();
                this.Controls.Add(l);
                switch(s.Key)
                {
                    case "AfisCuvCorect":
                        l.Text = "Afiseaza cand cuvantul este corect";
                        break;
                    case "DezTimp":
                        l.Text = "Dezactiveaza timpul";
                        break;
                }
                l.Location = new Point(30, 60 * i);
                l.Font = fnt;
                l.AutoSize = true;

                Button b = new Button();
                this.Controls.Add(b);
                b.Name = s.Key;
                b.Text = string.Empty;
                b.Size = new Size(30, l.Height);
                b.Location = new Point(l.Location.X + l.Width + 10, l.Location.Y + 4);
                b.BackColor = s.Value ? Color.Green : Color.Red;
                b.FlatStyle = FlatStyle.Flat;
                b.FlatAppearance.BorderSize = 0;
                b.Click += BtnSetareClick;
                setari.Add(b);

                i++;
            }

            Label lblTema = new Label();
            this.Controls.Add(lblTema);
            lblTema.AutoSize = true;
            lblTema.Location = new Point(30, 60 * i);
            lblTema.Text = "Schimba tema";
            lblTema.Font = fnt;
            i++;

            cmbTeme = new ComboBox();
            this.Controls.Add(cmbTeme);
            cmbTeme.Location = new Point(lblTema.Location.X + lblTema.Width + 10, lblTema.Location.Y);
            cmbTeme.Font = fnt;
            cmbTeme.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTeme.Width = lblTema.Width;
            foreach(Teme t in Enum.GetValues(typeof(Teme)))
            {
                cmbTeme.Items.Add(t);
            }
            cmbTeme.SelectedIndexChanged += cmbTeme_SelectedIndexChanged;
            cmbTeme.SelectedIndex = DBManager.GetIndexTemaSelectata();
        }

        private bool temaSchimbata = false;
        private void cmbTeme_SelectedIndexChanged(object sender, EventArgs e)
        {
            temaSchimbata = true;
            Important.temaAleasa = (Teme)cmbTeme.SelectedIndex;
            TemaManager.SeteazaTema((Teme)cmbTeme.SelectedIndex);
        }

        private bool dateSchimbate = false;
        private void IncarcaSetariUtilizator()
        {
            pnlUtilizator.Visible = true;
            txtNume.Text = Important.utilizatorCurent.NumeUtilizator;
            txtEmail.Text = Important.utilizatorCurent.Email;
            txtParola.Text = Utilizator.DecripteazaText(Important.utilizatorCurent.Parola);
            btnVisibility.BackgroundImage = Important.imgPassNotVisible;
            btnVisibility.Click += (se, ar) =>
            {
                txtParola.UseSystemPasswordChar = !txtParola.UseSystemPasswordChar;
                if (txtParola.UseSystemPasswordChar) btnVisibility.BackgroundImage = Important.imgPassNotVisible;
                else btnVisibility.BackgroundImage = Important.imgPassVisible;
            };
            btnVisibility.Enabled = true;
        }

        private bool setariJocSchimbate = false;
        private void BtnSetareClick(object sender, EventArgs args)
        {
            setariJocSchimbate = true;

            Button b = sender as Button;
            Important.utilizatorCurent.SetariJoc[b.Name] = !Important.utilizatorCurent.SetariJoc[b.Name];
            b.BackColor = Important.utilizatorCurent.SetariJoc[b.Name] ? Color.Green : Color.Red;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtEmail.Enabled = txtNume.Enabled = txtParola.Enabled = true;
        }

        private void txtNume_TextChanged(object sender, EventArgs e)
        {
            dateSchimbate = true;
        }
    }
}
