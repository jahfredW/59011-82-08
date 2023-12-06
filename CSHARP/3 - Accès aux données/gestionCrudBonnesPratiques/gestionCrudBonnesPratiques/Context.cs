using gestionCrudBonnesPratiques.Datas;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestionCrudBonnesPratiques
{
    public static class Context
    {
        public static JsonStructure ReadJson(string path)
        {

            string content = File.ReadAllText(path);

            // deserialisation en objet de type StructureJson
            JsonStructure structure = Newtonsoft.Json.JsonConvert.DeserializeObject<JsonStructure>(content);

            // on renvoie la structure
            return structure; 

        }

        public static void WriteJson(string path, JsonStructure json)
        {   
            // serialisation de l'objet json qui représente la structure : 

            string js = Newtonsoft.Json.JsonConvert.SerializeObject(json);

            // inscription en Bdd 
            File.WriteAllText(path, js);
        }
    }
}
