using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;

namespace atestat3._0
{
    static class DBManager
    {
        private static string conexiune = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Resurse\DB.accdb";

        public static int GetLastUserId()
        {
            OleDbConnection con = new OleDbConnection(conexiune);
            con.Open();

            OleDbCommand com = new OleDbCommand();
            com.Connection = con;
            com.CommandText = "SELECT * FROM Utilizatori ORDER BY Id DESC";

            using (OleDbDataReader r = com.ExecuteReader())
            {
                if (r.Read())
                {
                    return Convert.ToInt32(r["Id"]);
                }
                else
                {
                    return 1;
                }
            }
        }

        public static bool CheckNameExists(string nume)
        {
            OleDbConnection con = new OleDbConnection(conexiune);
            con.Open();

            OleDbCommand com = new OleDbCommand();
            com.Connection = con;

            com.CommandText = "SELECT * FROM Utilizatori WHERE NumeUtilizator = @nume";
            com.Parameters.AddWithValue("nume", nume);
            using (OleDbDataReader r = com.ExecuteReader())
            {
                if (r.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static bool CheckEmailExists(string email)
        {
            OleDbConnection con = new OleDbConnection(conexiune);
            con.Open();

            OleDbCommand com = new OleDbCommand();
            com.Connection = con;

            com.CommandText = "SELECT * FROM Utilizatori WHERE Email = @email";
            com.Parameters.AddWithValue("email", email);
            using (OleDbDataReader r = com.ExecuteReader())
            {
                if (r.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static void AdaugaUtilizator(Utilizator util)
        {
            OleDbConnection con = new OleDbConnection(conexiune);
            con.Open();

            OleDbCommand com = new OleDbCommand();
            com.Connection = con;

            com.CommandText = $"INSERT INTO Utilizatori(NumeUtilizator, Email, Parola, TemaAleasa, Admin)" +
                              $"VALUES(@nume, @email, @parola, @tema, @admin)";
            com.Parameters.AddWithValue("@nume", util.NumeUtilizator);
            com.Parameters.AddWithValue("@email", util.Email);
            com.Parameters.AddWithValue("@parola", util.Parola);
            com.Parameters.AddWithValue("@tema", (int)util.TemaAleasa);
            com.Parameters.AddWithValue("@admin", false);

            com.ExecuteNonQuery();


            com.Parameters.Clear();
            com.CommandText = "INSERT INTO Setari(AfisCuvCorect, DezTimp) VALUES(@afc, @dz)";
            com.Parameters.AddWithValue("afc", true);
            com.Parameters.AddWithValue("dz", false);

            com.ExecuteNonQuery();
        }

        public static Utilizator CautaUtilizator(string email, string parola)
        {
            OleDbConnection con = new OleDbConnection(conexiune);
            con.Open();

            OleDbCommand com = new OleDbCommand();
            com.Connection = con;

            com.CommandText = "SELECT * FROM Utilizatori WHERE Email = @email AND Parola = @parola";
            com.Parameters.AddWithValue("email", email);
            com.Parameters.AddWithValue("parola", parola);

            using (OleDbDataReader r = com.ExecuteReader())
            {
                if (r.Read())
                {
                    Utilizator u = new Utilizator();
                    u.Id = Convert.ToInt32(r["ID"]);
                    u.NumeUtilizator = r["NumeUtilizator"].ToString();
                    u.Email = r["Email"].ToString();
                    u.Parola = r["Parola"].ToString();
                    u.TemaAleasa = (Teme)Convert.ToInt32(r["TemaAleasa"]);
                    u.TipUtilizator = Convert.ToBoolean(r["Admin"]) == true ? TipUtilizator.Admin : TipUtilizator.Utilizator;

                    return u;
                }
            }
            return null;
        }

        public static List<Utilizator> GetUtilizatori()
        {
            OleDbConnection con = new OleDbConnection(conexiune);
            con.Open();

            OleDbCommand com = new OleDbCommand();
            com.Connection = con;
            com.CommandText = "SELECT * FROM Utilizatori";

            List<Utilizator> utils = new List<Utilizator>();

            OleDbDataReader r = com.ExecuteReader();
            while (r.Read())
            {
                Utilizator u = new Utilizator(
                    Convert.ToInt32(r["ID"]),
                    r["NumeUtilizator"].ToString(),
                    r["Email"].ToString(),
                    string.Empty,
                    (Teme)Convert.ToInt32(r["TemaAleasa"]),
                    Convert.ToBoolean(r["Admin"]) ? TipUtilizator.Admin : TipUtilizator.Utilizator);
                utils.Add(u);
            }
            return utils;
        }

        public static void ModificaDate(this Utilizator u, string nume, string email, int tema, TipUtilizator tip)
        {
            OleDbConnection con = new OleDbConnection(conexiune);
            con.Open();

            OleDbCommand com = new OleDbCommand();
            com.Connection = con;
            com.CommandText = "UPDATE Utilizatori SET NumeUtilizator = @nume, Email = @email, TemaAleasa = @tema, Admin = @admin WHERE ID = @id";
            com.Parameters.AddWithValue("nume", nume);
            com.Parameters.AddWithValue("email", email);
            com.Parameters.AddWithValue("tema", tema);
            com.Parameters.AddWithValue("admin", tip == TipUtilizator.Admin);
            com.Parameters.AddWithValue("id", u.Id);

            com.ExecuteNonQuery();
        }

        public static void SalveazaSetariUtilizator(string numeNou, string emailNou, string parolaNoua)
        {
            OleDbConnection con = new OleDbConnection(conexiune);
            con.Open();

            OleDbCommand com = new OleDbCommand();
            com.Connection = con;
            com.CommandText = "UPDATE Utilizatori SET NumeUtilizator = @nume, Email = @email, Parola = @parola WHERE ID = @id";
            com.Parameters.AddWithValue("nume", numeNou);
            com.Parameters.AddWithValue("email", emailNou);
            com.Parameters.AddWithValue("parola", parolaNoua);
            com.Parameters.AddWithValue("id", Important.utilizatorCurent.Id);

            com.ExecuteNonQuery();

            Important.utilizatorCurent.NumeUtilizator = numeNou;
            Important.utilizatorCurent.Email = emailNou;
            Important.utilizatorCurent.Parola = parolaNoua;
            (Important.ferestreDeschise.Find(f => f.Name == "FrmJoc") as FrmJoc).SeteazaTitlu();
        }

        public static int GetIndexTemaSelectata()
        {
            OleDbConnection con = new OleDbConnection(conexiune);
            con.Open();

            OleDbCommand com = new OleDbCommand();
            com.Connection = con;
            com.CommandText = "SELECT TemaAleasa FROM Utilizatori WHERE ID = @id";
            com.Parameters.AddWithValue("id", Important.utilizatorCurent.Id);

            OleDbDataReader r = com.ExecuteReader();
            if (r.Read())
            {
                return Convert.ToInt32(r["TemaAleasa"]);
            }
            else
            {
                return -1;
            }
        }

        public static void SalveazaTemaUtilizator(int indexTema)
        {
            OleDbConnection con = new OleDbConnection(conexiune);
            con.Open();

            OleDbCommand com = new OleDbCommand();
            com.Connection = con;
            com.CommandText = "UPDATE Utilizatori SET TemaAleasa = @ta WHERE ID = @id";
            com.Parameters.AddWithValue("ta", indexTema);
            com.Parameters.AddWithValue("id", Important.utilizatorCurent.Id);

            com.ExecuteNonQuery();
        }

        public static void SalveazaSetariJoc(Dictionary<string, bool> setari)
        {
            OleDbConnection con = new OleDbConnection(conexiune);
            con.Open();

            OleDbCommand com = new OleDbCommand();
            com.Connection = con;
            com.CommandText = "UPDATE Setari SET AfisCuvCorect = @acc, DezTimp = @dt WHERE IdUtilizator = @id";

            com.Parameters.AddWithValue("acc", setari["AfisCuvCorect"]);
            com.Parameters.AddWithValue("dt", setari["DezTimp"]);
            com.Parameters.AddWithValue("id", Important.utilizatorCurent.Id);

            com.ExecuteNonQuery();

            Important.utilizatorCurent.SetariJoc = setari;
        }

        public static Dictionary<string, bool> GetSetariJoc(Utilizator u)
        {
            Dictionary<string, bool> dic = new Dictionary<string, bool>();

            OleDbConnection con = new OleDbConnection(conexiune);
            con.Open();

            OleDbCommand com = new OleDbCommand();
            com.Connection = con;
            com.CommandText = "SELECT * FROM Setari WHERE IdUtilizator = @id";
            com.Parameters.AddWithValue("id", u.Id);

            OleDbDataReader r = com.ExecuteReader();
            if (r.Read())
            {
                dic.Add("AfisCuvCorect", Convert.ToBoolean(r["AfisCuvCorect"]));
                dic.Add("DezTimp", Convert.ToBoolean(r["DezTimp"]));
            }
            r.Close();

            return dic;
        }

        public static List<Rebus> GetRebusuri()
        {
            OleDbConnection con = new OleDbConnection(conexiune);
            con.Open();

            OleDbCommand com = new OleDbCommand();
            com.Connection = con;

            List<Rebus> rebusuri = new List<Rebus>();
            com.CommandText = "SELECT * FROM Rebusuri";

            using (OleDbDataReader r = com.ExecuteReader())
            {
                while (r.Read())
                {
                    if (Convert.ToInt32(r["IdRebus"]) > 3) break; // restul rebusurilor nu sunt adaugate

                    rebusuri.Add(new Rebus(
                        Convert.ToInt32(r["IdRebus"]),
                        r["DenumireRebus"].ToString(),
                        Convert.ToInt32(r["NrLinii"]),
                        Convert.ToInt32(r["NrColoane"]),
                        Convert.ToInt32(r["TimpEstimat"]),
                        r["note"].ToString()
                        /*StatusRebus.Neinceput*/));
                }
            }
            return rebusuri;
        }

        public static List<Rezolvare> CautaRezolvari(int id)
        {
            OleDbConnection con = new OleDbConnection(conexiune);
            con.Open();

            OleDbCommand com = new OleDbCommand();
            com.Connection = con;

            List<Rezolvare> rez = new List<Rezolvare>();

            com.CommandText = "SELECT * FROM Rezolvari WHERE IdRebus = @id";
            com.Parameters.AddWithValue("id", id);

            using (OleDbDataReader r = com.ExecuteReader())
            {
                while (r.Read())
                {
                    rez.Add(new Rezolvare(
                        Convert.ToInt32(r["IdRebus"]),
                        Convert.ToInt32(r["LiniaStart"]),
                        Convert.ToInt32(r["ColoanaStart"]),
                        r["Orientare"].ToString() == "orizontal" ? OrientareRezolvare.Orizontal : OrientareRezolvare.Vertical,
                        r["Solutie"].ToString(),
                        r["TextDefinitie"].ToString()));
                }
            }
            return rez;
        }
    }
}
