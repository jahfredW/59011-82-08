using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace account
{
    public class Client
    {
        public Client(string cin, string nom, string prenom, string tel)
        {
            Cin = cin;
            Nom = nom;
            Prenom = prenom;
            Tel = tel;
        }

        public Client(string cin, string nom, string prenom)
        {
            Cin = cin;
            Nom = nom;
            Prenom = prenom;
        }

        public string Cin { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Tel { get; set; }

        public override string ToString()
        {
            return "CIN : " + Cin + ", Nom : " + Nom + ", Prenom : " + Prenom + ", tel : " + Tel;
        }


    }
}
