using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voiture
{
    internal class Voiture
    {
        public Voiture(string marque, string modele, string motorisation, string couleur, int? nbKilometres = null)
        {
            Couleur = couleur;
            Marque = marque;
            Modele = modele;
            NbKilometres = Convert.ToInt32(nbKilometres);
            Motorisation = motorisation;
        }

        // Propriétés de la classe 
        public string Couleur { get; set; }
        public string Marque { get; set; }
        public string Modele { get; set; }
        public int NbKilometres { get; set; }
        public string Motorisation {  get; set; }

        // méthode toString 
        public override string ToString()
        {
            string description = "Cette Voiture est une " + Modele + " de la marque " + Marque;
            if (Couleur != null)
            {
                description += " de couleur " + Couleur;
            }
            if(Motorisation != null)
            {
                description += " ,de motorisation " + Motorisation;
            }
            if(NbKilometres != null)
            {
                description += ", avec " + NbKilometres + " kilomètres";
            }

            return description;
                 
        }

        public void Rouler(int nbKm)
        {
            NbKilometres += nbKm;
        }
        


    }
}
