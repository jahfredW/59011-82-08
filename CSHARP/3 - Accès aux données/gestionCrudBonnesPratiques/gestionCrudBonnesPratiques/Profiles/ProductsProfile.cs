using gestionCrudBonnesPratiques.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestionCrudBonnesPratiques.Profiles
{
    public static class ProductsProfile
    {
        // la méthode prend donc la liste d'objets en param
        public static List<Product>? FromJsToProduct(List<Object> ItemsListe)
        {
            // étape 1 : on va sérialiser la liste d'objets : 
            string ItemsListeString = Newtonsoft.Json.JsonConvert.SerializeObject(ItemsListe);

            // Puis la désérialiser en ce que l'on veut : 
            List<Product>? productsListe = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Product>>(ItemsListeString);

            return productsListe != null ? productsListe : null;
            
        }

    }
}
