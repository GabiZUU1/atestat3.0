using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
using static System.Windows.Forms.LinkLabel;

namespace atestat3._0
{
    public class GridJoc
    {
        public Rebus Rebus { get; set; }
        public Control _parent { get; set; }
        public Celula[,] Celule { get; set; }
        public int Linii { get; set; }
        public int Coloane { get; set; }


        public Celula celulaSelectata { get; set; }
        public TipCelula tipCelulaSelectata { get; set; }
        public (int, int) celulaSelectataPoz { get; set; }

        public List<Celula> celuleSelectate { get; set; } = new List<Celula>();
        public List<TipCelula> tipCeluleSelectate { get; set; } = new List<TipCelula>();


        public TextBox tb;
        public bool tbActiv { get; set; } = false;


        private List<string> listaCuvinteCompletate;
        private List<(int, int, int)> cuvinteCompletateLinie;
        private List<(int, int, int)> cuvinteCompletateColoana;
        public int Scor { get; set; }

        public GridJoc(Control parent, Rebus rebus)
        {
            _parent = parent;
            Linii = rebus.NrLinii;
            Coloane = rebus.NrColoane;
            Rebus = rebus;

            Scor = 0;

            InitializeComponent();
        }

        private void InitializeComponent()
        {
            if (Rebus == null) return;

            this._parent.Enabled = true;
            this._parent.Controls.Clear();

            Linii = Rebus.NrLinii;
            Coloane = Rebus.NrColoane;

            Random r = new Random();
            Celule = new Celula[Linii, Coloane];

            listaCuvinteCompletate = new List<string>();
            cuvinteCompletateLinie = new List<(int, int, int)>();
            cuvinteCompletateColoana = new List<(int, int, int)>();

            for (int i = 0; i < Linii; i++)
            {
                for (int j = 0; j < Coloane; j++)
                {
                    int g = r.Next(0, 3);

                    Celule[i, j] = new Celula();
                    Celula c = Celule[i, j];
                    _parent.Controls.Add(c);
                    c.Size = new Size(_parent.Width / Coloane, _parent.Height / Linii);
                    c.Location = new Point(j * c.Width, i * c.Height);
                    c.TextAlign = ContentAlignment.MiddleCenter;
                    c.Font = new Font("Microsoft Sans Serif", 21f);
                    c.ForeColor = Color.Black;
                    c.MouseClick += (se, ar) =>
                    {
                        var poz = this.GasestePozitieCelula(se as Celula);
                        this.SelecteazaCelula(poz.Item1, poz.Item2);
                        this.IncarcaTextBox();
                    };
                }
            }

            tb = new TextBox();
            _parent.Controls.Add(tb);
            tb.Size = Celule[0, 0].Size;
            tb.Visible = false;
            tb.MaxLength = 1;
            tb.Font = new Font("Microsoft Sans Serif", 20f);
            tb.TextAlign = HorizontalAlignment.Center;
            tb.AutoSize = false;

            tb.KeyPress += TextBoxKeyPress;

            tb.BringToFront();

            IncarcaRebus(Rebus);
        }

        private void IncarcaRebus(Rebus r)
        {
            Random rand = new Random();
            foreach (Rezolvare rez in r.Rezolvari.FindAll(rz => rz.Orientare == OrientareRezolvare.Vertical))
            {
                int lin = rez.LiniaStart - 1, col = rez.ColoanaStart - 1;
                string cuv = rez.Solutie;

                foreach (char ch in cuv)
                {
                    int nr = rand.Next(0, 10);

                    Celula c = Celule[lin, col];
                    if (c.TipCelula == TipCelula.Goala)
                    {
                        c.TipCelula = nr == 0 ? TipCelula.PuncteDuble : TipCelula.Simpla;
                        c.Tag = ch.ToString().ToUpper();
                    }

                    lin++;
                }
            }

            foreach (Rezolvare rez in r.Rezolvari.FindAll(rz => rz.Orientare == OrientareRezolvare.Orizontal))
            {
                int lin = rez.LiniaStart - 1, col = rez.ColoanaStart - 1;
                string cuv = rez.Solutie;

                foreach (char ch in cuv)
                {
                    int nr = rand.Next(0, 10);

                    Celula c = Celule[lin, col];
                    if (c.TipCelula == TipCelula.Goala)
                    {
                        c.TipCelula = nr == 0 ? TipCelula.PuncteDuble : TipCelula.Simpla;
                        c.Tag = ch.ToString().ToUpper();
                    }

                    col++;
                }
            }

            SelecteazaCelula(0, 0);
        }

        public (int, int) GasestePozitieCelula(Celula c)
        {
            for (int i = 0; i < Rebus.NrLinii; i++)
            {
                for (int j = 0; j < Rebus.NrColoane; j++)
                {
                    if (Celule[i, j] == c)
                    {
                        return (i, j);
                    }
                }
            }
            return (-1, -1);
        }

        public void MutaCelula(Celula c)
        {
            var pozCel = GasestePozitieCelula(c);
            MutaCelula(pozCel.Item1, pozCel.Item2);
        }

        public void MutaCelula(int linie, int coloana)
        {
            if (linie >= Rebus.NrLinii)
            {
                linie = 0;
            }
            else if (linie < 0)
            {
                linie = Rebus.NrLinii - 1;
            }

            if (coloana >= Rebus.NrColoane)
            {
                coloana = 0;
            }
            else if (coloana < 0)
            {
                coloana = Rebus.NrColoane - 1;
            }

            SelecteazaCelula(linie, coloana);
        }

        private void SelecteazaCelula(int linie, int coloana, bool selecteazaDinCuvant = false)
        {
            if (celulaSelectata != null)
            {
                celulaSelectata.TipCelula = tipCelulaSelectata;
            }

            if (celuleSelectate.Count != 0 && !selecteazaDinCuvant)
            {
                for (int j = 0; j < celuleSelectate.Count; j++)
                {
                    celuleSelectate[j].TipCelula = tipCeluleSelectate[j];
                }
                celuleSelectate = new List<Celula>();
                tipCeluleSelectate = new List<TipCelula>();
            }

            celulaSelectataPoz = (linie, coloana);
            celulaSelectata = Celule[linie, coloana];

            tipCelulaSelectata = celulaSelectata.TipCelula;
            celulaSelectata.TipCelula = TipCelula.Selectata;
        }

        public void SelecteazaMaiMulteCelule(Rezolvare rez)
        {
            switch (rez.Orientare)
            {
                case OrientareRezolvare.Orizontal:
                    SelecteazaMaiMulteCelule(rez.LiniaStart - 1, rez.ColoanaStart - 1, rez.Solutie.Length - 1, rez.Orientare);
                    break;

                case OrientareRezolvare.Vertical:
                    SelecteazaMaiMulteCelule(rez.LiniaStart - 1, rez.ColoanaStart - 1, rez.Solutie.Length - 1, rez.Orientare);
                    break;
            }
        }

        public void SelecteazaMaiMulteCelule(int liniaStart, int coloanaStart, int lungime, OrientareRezolvare orientare)
        {
            if (celulaSelectata != null)
            {
                celulaSelectata.TipCelula = tipCelulaSelectata;
            }

            if (celuleSelectate.Count != 0)
            {
                for (int j = 0; j < celuleSelectate.Count; j++)
                {
                    celuleSelectate[j].TipCelula = tipCeluleSelectate[j];
                }
                celuleSelectate = new List<Celula>();
                tipCeluleSelectate = new List<TipCelula>();
            }

            int i = 0;
            switch (orientare)
            {
                case OrientareRezolvare.Orizontal:
                    i = 0;
                    while (i <= lungime)
                    {
                        celuleSelectate.Add(Celule[liniaStart, i + coloanaStart]);
                        tipCeluleSelectate.Add(Celule[liniaStart, i + coloanaStart].TipCelula);
                        Celule[liniaStart, i + coloanaStart].TipCelula = TipCelula.Selectata;
                        i++;
                    }
                    break;

                case OrientareRezolvare.Vertical:
                    i = 0;
                    while (i <= lungime)
                    {
                        celuleSelectate.Add(Celule[i + liniaStart, coloanaStart]);
                        tipCeluleSelectate.Add(Celule[i + liniaStart, coloanaStart].TipCelula);
                        Celule[i + liniaStart, coloanaStart].TipCelula = TipCelula.Selectata;
                        i++;
                    }
                    break;
            }

            if (celuleSelectate.Contains(celulaSelectata))
            {
                tipCeluleSelectate[celuleSelectate.IndexOf(celulaSelectata)] = tipCelulaSelectata;
            }

            for (int ind = 0; ind < celuleSelectate.Count; ind++)
            {
                celulaSelectata = celuleSelectate[ind];
                celulaSelectataPoz = GasestePozitieCelula(celulaSelectata);
                tipCelulaSelectata = tipCeluleSelectate[ind];

                if (!celulaSelectata.CorectaLinie && !celulaSelectata.CorectaColoana)
                {
                    break;
                }
            }
        }

        public void IncarcaTextBox()
        {
            if (tipCelulaSelectata == TipCelula.Goala) return;

            //(_parent.Parent.Parent as FrmJoc).btnRebus.Text = celulaSelectata.Tag.ToString();

            if (Important.utilizatorCurent.SetariJoc["AfisCuvCorect"])
            {
                if (celulaSelectata.CorectaLinie || celulaSelectata.CorectaColoana)
                {
                    return;
                }
            }

            tbActiv = true;
            tb.Location = celulaSelectata.Location;
            tb.Visible = true;
            tb.Focus();
        }

        private void TextBoxKeyPress(object sender, KeyPressEventArgs args)
        {
            if (args.KeyChar == (char)Keys.Enter && tbActiv)
            {
                if (tb.Text != string.Empty && char.IsLetterOrDigit(tb.Text[0]))
                {
                    tbActiv = false;
                    celulaSelectata.Text = tb.Text.ToUpper();
                    tb.Text = string.Empty;
                    tb.Visible = false;
                    VerificaCuvinte(); //pe linie si pe coloana
                    //(_parent.Parent.Parent as FrmJoc).btnRebus.Text = this.Scor.ToString();

                    args.Handled = true; // sa nu mai scoata sunete
                }
            }
        }

        private void VerificaCuvinte() //pe linie si pe coloana
        {
            int cuvLinie = celulaSelectataPoz.Item1;
            int cuvColoana = celulaSelectataPoz.Item2;

            int startCuvant = -1, finalCuvant = -1;
            int aux = cuvColoana;
            while (aux >= 0)
            {
                Celula cel = Celule[cuvLinie, aux];
                if (cel.TipCelula == TipCelula.Goala)
                {
                    startCuvant = aux + 1;
                    break;
                }
                else
                {
                    aux--;
                }
                startCuvant = 0;
            }

            aux = cuvColoana;
            while (aux <= Rebus.NrColoane - 1)
            {
                Celula cel = Celule[cuvLinie, aux];
                if (cel.TipCelula == TipCelula.Goala)
                {
                    finalCuvant = aux - 1;
                    break;
                }
                else
                {
                    aux++;
                }
                finalCuvant = Rebus.NrColoane - 1;
            }
            (int, int) cuvantGasitLinie = (startCuvant, finalCuvant);


            startCuvant = finalCuvant = -1;
            aux = cuvLinie;
            while (aux >= 0)
            {
                Celula cel = Celule[aux, cuvColoana];
                if (cel.TipCelula == TipCelula.Goala)
                {
                    startCuvant = aux + 1;
                    break;
                }
                else
                {
                    aux--;
                }
                startCuvant = 0;
            }

            aux = cuvLinie;
            while (aux <= Rebus.NrLinii - 1)
            {
                Celula cel = Celule[aux, cuvColoana];
                if (cel.TipCelula == TipCelula.Goala)
                {
                    finalCuvant = aux - 1;
                    break;
                }
                else
                {
                    aux++;
                }
                finalCuvant = Rebus.NrLinii - 1;
            }
            (int, int) cuvantGasitColoana = (startCuvant, finalCuvant);



            bool ex = Rebus.Rezolvari.Any(rez => rez.Orientare == OrientareRezolvare.Orizontal && rez.LiniaStart == cuvLinie + 1 && rez.ColoanaStart == cuvantGasitLinie.Item1 + 1);
            if (!ex) return;
            string cuvant = Rebus.Rezolvari.FirstOrDefault(rez => rez.Orientare == OrientareRezolvare.Orizontal && rez.LiniaStart == cuvLinie + 1 && rez.ColoanaStart == cuvantGasitLinie.Item1 + 1).Solutie.ToUpper();

            bool cuvantLinieOK = true;
            if (cuvantGasitLinie.Item2 != cuvantGasitLinie.Item1)
            {
                for (int i = cuvantGasitLinie.Item1; i <= cuvantGasitLinie.Item2; i++)
                {
                    if (Celule[cuvLinie, i].Tag.ToString() != Celule[cuvLinie, i].Text && cuvantLinieOK)
                    {
                        cuvantLinieOK = false;
                        break;
                    }
                }
                if (cuvantLinieOK)
                {
                    for (int i = cuvantGasitLinie.Item1; i <= cuvantGasitLinie.Item2; i++)
                    {
                        Celula cel = Celule[cuvLinie, i];
                        cel.CorectaLinie = true;
                        if (Important.utilizatorCurent.SetariJoc["AfisCuvCorect"])
                        {
                            cel.BackColor = Color.Green;
                        }
                    }

                    if (cuvant != string.Empty)
                    {
                        listaCuvinteCompletate.Add(cuvant);
                        cuvinteCompletateLinie.Add((cuvantGasitLinie.Item1, cuvantGasitLinie.Item2, cuvLinie));
                        this.Scor++;
                    }
                }
                else
                {
                    if (listaCuvinteCompletate.Contains(cuvant))
                    {
                        for (int i = cuvantGasitLinie.Item1; i <= cuvantGasitLinie.Item2; i++)
                        {
                            Celule[cuvLinie, i].CorectaLinie = false;
                        }

                        listaCuvinteCompletate.Remove(cuvant);
                        cuvinteCompletateLinie.Remove((cuvantGasitLinie.Item1, cuvantGasitLinie.Item2, cuvLinie));
                        this.Scor--;
                    }
                }
                VerificaScor();
            }

            ex = Rebus.Rezolvari.Any(rez => rez.Orientare == OrientareRezolvare.Vertical && rez.LiniaStart == cuvantGasitColoana.Item1 + 1 && rez.ColoanaStart == cuvColoana + 1);
            if (!ex) return;
            cuvant = Rebus.Rezolvari.FirstOrDefault(rez => rez.Orientare == OrientareRezolvare.Vertical && rez.LiniaStart == cuvantGasitColoana.Item1 + 1 && rez.ColoanaStart == cuvColoana + 1).Solutie.ToUpper();

            bool cuvantColoanaOK = true;
            if (cuvantGasitColoana.Item2 != cuvantGasitColoana.Item1)
            {
                for (int i = cuvantGasitColoana.Item1; i <= cuvantGasitColoana.Item2; i++)
                {
                    if (Celule[i, cuvColoana].Tag.ToString() != Celule[i, cuvColoana].Text && cuvantColoanaOK)
                    {
                        cuvantColoanaOK = false;
                        break;
                    }
                }
                if (cuvantColoanaOK)
                {
                    for (int i = cuvantGasitColoana.Item1; i <= cuvantGasitColoana.Item2; i++)
                    {
                        Celula cel = Celule[i, cuvColoana];
                        cel.CorectaColoana = true;
                        if (Important.utilizatorCurent.SetariJoc["AfisCuvCorect"])
                        {
                            cel.BackColor = Color.Green;
                        }
                    }

                    if (cuvant != string.Empty)
                    {
                        listaCuvinteCompletate.Add(cuvant);
                        cuvinteCompletateColoana.Add((cuvantGasitColoana.Item1, cuvantGasitColoana.Item2, cuvColoana));
                        this.Scor++;
                    }
                }
                else
                {
                    if (listaCuvinteCompletate.Contains(cuvant))
                    {
                        for (int i = cuvantGasitColoana.Item1; i <= cuvantGasitColoana.Item2; i++)
                        {
                            Celule[i, cuvColoana].CorectaColoana = false;
                        }

                        listaCuvinteCompletate.Remove(cuvant);
                        cuvinteCompletateColoana.Remove((cuvantGasitColoana.Item1, cuvantGasitColoana.Item2, cuvColoana));
                        this.Scor--;
                    }
                }
                VerificaScor();
            }
        }

        private void VerificaScor()
        {
            if (this.Scor == this.Rebus.Rezolvari.Count)
            {
                (Important.ferestreDeschise.Find(f => f.Name == "FrmJoc") as FrmJoc).StopTimer();
                this._parent.Enabled = false;

                new CustomMessageBox().ShowDialog("Felicitari, ai completat rebusul!", ButoaneCustomMessageBox.Ok);
                new CustomMessageBox().ShowDialog("Apasa pe butonul \"Rebus\" pentru a incepe un rebus nou!", ButoaneCustomMessageBox.Ok);
            }
        }

        public void AplicaSetari()
        {
            if (Rebus == null) return;

            switch (Important.utilizatorCurent.SetariJoc["AfisCuvCorect"])
            {
                case true:
                    foreach (var cuvLin in cuvinteCompletateLinie)
                    {
                        for (int i = cuvLin.Item1; i <= cuvLin.Item2; i++)
                        {
                            Celule[cuvLin.Item3, i].BackColor = Color.Green;
                        }
                    }
                    foreach (var cuvCol in cuvinteCompletateColoana)
                    {
                        for (int i = cuvCol.Item1; i <= cuvCol.Item2; i++)
                        {
                            Celule[i, cuvCol.Item3].BackColor = Color.Green;
                        }
                    }
                    break;

                case false:
                    foreach (var cuvLin in cuvinteCompletateLinie)
                    {
                        for (int i = cuvLin.Item1; i <= cuvLin.Item2; i++)
                        {
                            Celule[cuvLin.Item3, i].TipCelula = Celule[cuvLin.Item3, i].TipCelula;
                        }
                    }
                    foreach (var cuvCol in cuvinteCompletateColoana)
                    {
                        for (int i = cuvCol.Item1; i <= cuvCol.Item2; i++)
                        {
                            Celule[i, cuvCol.Item3].TipCelula = Celule[i, cuvCol.Item3].TipCelula;
                        }
                    }
                    break;
            }
        }
    }
}
