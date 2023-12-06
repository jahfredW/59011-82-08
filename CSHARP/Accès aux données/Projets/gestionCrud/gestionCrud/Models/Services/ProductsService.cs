using gestionCrud.Models.Datas;
using gestionCrud.Models;
using gestionCrud.Models.DTOs;
using System.IO;

namespace gestionCrud.Models.Services;

public class ProductsService
{
    const string PRODUCT_PATH = @"U:\59011-82-08\CSHARP\Accès aux données\Projets\gestionCrud\gestionCrud\datas.json";
    static public int NextId { get; set; }


    // permet de sauvegarder une liste de produit
    public static void SaveAllProducts(List<Product> productList)
    {

        if (productList == null)
        {
            throw new ArgumentNullException(nameof(productList));
        }

         json = Newtonsoft.Json.JsonConvert.SerializeObject(productList);

        // Convertir les Object en product 
        JsonContext.SaveData(json, PRODUCT_PATH);


    }

    // méthode de récupération de tous les produits 
    public static List<Product> GetAllProducts() 
    {
        // récuépration du contenu du fichier : 
        StructureJson js = JsonContext.ReadData(PRODUCT_PATH);
        // mapping 



    }

}


