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
        const string CATEGORIES_PATH = @"U:\59011-82-08\CSHARP\Accès aux données\Projets\gestionCrud\gestionCrud\categories.json";
       

   

    // permet de sauvegarder une liste de produit
    public void SaveAllCategories(List<Category> categoryList)
    {
        
        if (categoryList == null)
        {
            throw new ArgumentNullException(nameof(categoryList));
        }

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(categoryList);

        JsonContext.SaveData(json, CATEGORIES_PATH);
      
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
