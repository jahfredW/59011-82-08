using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employe
{
    // Valeurs par défauts, utiliser le polymorphisme 
    internal class Employe
    {
        public static List<Employe> employes = new List<Employe>();
        public Employe(string nom, string prenom, DateTime date, string fonction, double salaire, Entreprise entreprise)
        {
            Nom = nom;
            Prenom = prenom;
            Date = date;
            Fonction = fonction;
            Salaire = salaire;
            Entreprise = entreprise;
            employes.Add(this);
            
  
        }
        public Employe(string nom, string prenom, DateTime date, string fonction, double salaire, Entreprise entreprise,string service)
        {
            Nom = nom;
            Prenom = prenom;
            Date = date;
            Fonction = fonction;
            Salaire = salaire;
            Service = service;
            Entreprise = entreprise;
            employes.Add(this);
        }

        public string Nom { get; set; } = "testName";
        public string Prenom { get; set; } = "testPRenom";
        public DateTime Date { get; set; } = DateTime.MinValue;
        public string Fonction { get; set; } = "defaut fonction";
        public double Salaire { get; set; } = 1500;
        public string Service { get; set; } = "defaut Service";

        public Entreprise Entreprise { get; set; } = null;

        // Récupération 
        public double Seniority()
        {
            DateTime now = DateTime.Today;
            TimeSpan seniority;

            seniority = now.Subtract(Date);

            DateAndTime.DateDiff(DateInterval.Year, Date, DateTime.Now);

            return seniority.TotalDays;
        }
        private double getPrime()
        {
            double prime = Salaire * 0.05;
            return prime;
        }

        private double getSeniorityPrime()
        {
            double seniority;
            double prime;
            seniority = Seniority();

            prime = seniority * 0.02;

            return prime;

        }

        private double getTotalPrime()
        {
            return getPrime() + getSeniorityPrime();
        }

        public void primeVersement(DateTime date)
        {
            if(date.Month == 11 && date.Day == 30)
            {
                Console.WriteLine("Versement de : " + getTotalPrime() + " effectué");
            }
        }

        public override string ToString()
        {
            return "service : " + Service;
        }


    }
}
