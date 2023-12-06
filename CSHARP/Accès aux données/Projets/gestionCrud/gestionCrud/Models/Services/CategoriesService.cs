using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gestionCrud.Models.Datas;


namespace gestionCrud.Models.Services
{
    class CategoriesService
    {
            private JsonContext _context;

    public CategoriesService()
    {
        _context = new JsonContext();
    }

    // permet de sauvegarder une liste de produit
    public void SaveAllCategories(List<Category> categoryList)
    {
        
        if (categoryList == null)
        {
            throw new ArgumentNullException(nameof(categoryList));
        }

        _context.SaveDataCategory(categoryList);
      
    }   

   // permet de récupérer la liste de produits 
    public IEnumerable<Category> GetAllCategories()
    {
        return _context.GetAllCategories().ToList();
    }

    // récupération d'un produit via son id 
    public Category GetCategoryById(int id)
    {
        return _context.GetCategory(id);
    }
    
    // récupération d'une catégorie par son nom 
    public Category GetCategoryByName(string name)
    {
        return _context.GetCategoryByName(name);
    }

        // udpate d'un produit dans le JSon
        public void UpdateCategory(Category category)
    {
        _context.ReplaceCategory(category);
    }


    public void DeleteCategory(int id)
    {
        _context.DeleteCategory(id);
    }

    public void CreateCategory(Category category)
    {
        _context.CreateCategory(category);
    }

    public int getLastId()
    {
        return _context.GetLastId();
    }
    }
}
