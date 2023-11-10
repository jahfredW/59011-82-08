using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voiture
{
    public abstract class Vehicule
    {
        public Vehicule(string modele, string marque, string couleur, int kilometrage, DateTime revision_date)
        {
            Modele = modele;
            Marque = marque;
            Couleur = couleur;
            Kilometrage = kilometrage;
            Revision_date = revision_date;
        }

        public string Modele { get; set; }
        public string Marque { get; set; }
        public string Couleur { get; set; }
        public int Kilometrage { get; set; }
        public DateTime Revision_date {  get; set; }
        
        public abstract void Rouler();
        public abstract override string ToString();
        public abstract void Revision();

    }
}
