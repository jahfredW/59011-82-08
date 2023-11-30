using gestionCrud.Models.DTOs;
using gestionCrud.Models.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                ProductsDTOout productDTO = new ProductsDTOout();
                productDTO.Name = product.Name;
                productDTO.Description = product.Description;
                productDTO.Serial = product.Serial;
                productDTO.Date = product.Date;

                productsDTOout.Add(productDTO);
            }

            return productsDTOout;
        }
        

       
}
}
