using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using gestionCrud.Models.Services;
using gestionCrud.Models;
using gestionCrud.Models.Datas;
using gestionCrud.Models.DTOs;
using gestionCrud.Models.Profiles;

namespace gestionCrud.Controllers;

public class CategoriesController
{

    private CategoriesService _categoriesService;
    private CategoriesProfile _categoriesProfile;

    public CategoriesController()
    {
        _categoriesService = new CategoriesService();
        _categoriesProfile = new CategoriesProfile();

    }

    /// <summary>
    /// Récupération des produits dans le fichiers JSON
    /// </summary>
    /// <returns>Une liste de produits DTO out</returns>
    public List<CategoriesDTOout> GetAllCategories()
    {

        var listeCategories = _categoriesService.GetAllCategories();

        List<CategoriesDTOout> categoriesDTOouts = _categoriesProfile.CategorysMap(listeCategories);

        return categoriesDTOouts;
    }

    public CategoriesDTOout GetCategoryById(int id)
    {
        try
        {
            Category catFromRepo = _categoriesService.GetCategoryById(id);
            CategoriesDTOout cat = _categoriesProfile.CategorysOutToBaseMap(catFromRepo);
            return cat;
        } 
        catch (Exception ex)
        {
            return null;
        }        

    }

    public CategoriesDTOout GetCategoryByName(string name)
    {
        try
        {
            Category catFromRepo = _categoriesService.GetCategoryByName(name);
            CategoriesDTOout cat = _categoriesProfile.CategorysOutToBaseMap(catFromRepo);
            return cat;
        }
        catch (Exception ex)
        {
            return null;
        }

    }



    public void UpdateCategorie(int id, CategoriesDTOout entity)
    {
        // conversion de CategoriesDTOin en CategoriesDTO
        Category category = _categoriesProfile.CategorysMapOutUpdate(entity);



        // Categorie CategorieFromRepo = _productsService.GetCategorieById(id);

        // if (CategorieFromRepo == null)
        //{
        //     Console.Write("Not found");
        //}



        _categoriesService.UpdateCategory(category);
    }

    public void DeleteCategorie(int id)
    {
        _categoriesService.DeleteCategory(id);
    }

    public void CreateProduct(CategoriesDTOin entity)
    {
        // conversion de ProductsDTOin en ProductsDTO
        Category category = _categoriesProfile.CategorysMapCreate(entity);
        _categoriesService.CreateCategory(category);
    }


    //public ActionResult PartialProductUpdate(int id, [FromBody] JsonPatchDocument<Product> patchDoc)
    //{
    //    var ProductFromRepo = _ProductsService.GetProductById(id);

    //    if (ProductFromRepo == null)
    //    {
    //        return NotFound();
    //    }

    //    var ProductToPatch = _mapper.Map<Product>(ProductFromRepo);

    //    patchDoc.ApplyTo(ProductToPatch, ModelState);
    //    if (!TryValidateModel(ProductToPatch))
    //    {
    //        return ValidationProblem();
    //    }

    //    _mapper.Map(ProductToPatch, ProductFromRepo);
    //    _ProductsService.UpdateProduct(ProductFromRepo);

    //    return NoContent();
    //}
}

