using AutoMapper.Configuration.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gestionCrud.Models.Datas;
using Microsoft.EntityFrameworkCore.Query.Internal;
using gestionCrud.Models;

namespace gestionCrud
{
    public static class ObjectBuilder
    {
        public static void productBuilder()
        {
            List<Product> listeproducts = new List<Product>();

            for( int index = 0; index < 10; index++ ) 
            {
                Product product = new Product();
                product.Id = index;
                product.Name = "nom" + index;
                product.Date = DateTime.Now;
                product.Description = "description produit" + index;
                product.Serial =  "serial" + index;

                listeproducts.Add(product);
            }

            // inscription dans la fichier Json : 
            saveDb(listeproducts);
            
        }

        private static void saveDb(List<Product> listeProduct)
        {
            JsonContext context = new JsonContext();
            context.SaveData(listeProduct);
        }


    }
}
