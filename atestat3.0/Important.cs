using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace atestat3._0
{
    class Important
    {
        public static Utilizator utilizatorCurent;
        public static Rebus rebusSelectat = null;
        
        public static List<Form> ferestreDeschise = new List<Form>();
        public static List<Rebus> rebusuri = DBManager.GetRebusuri();
        public static Teme temaAleasa;

        public static Image imgSageataJos = Image.FromFile("Resurse/Imagini/SageataJos.png");
        public static Image imgPassVisible = Image.FromFile("Resurse/Imagini/Visible.png");
        public static Image imgPassNotVisible = Image.FromFile("Resurse/Imagini/NotVisible.png");
    }
}
