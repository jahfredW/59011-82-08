using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employe
{
    internal class Entreprise
    {
        public Entreprise(List<Employe> employes)
        {
            Employes = employes;
        }

        public List<Employe> Employes { get; set; }
        public string Nom {  get; set; }
        public string Adresse { get; set; }
        public string Postal { get; set; }

    }
}
