using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestionCrudBonnesPratiques.Datas
{
    public class JsonStructure
    {
        // ici ne pas mettre en statique, car lors de la désérialisation, on récupère l'instance d'un objet. 
        public int NextId { get; set; }
        public List<Object> ItemsListe { get; set; }
    }
}
