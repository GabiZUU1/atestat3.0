using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace atestat3._0
{
    public class Tema
    {
        public Color culoareText { get; set; }
        public Color culoareButoane { get; set; }
        public Color culoareBackground { get; set; }
        public Color culoareTaskBar { get; set; }
        public Color culoareMargini { get; set; }

        public Tema(Color culoareText, Color culoareButoane, Color culoareBackground, Color culoareTaskBar, Color culoareMargini)
        {
            this.culoareText = culoareText;
            this.culoareButoane = culoareButoane;
            this.culoareBackground = culoareBackground;
            this.culoareTaskBar = culoareTaskBar;
            this.culoareMargini = culoareMargini;
        }
    }

    public static class TemaManager
    {
        public static Tema LightMode = new Tema
            (Color.Black, Color.LightGray, Color.Silver, Color.DarkGray, Color.Black);

        public static Tema DarkMode = new Tema
            (Color.White, Color.DarkGray, Color.Gray, Color.DimGray, Color.White);

        public static Tema Tema1 = new Tema
            (Color.FromArgb(205, 197, 180), Color.FromArgb(109, 61, 20),
             Color.FromArgb(85, 27, 20), Color.FromArgb(75, 17, 10), Color.AntiqueWhite);

        public static Tema Tema2 = new Tema
            (Color.FromArgb(225, 187, 128), Color.FromArgb(123, 107, 67),
             Color.FromArgb(53, 34, 8), Color.FromArgb(108, 80, 47), Color.White);

        public static Tema temaCurenta { get; set; }
        public static Teme temaEnumCurenta = Teme.LightMode;

        public static List<string> ignoraButoane = new List<string>() { "AfisCuvCorect", "DezTimp", "btnVisibility"};
        public static void SeteazaTema(Teme tema)
        {
            switch (tema)
            {
                case Teme.LightMode:
                    temaCurenta = LightMode;
                    break;

                case Teme.DarkMode:
                    temaCurenta = DarkMode;
                    break;

                case Teme.Tema1:
                    temaCurenta = Tema1;
                    break;

                case Teme.Tema2:
                    temaCurenta = Tema2;
                    break;

                default:
                    MessageBox.Show("Nu e implementat!");
                    break;
            }
            temaEnumCurenta = tema;
            AplicaTema();
        }

        private static void AplicaTema()
        {
            foreach (Form f in Important.ferestreDeschise)
            {
                f.ForeColor = temaCurenta.culoareText;
                f.BackColor = temaCurenta.culoareBackground;

                AplicaTemaControale(f.Controls);

                Control lblTitlu = f.Controls.Find("lblTitlu", false).FirstOrDefault();
                if (lblTitlu != null) lblTitlu.BackColor = temaCurenta.culoareTaskBar;

                foreach (Panel p in f.Controls.OfType<Panel>())
                {
                    if (p.Name == "pnlSus" || p.Name == "pnlJos" || p.Name == "pnlDreapta" || p.Name == "pnlStanga")
                        p.BackColor = temaCurenta.culoareMargini;
                }
            }
        }

        private static void AplicaTemaControale(Control.ControlCollection controale)
        {
            foreach (Control c in controale)
            {
                switch (c)
                {
                    case CustomMenu cm:
                        cm.BackColor = temaCurenta.culoareTaskBar;
                        AplicaTemaControale(cm.Controls);
                        break;
                        
                    case Button b:
                        if (ignoraButoane.Contains(b.Name)) break;
                        if (b.Name == "btnMinimise" || b.Name == "btnInchide") b.BackColor = temaCurenta.culoareTaskBar;
                        else b.BackColor = temaCurenta.culoareButoane;
                        break;

                    case GroupBox g:
                        g.ForeColor = temaCurenta.culoareText;
                        AplicaTemaControale(g.Controls);
                        break;

                    case Panel p:
                        AplicaTemaControale(p.Controls);
                        break;

                    case DataGridView dgv:
                        dgv.BackgroundColor = temaCurenta.culoareBackground;

                        dgv.DefaultCellStyle.BackColor = temaCurenta.culoareBackground;
                        dgv.DefaultCellStyle.ForeColor = temaCurenta.culoareText;
                        dgv.DefaultCellStyle.SelectionBackColor = temaCurenta.culoareText;
                        dgv.DefaultCellStyle.SelectionForeColor = temaCurenta.culoareBackground;
                        break;

                    default:
                        AplicaTemaControale(c.Controls);
                        break;
                }
            }
        }
    }

    public enum Teme
    {
        LightMode,
        DarkMode,
        Tema1,
        Tema2
    }
}
