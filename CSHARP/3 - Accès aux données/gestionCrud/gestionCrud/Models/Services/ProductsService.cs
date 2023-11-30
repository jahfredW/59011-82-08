using gestionCrud.Models.Datas;
using gestionCrud.Models;

namespace gestionCrud.Models.Services;

public class ProductsService
{
    private JsonContext _context;

    public ProductsService()
    {
        _context = new JsonContext();
    }

    // permet de sauvegarder une liste de produit
    public void SaveAllProducts(List<Product> productList)
    {
        
        if (productList == null)
        {
            throw new ArgumentNullException(nameof(productList));
        }

        _context.SaveData(productList);
      
    }   

   // permet de récupérer la liste de produits 
    public IEnumerable<Product> GetAllProducts()
    {
        return _context.GetAll().ToList();
    }


}


