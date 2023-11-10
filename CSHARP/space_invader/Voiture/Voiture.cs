using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voiture
{
    internal class Voiture : Vehicule
    {
        public Voiture(string modele, string marque, string couleur, int kilometrage, DateTime revision_date, string[] roues_motrices)
            : base(modele, marque, couleur, kilometrage, revision_date)
        {
            Roues_motrices = roues_motrices;
        }

        public string[] Roues_motrices { get; set; } = { "4x4", "traction", "propulsion" };

        public override void Revision()
        {
            throw new NotImplementedException();
        }

        public override void Rouler()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
