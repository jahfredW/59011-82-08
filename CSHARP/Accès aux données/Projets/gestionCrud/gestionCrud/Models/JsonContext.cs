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
        const string CATEGORIES_PATH = @"U:\59011-82-08\CSHARP\Accès aux données\Projets\gestionCrud\gestionCrud\datas.json";
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

        public void SaveDataCategory(List<Category> category)
        {



            string json = Newtonsoft.Json.JsonConvert.SerializeObject(category);

            try
            {
                File.WriteAllText(CATEGORIES_PATH, json);
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

        public void DeleteCategory(int id)
        {

            // string json = Newtonsoft.Json.JsonConvert.SerializeObject(product);

            // lecture du fichier
            string jsonData = File.ReadAllText(JSON_PATH);

            try
            {
                // récupération de la liste des product et désérialisation : 
                List<Category> categoryList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Category>>(jsonData);
                List<Category> categoryToKeep = new List<Category>();

                // parcours de la liste : 
                foreach (var item in categoryList)
                {
                    if (item.Id != id)
                    {
                        categoryToKeep.Add(item);
                    }

                }

                SaveDataCategory(categoryToKeep);

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
                List<Product> productList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Product>>(jsonData);
                return productList;

            }
            catch (Exception ex)
            {
                ex.Dump();
                return null;
            }
        }

        public List<Category> GetAllCategories()
        {
            // lecture du fichier
            string jsonData = File.ReadAllText(CATEGORIES_PATH);

            try
            {
                List<Category> categoryList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Category>>(jsonData);
                return categoryList;

            }
            catch (Exception ex)
            {
                ex.Dump();
                return null;
            }
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

        public void AddAllCategories(Category category)
        {

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(category);

            try
            {
                File.AppendAllText(CATEGORIES_PATH, json);
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

        public Category GetCategory(int id)
        {

            // string json = Newtonsoft.Json.JsonConvert.SerializeObject(product);

            // lecture du fichier
            string jsonData = File.ReadAllText(CATEGORIES_PATH);

            try
            {
                // récupération de la liste des product et désérialisation : 
                List<Category> categoryList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Category>>(jsonData);

                // parcours de la liste : 
                foreach (var item in categoryList)
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

        // remplacement d'un produit et sauvegarde dans le fichier 
        public void ReplaceCategory(Category category)
        {
            // récupération du product dans le repo 
            Category categoryfromRepo = GetCategory(category.Id);

            // remplacement des valeurs 
            categoryfromRepo.Name = category.Name;
            categoryfromRepo.Description = category.Description;
            categoryfromRepo.Date = category.Date;

            try
            {
                // récupération de la liste des product et désérialisation : 
                List<Category> categoryList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Category>>(_jsonData);

                // remplacement 
                int index = categoryList.FindIndex(o => o.Id == category.Id);

                if (index != -1)
                {
                    categoryList[index] = category;
                }

                // sauvegarde en bdd 
                SaveDataCategory(categoryList);



            }
            catch (Exception ex)
            {
                Console.WriteLine("error");

            }

        }

        public void CreateProduct(Product product) 
        {
            // Récupération de la liste des produits
            List<Product> productsList = GetAll();

            // réupération du dernier produit de la liste
            Product lastP = productsList[productsList.Count - 1];

            // récupération de son Id 
            int lastId = lastP.Id;

            // int productsListIndex = productsList.Count();

            Product productToSave = new Product(lastId + 1, product.Name, product.Description, product.Serial, product.Date, product.CategoryId);

            // ajout du dernier produit à la liste  
            productsList.Add(productToSave);

            // sauvegarde dans le fihcier JSON
            SaveData(productsList);

        }

        public void CreateCategory(Category category)
        {
            // Récupération de la liste des produits
            List<Category> categorysList = GetAllCategories();

            // réupération du dernier produit de la liste
            Category lastP = categorysList[categorysList.Count - 1];

            // récupération de son Id 
            int lastId = lastP.Id;

            // int categorysListIndex = categorysList.Count();

            Category categoryToSave = new Category(lastId + 1, category.Name, category.Description, category.Date, null);

            // ajout du dernier produit à la liste  
            categorysList.Add(categoryToSave);

            // sauvegarde dans le fihcier JSON
            SaveDataCategory(categorysList);

        }

        public int GetLastId()
        {
            // Récupération de la liste des produits
            List<Product> productsList = GetAll();

            // réupération du dernier produit de la liste
            Product lastP = productsList[productsList.Count - 1];

            // récupération de son Id 
            int lastId = lastP.Id;

            return lastId;
        }

        public int GetLastIdCategory()
        {
            // Récupération de la liste des produits
            List<Category> categorysList = GetAllCategories();

            // réupération du dernier produit de la liste
            Category lastP = categorysList[categorysList.Count - 1];

            // récupération de son Id 
            int lastId = lastP.Id;

            return lastId;
        }
    }
}
