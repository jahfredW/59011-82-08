using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MultiFenetre
{
    static class Dto
    {
        const string JSON_PATH = @"U:\59011-82-08\MultiFenetre\MultiFenetre\data.json";
        static string currentDirectory = Directory.GetCurrentDirectory();
        // fonction save photos, itère sur la liste des photos et 
        // alimente le fichier data.json"
        // string jsonPath = Path.Combine(currentDirectory, JSON_PATH);

        public static void SaveData(List<Photos> photos)
        {
           
            

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(photos);
            
            try
            {
                File.WriteAllText(JSON_PATH, json);
            }
            catch ( Exception ex)
            {
                ex.Dump();
            }
           
        }

        public static List<Photos> GetAll()
        {
            // lecture du fichier
            string jsonData = File.ReadAllText(JSON_PATH);

            try
            {
                List<Photos> photos = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Photos>>(jsonData);
                return photos;
                
            } 
            catch ( Exception ex )
            {
                ex.Dump();
                return null;
            }


            // désérialisation 

            

        }
        public static void AddAll(Photos photos)
        {

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(photos);

            try
            {
                File.AppendAllText(JSON_PATH, json);
            }
            catch (Exception ex)
            {
                ex.Dump();
            }

        }

        public static Photos Get(Photos photos)
        {

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(photos);

            // lecture du fichier
            string jsonData = File.ReadAllText(JSON_PATH);

            try
            {
                // récupération de la liste des photos et désérialisation : 
                List<Photos> photoList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Photos>>(jsonData);

                // parcours de la liste : 
                foreach( var item in photoList)
                {
                    if(item == photos)
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
