using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gestionCrud.Models.Datas;
using gestionCrud.Models.DTOs;

namespace gestionCrud.Models
{
    public class JsonContext
    {
        const string JSON_PATH = @"U:\59011-82-08\CSHARP\Accès aux données\Projets\gestionCrud\gestionCrud\datas.json";
        // const string JSON_PATH = @"E:\cours\59011-82-08\CSHARP\3 - Accès aux données\gestionCrud\gestionCrud\datas.json";
        static string currentDirectory = Directory.GetCurrentDirectory();
        public string _jsonData;
        // fonction save product, itère sur la liste des product et 
        // alimente le fichier data.json"
        // string jsonPath = Path.Combine(currentDirectory, JSON_PATH);

        public JsonContext()
        {
            _jsonData = File.ReadAllText(JSON_PATH);
        }


        public void SaveData(List<Product> product)
        {



            string json = Newtonsoft.Json.JsonConvert.SerializeObject(product);

            try
            {
                File.WriteAllText(JSON_PATH, json);
            }
            catch (Exception ex)
            {
                ex.Dump();
            }

        }

        public void DeleteProduct(int id)
        {



            // string json = Newtonsoft.Json.JsonConvert.SerializeObject(product);

            // lecture du fichier
            string jsonData = File.ReadAllText(JSON_PATH);

            try
            {
                // récupération de la liste des product et désérialisation : 
                List<Product> productList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Product>>(jsonData);
                List<Product> productToKeep = new List<Product>();

                // parcours de la liste : 
                foreach (var item in productList)
                {
                    if (item.Id != id)
                    {
                        productToKeep.Add(item);
                    }

                }

                SaveData(productToKeep);

            }
            catch (Exception ex)
            {
                ex.Dump();
                Console.Write("une erreur est survenue");
            }

        
    
        }

        public  List<Product> GetAll()
        {
            // lecture du fichier
            string jsonData = File.ReadAllText(JSON_PATH);

            try
            {
                List<Product> product = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Product>>(jsonData);
                return product;

            }
            catch (Exception ex)
            {
                ex.Dump();
                return null;
            }


            // désérialisation 



        }
        public void AddAll(Product product)
        {

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(product);

            try
            {
                File.AppendAllText(JSON_PATH, json);
            }
            catch (Exception ex)
            {
                ex.Dump();
            }

        }

        public Product Get(int id)
        {

            // string json = Newtonsoft.Json.JsonConvert.SerializeObject(product);

            // lecture du fichier
            string jsonData = File.ReadAllText(JSON_PATH);

            try
            {
                // récupération de la liste des product et désérialisation : 
                List<Product> photoList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Product>>(jsonData);

                // parcours de la liste : 
                foreach (var item in photoList)
                {
                    if (item.Id == id)
                    {
                        return item;
                    }

                }
                return null;


            }
            catch (Exception ex)
            {
                ex.Dump();
                return null;
            }

        }

        // remplacement d'un produit et sauvegarde dans le fichier 
        public void Replace(Product product)
        {
            // récupération du product dans le repo 
            Product productfromRepo = Get(product.Id);

            // remplacement des valeurs 
            productfromRepo.Name = product.Name;
            productfromRepo.Description = product.Description;
            productfromRepo.Serial = product.Serial;
            productfromRepo.Date = product.Date;

            try
            {
                // récupération de la liste des product et désérialisation : 
                List<Product> photoList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Product>>(_jsonData);

                // remplacement 
                int index = photoList.FindIndex(o => o.Id == product.Id);

                if(index != -1)
                {
                    photoList[index] = product;
                }

                // sauvegarde en bdd 
                SaveData(photoList);
                


            }
            catch (Exception ex)
            {
                Console.WriteLine("error");
                
            }

        }
    }
}
