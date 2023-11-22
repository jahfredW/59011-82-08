using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heritage
{
    public abstract class Employe
    {
        public Employe(int age, string nom, string prenom, double salaire)
        {
            Age = age;
            Nom = nom;
            Prenom = prenom;
            Salaire = salaire;
        }

        protected int Age {  get; set; }
        protected string Nom {  get; set; }
        protected string Prenom { get; set; }
        protected double Salaire { get; set; }

        public abstract override string ToString();

        public abstract void Afficher();
        
        public abstract void CalculSalaire();
       


    }
}
