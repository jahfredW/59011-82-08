using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercices
{
    internal class Compte
    {
        private static int Code;
        public Compte(double solde)
        {
            Compte.Code++;
            Solde = solde;
        }

        public double Solde { get; set; }
       
    }
}
