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

    public class CategoriesProfile
    {



        /// <summary>
        /// Mapping de la classe Categorys avec les DTOS
        /// </summary>
        /// <param name="categorysListe"></param>
        /// <returns>Une liste de CategorysDtoout</returns>
        public List<CategoriesDTOout> CategorysMap(IEnumerable<Category> categorysListe)
        {
            List<CategoriesDTOout> categorysDTOout = new List<CategoriesDTOout>();

            foreach (var category in categorysListe)
            {
                CategoriesDTOout categoryDTO = new CategoriesDTOout(category.Id, category.Name, category.Description, category.Date);
                categoryDTO.Id = category.Id;
                categoryDTO.Name = category.Name;
                categoryDTO.Description = category.Description;
 
                categoryDTO.Date = category.Date;

                categorysDTOout.Add(categoryDTO);
            }

            return categorysDTOout;
        }

        // converti un DTOIn en category Base pour create 
        public Category CategorysMapCreate(CategoriesDTOin categoryDtoIn)
        {

            CategoriesService categorysService = new CategoriesService();

            int id = categorysService.getLastId();

            Category category = new Category(id + 1, categoryDtoIn.Name, categoryDtoIn.Description, categoryDtoIn.Date, null);


            //category.Id = categoryDtoIn.Id;
            //category.Name = categoryDtoIn.Name;
            //category.Description = categoryDtoIn.Description;
            //category.Serial = categoryDtoIn.Serial;
            //category.Date = categoryDtoIn.Date;



            return category;
        }

        // converti un DTOout en category Base pour update 
        public Category CategorysMapOutUpdate(CategoriesDTOout categoryDtoout)
        {

            CategoriesService categorysService = new CategoriesService();

            int id = categorysService.getLastId();

            Category category = new Category(categoryDtoout.Id, categoryDtoout.Name, categoryDtoout.Description,  categoryDtoout.Date, null);


            //category.Id = categoryDtoIn.Id;
            //category.Name = categoryDtoIn.Name;
            //category.Description = categoryDtoIn.Description;
            //category.Serial = categoryDtoIn.Serial;
            //category.Date = categoryDtoIn.Date;



            return category;
        }

        public CategoriesDTOout CategorysOutToBaseMap(Category category)
        {

            // CategoriesService categorysService = new CategoriesService();


            CategoriesDTOout categoryOut = new CategoriesDTOout(category.Id, category.Name, category.Description, category.Date);


            //category.Id = categoryDtoIn.Id;
            //category.Name = categoryDtoIn.Name;
            //category.Description = categoryDtoIn.Description;
            //category.Serial = categoryDtoIn.Serial;
            //category.Date = categoryDtoIn.Date;



            return categoryOut;
        }



    }
}

