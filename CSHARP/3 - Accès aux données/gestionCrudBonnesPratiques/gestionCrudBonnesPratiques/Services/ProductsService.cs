using gestionCrudBonnesPratiques.Datas;
using gestionCrudBonnesPratiques.Profiles;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace gestionCrudBonnesPratiques.Services
{
    public class ProductsService
    {
        const string PRODUCT_PATH = @"U:\59011-82-08\CSHARP\3 - Accès aux données\gestionCrudBonnesPratiques\gestionCrudBonnesPratiques\productsData.json";

        public static List<Product> getAllProducts()
        {
           JsonStructure js  = Context.ReadJson(PRODUCT_PATH);
            // le js est un objet qui contient une propiété nextID et une propriété Liste
            // en désérailisant, on a mis nextID dans nextID, et le reste dans liste.
            // attention, il faut que les noms correspondent ! 
            // on va donc passer la liste dans le profiler pour récuépérer une liste de Products : 

            List<Product> productsListe = ProductsProfile.FromJsToProduct(js.ItemsListe);

            return productsListe;
        }


    }
}
