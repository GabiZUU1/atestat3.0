using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace atestat3._0
{
    public class Rebus
    {
        public int Id { get; set; }
        public string Denumire { get; set; }
        public int NrLinii { get; set; }
        public int NrColoane { get; set; }
        public int TimpEstimat { get; set; }
        public string Note { get; set; }
        //public StatusRebus StatusRebus { get; set; }
        public List<Rezolvare> Rezolvari { get; set; }

        public Rebus()
        {
            Id = NrLinii = NrColoane = TimpEstimat = -1;
            Denumire = Note = string.Empty;
            //StatusRebus = StatusRebus.Neinceput;

            InitializeComponent();
        }

        public Rebus(int id, string denumire, int nrLinii, int nrColoane, int timpEstimat, string note/*, StatusRebus statusRebus*/)
        {
            Id = id;
            Denumire = denumire;
            NrLinii = nrLinii;
            NrColoane = nrColoane;
            TimpEstimat = timpEstimat;
            Note = note;
            //StatusRebus = statusRebus;

            InitializeComponent();
        }

        private void InitializeComponent()
        {
            Rezolvari = DBManager.CautaRezolvari(Id);
            if(Rezolvari.Count == 0)
            {
                new CustomMessageBox(TipuriCustomMessageBox.Eroare).ShowDialog("Eroare la incarcarea rezolvarilor!", ButoaneCustomMessageBox.Ok);
                return;
            }
        }
    }

    //public enum StatusRebus
    //{
    //    Neinceput,
    //    Inceput,
    //    Completat
    //}

    public class Celula : Label
    {
        public bool CorectaLinie { get; set; } = false;
        public bool CorectaColoana { get; set; } = false;

        private TipCelula _tipCelula = TipCelula.Goala;
        public TipCelula TipCelula
        {
            get
            {
                return _tipCelula;
            }
            set
            {
                SchimbaTip(value);
            }
        }

        public Celula()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            SchimbaTip(_tipCelula);

            this.Font = new Font("Microsoft Sans Serif", 12f);
            this.BorderStyle = BorderStyle.FixedSingle;
        }

        private void SchimbaTip(TipCelula tip)
        {
            this._tipCelula = tip;

            switch (TipCelula)
            {
                case TipCelula.Goala:
                    this.BackColor = Color.Black;
                    break;

                case TipCelula.Simpla:
                    if (Important.utilizatorCurent.SetariJoc["AfisCuvCorect"])
                    {
                        if (CorectaLinie || CorectaColoana)
                        {
                            this.BackColor = Color.Green;
                            break;
                        }
                    }
                    this.BackColor = Color.WhiteSmoke;
                    break;

                case TipCelula.PuncteDuble:
                    if (Important.utilizatorCurent.SetariJoc["AfisCuvCorect"])
                    {
                        if (CorectaLinie || CorectaColoana)
                        {
                            this.BackColor = Color.Green;
                            break;
                        }
                    }
                    this.BackColor = Color.FromArgb(200, 255, 200);
                    break;

                case TipCelula.Selectata:
                    this.BackColor = Color.Gray;
                    break;

                default:
                    MessageBox.Show("Nu exista!");
                    break;
            }
        }
    }

    public enum TipCelula
    {
        Goala,
        Simpla,
        PuncteDuble,
        Selectata
    }
}
