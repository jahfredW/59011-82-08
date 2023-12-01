using gestionCrud.Models.Datas;
using gestionCrud.Models;
using gestionCrud.Models.DTOs;

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

    // récupération d'un produit via son id 
    public Product GetProductById(int id)
    {
        return _context.Get(id);
    }

    // udpate d'un produit dans le JSon
    public void UpdateProduct(Product product)
    {
        _context.Replace(product);
    }

}


