using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heritage
{
    public class Commerciaux : Employe
    {
        public Commerciaux(int age, string nom, string prenom, double salaire, int nbDeplacement, int nbPrime)
            : base(age, nom, prenom, salaire)
        {

            NbDeplacement = nbDeplacement;
            NbPrime = nbPrime;


        }

        protected int NbDeplacement { get; set; }
        protected int NbPrime { get; set; }

        public override void CalculSalaire()
        {

        }

        public override string ToString()
        {
            return "Je suis un vendeur";
        }

        public override void Afficher()
        {
            Console.WriteLine(this.ToString());
        }
    }


}
        
}
