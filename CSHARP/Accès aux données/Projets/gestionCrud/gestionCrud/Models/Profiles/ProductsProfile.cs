using gestionCrud.Models.DTOs;
using gestionCrud.Models.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gestionCrud.Models.Services;

namespace gestionCrud.Models.Profiles
{
    
    public class ProductsProfile
    {
       

         
        /// <summary>
        /// Mapping de la classe Products avec les DTOS
        /// </summary>
        /// <param name="productsListe"></param>
        /// <returns>Une liste de ProductsDtoout</returns>
        public List<ProductsDTOout> ProductsMap(IEnumerable<Product> productsListe)
        {
            List<ProductsDTOout> productsDTOout = new List<ProductsDTOout>();

            foreach (var product in productsListe)
            {
                ProductsDTOout productDTO = new ProductsDTOout(product.Id, product.Name, product.Description, product.Serial, product.Date);
                productDTO.Id = product.Id;
                productDTO.Name = product.Name;
                productDTO.Description = product.Description;
                productDTO.Serial = product.Serial;
                productDTO.Date = product.Date;

                productsDTOout.Add(productDTO);
            }

            return productsDTOout;
        }

        // converti un DTOIn en product Base pour create 
        public Product ProductsMapCreate(ProductsDTOin productDtoIn)
        {

            ProductsService productsService = new ProductsService();

            int id = productsService.getLastId();
             
            Product product = new Product(id + 1, productDtoIn.Name, productDtoIn.Description, productDtoIn.Serial, productDtoIn.Date, 1 );

          
            //product.Id = productDtoIn.Id;
            //product.Name = productDtoIn.Name;
            //product.Description = productDtoIn.Description;
            //product.Serial = productDtoIn.Serial;
            //product.Date = productDtoIn.Date;

         

            return product;
        }

        // converti un DTOout en product Base pour update 
        public Product ProductsMapOutUpdate(ProductsDTOout productDtoout)
        {

            ProductsService productsService = new ProductsService();

            int id = productsService.getLastId();

            Product product = new Product(productDtoout.Id, productDtoout.Name, productDtoout.Description, productDtoout.Serial, productDtoout.Date, 1);


            //product.Id = productDtoIn.Id;
            //product.Name = productDtoIn.Name;
            //product.Description = productDtoIn.Description;
            //product.Serial = productDtoIn.Serial;
            //product.Date = productDtoIn.Date;



            return product;
        }



    }
}
