using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gestionCrud.Models.Datas;

namespace gestionCrud.Models
{
    public  class JsonContext
    {
        const string JSON_PATH = @"U:\59011-82-08\CSHARP\3 - Accès aux données\gestionCrud\gestionCrud\datas.json";
        static string currentDirectory = Directory.GetCurrentDirectory();
        // fonction save product, itère sur la liste des product et 
        // alimente le fichier data.json"
        // string jsonPath = Path.Combine(currentDirectory, JSON_PATH);

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

        public Product Get(Product product)
        {

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(product);

            // lecture du fichier
            string jsonData = File.ReadAllText(JSON_PATH);

            try
            {
                // récupération de la liste des product et désérialisation : 
                List<Product> photoList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Product>>(jsonData);

                // parcours de la liste : 
                foreach (var item in photoList)
                {
                    if (item == product)
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
    }
}
