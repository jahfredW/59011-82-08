using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercices
{
    public class Compte
    {
        private static int Code;
        public Compte(double solde, Client client)
        {
            Compte.Code++;
            Solde = solde;
            Client = client;
            Afficher();
        }

        public double Solde { get; set; }
        public Client Client { get; set; } // lecture seule private ou on enlève le setter 
        
        public void Crediter (double somme)
        {
            Solde += somme;
        }

        public void Crediter(double somme, Compte compte)
        {
            Solde += somme;
            compte.Debiter(somme);
        }

        public void Debiter(double somme)
        {
            Solde -= somme;
        }

        public void Debiter(double somme, Compte compte)
        {
            Solde -= somme;
            compte.Crediter(somme);
        }






        public void Afficher()
        {
            Console.WriteLine("Cin du client : " + Client.Cin + "Nom du client : " + Client.Nom + "compte : " + Code);
        }
    }
}
