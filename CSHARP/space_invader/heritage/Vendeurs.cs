using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heritage
{
    public class Vendeurs : Commerciaux
    {
        public const int NB_IRIS_PAR_PRIME = 0;
        public const int SALAIRE_DE_BASE = 0;

        public Vendeurs(int age, string nom, string prenom, double salaire, int nbDeplacement, int nbPrime)
            : base(age, nom, prenom, salaire, nbDeplacement, nbPrime)
        {

        }

        public override void CalculSalaire()
        {

        }

        public override string ToString()
        {
            return "Je suis un vendeur";
        }


        
    }
}
