using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace atestat3._0
{
    public class Rezolvare
    {
        public int IdRebus { get; set; }
        public int LiniaStart { get; set; }
        public int ColoanaStart { get; set; }
        public OrientareRezolvare Orientare { get; set; }
        public string Solutie { get; set; }
        public string Definitie { get; set; }

        public Rezolvare()
        {
            IdRebus = LiniaStart = ColoanaStart = -1;
            Solutie = Definitie = string.Empty;
            Orientare = OrientareRezolvare.Orizontal;
        }

        public Rezolvare(int idRebus, int liniaStart, int coloanaStart, OrientareRezolvare orientare, string solutie, string definitie)
        {
            IdRebus = idRebus;
            LiniaStart = liniaStart;
            ColoanaStart = coloanaStart;
            Orientare = orientare;
            Solutie = solutie;
            Definitie = definitie;
        }
    }

    public enum OrientareRezolvare
    {
        Orizontal,
        Vertical
    }

    public class RezolvariManager
    {
        public DataGridView Location { get; set; }
        public List<Rezolvare> Rezolvari { get; set; } = new List<Rezolvare>();

        public RezolvariManager(DataGridView location, List<Rezolvare> rezolvari)
        {
            Location = location;
            this.Rezolvari = rezolvari;
        }

        public void IncarcaRezolvari(OrientareRezolvare orientare = OrientareRezolvare.Orizontal)
        {
            Location.Rows.Clear();

            var lista = Important.rebusSelectat.Rezolvari.FindAll(rez => rez.Orientare == orientare);
            foreach (Rezolvare r in lista)
            {
                if (orientare == OrientareRezolvare.Orizontal) Location.Rows.Add("Linia: " + r.LiniaStart, r.Definitie);
                else Location.Rows.Add("Coloana: " + r.ColoanaStart, r.Definitie);
            }
        }

        public Rezolvare GasesteRezolvare(DataGridViewRow dgr)
        {
            return Rezolvari.Find(rez => rez.Definitie == dgr.Cells[1].Value.ToString());
        }
    }
}
