using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;

namespace atestat3._0
{
    public class Utilizator
    {
        private int _Id = -1;
        public int Id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
                SetariJoc = DBManager.GetSetariJoc(this);
            }
        }
        public string NumeUtilizator { get; set; }
        public string Email { get; set; }
        public string Parola { get; set; }
        public Teme TemaAleasa { get; set; }
        public TipUtilizator TipUtilizator { get; set; }
        public Dictionary<string, bool> SetariJoc { get; set; }

        public Utilizator()
        {
            NumeUtilizator = Email = Parola = string.Empty;
            TipUtilizator = TipUtilizator.Utilizator;
            SetariJoc = new Dictionary<string, bool>();
        }

        public Utilizator(int id, string nume, string email, string parola, Teme tema, TipUtilizator tip)
        {
            Id = id;
            NumeUtilizator = nume;
            Email = email;
            Parola = parola;
            TemaAleasa = tema;
            TipUtilizator = tip;
        }

        public void Clear()
        {
            Id = -1;
            NumeUtilizator = Email = Parola = string.Empty;
            TipUtilizator = TipUtilizator.Utilizator;
            SetariJoc = new Dictionary<string, bool>();
        }

        public static bool EmailCorect(string email)
        {
            Regex rEmail = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
            if (!rEmail.IsMatch(email))
            {
                return false;
            }
            return true;
        }

        public static string EncripteazaText(string text)
        {
            byte[] textBytes = Encoding.UTF8.GetBytes(text);
            return Convert.ToBase64String(textBytes);
        }

        public static string DecripteazaText(string text)
        {
            byte[] textBytes = Convert.FromBase64String(text);
            return Encoding.UTF8.GetString(textBytes);
        }
    }

    public enum TipUtilizator
    {
        Admin,
        Utilizator
    }
}
