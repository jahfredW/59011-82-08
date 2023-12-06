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

        static string currentDirectory = Directory.GetCurrentDirectory();
        // fonction save product, itère sur la liste des product et 
        // alimente le fichier data.json"
        // string jsonPath = Path.Combine(currentDirectory, JSON_PATH);

        //public JsonContext()
        //{
        //    _jsonData = File.ReadAllText(JSON_PATH);
        //}


        public static void SaveData(StructureJson json, string path)
        {

            string jsonToSave = Newtonsoft.Json.JsonConvert.SerializeObject(json);

            try
            {
                File.WriteAllText(path, jsonToSave);
            }
            catch (Exception ex)
            {
                ex.Dump();
            }

        }

        public static StructureJson ReadData(string path)
        {
            string content; 
            content = File.ReadAllText(path);

            StructureJson js = Newtonsoft.Json.JsonConvert.DeserializeObject<StructureJson>(content);

            return js;
        }



    }
}
