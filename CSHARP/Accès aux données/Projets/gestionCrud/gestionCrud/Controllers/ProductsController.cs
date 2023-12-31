﻿using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using gestionCrud.Models.Services;
using gestionCrud.Models;
using gestionCrud.Models.Datas;
using gestionCrud.Models.DTOs;
using gestionCrud.Models.Profiles;

namespace gestionCrud.Controllers;

public class ProductsController 
{
   
    private ProductsService _productsService;
    private ProductsProfile _productsProfile;

    public ProductsController()
    {
        _productsService = new ProductsService();
        _productsProfile = new ProductsProfile();

    }

    /// <summary>
    /// Récupération des produits dans le fichiers JSON
    /// </summary>
    /// <returns>Une liste de produits DTO out</returns>
    public List<ProductsDTOout> GetAllProducts()
    {

        
        var listeProducts = _productsService.GetAllProducts();

        List<ProductsDTOout> productsDTOouts = _productsProfile.ProductsMap(listeProducts);

        return productsDTOouts;
    }


    //public ActionResult<ProductsDTO> GetProductById(int id)
    //{
    //    var ProductItem = _ProductsService.GetProductById(id);

    //    if (ProductItem != null)
    //    {
    //        return Ok(_mapper.Map<ProductsDTO>(ProductItem));
    //    }

    //    return NotFound();
    //}


    //public ActionResult<ProductsDTO> CreateProduct(Product entity)
    //{
    //    _ProductsService.AddProduct(entity);
    //    return CreatedAtRoute(nameof(GetProductById), new { Id = entity.IdProduct }, entity);
    //}


    public void UpdateProduct(int id, ProductsDTOout entity)
    {
        // conversion de ProductsDTOin en ProductsDTO
        Product product = _productsProfile.ProductsMapOutUpdate(entity);



       // Product ProductFromRepo = _productsService.GetProductById(id);
       
       // if (ProductFromRepo == null)
       //{
       //     Console.Write("Not found");
       //}

        

        _productsService.UpdateProduct(product);
    }

    public void DeleteProduct(int id)
    {
        _productsService.DeleteProduct(id);
    }

    public void CreateProduct(ProductsDTOin entity) 
    {
        // conversion de ProductsDTOin en Product
        Product product = _productsProfile.ProductsMapCreate(entity);

        // Récupératin 


        _productsService.CreateProduct(product);
    }

}

