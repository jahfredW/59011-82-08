using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace log
{
    public static class FFManagement
    {

        // récupère les infos d'un dossier ( extension et chemin) 
        public static void FolderInfo(string path)
        {
            string extension;
            string folder;
            // obtenir l'extension du path 
            extension = Path.GetExtension(path);

            // récupérer le dossier du path 
            folder = Path.GetDirectoryName(path);

            Console.WriteLine("extention : " + extension + " , dossier :  " + folder);
        }

        public static bool CheckErrors(string path)
        {
            try
            {
                // vérification si présence d'une extension : 
                if (!Path.HasExtension(path))
                {
                    Console.WriteLine("Nom de dossier invalide");
                    return true;
                }
                
                if(File.Exists(path))
                {
                    Console.WriteLine("Le fichier existe déja");
                    return true;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed");
                return true;
            }
            return false;
        }



        // méthode de Build de dossier 
        public static void BuildDirectory(string path)
        {
            DirectoryInfo di;

            try
            {
                // gesttion dossier existe déja
                if (Directory.Exists(path))
                {
                    Console.WriteLine("{0} already exists", path);
                    return;
                }

                // vérification si présence d'une extension : 
                if (Path.HasExtension(path))
                {
                    Console.WriteLine("Nom de dossier invalide");
                    return;
                }



                di = Directory.CreateDirectory(path);
                Console.WriteLine("Directory {0} successfully created at {1}", path, Directory.GetCreationTime(path));
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed");
            }
        }

        // méthode de Build de fichier 
        public static void BuildFile(string path)
        {
            FileStream file;
            try
            {
                // vérification si présence d'une extension : 
                if (!Path.HasExtension(path))
                {
                    Console.WriteLine("Nom de dossier invalide");
                    return;
                }

                // gesttion dossier existe déja
                if (File.Exists(path))
                {
                    Console.WriteLine("{0} already exists", path);
                    return;
                }

                // création du fichier 
                file = File.Create(path);
                Console.WriteLine("Directory {0} successfully created at {1}", path, Directory.GetCreationTime(path));
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed");
            }
        }

        // méthode d'écriture dans un fichier 
        public static async Task CreateAndWriteFile(string path)
        {
            // Write the specified text asynchronously to a new file named "WriteTextAsync.txt".
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(path, "WriteTextAsync.txt")))
            {
                await outputFile.WriteAsync("Ecriture réussie.");
            }
        }


        public static async Task WriteIntoAFile(string path, string text)
        {
            
            // Write the specified text asynchronously to a new file named "WriteTextAsync.txt".
            try
            {
                using (StreamWriter outputFile = new StreamWriter(path))
                {

                    await outputFile.WriteAsync(text);
                }
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        // Ecrire dans 
        public static void WriteFile(string path, string text)
        {
            
            try
            {
                // Si le fichier text existe déja on append
                if (CheckErrors(path))
                {
                    File.AppendAllText(path, text);
                } else
                {
                    File.WriteAllText(path, text);
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void WriteFile(string path, string[] text)
        {
            
            try
            {
                if (CheckErrors(path))
                {
                    File.AppendAllLines(path, text);
                }
                else 
                {
                    File.WriteAllLines(path, text);
                }
                
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void ReadFile(string path)
        {
            string[] lines;
            // string file = Path.GetFileName(path);

            try
            {
                if (File.Exists(path))
                {
                    lines = File.ReadAllLines(path);

                    foreach (string line in lines)
                    {
                        Console.WriteLine(line);
                    }
                }
                else
                {
                    Console.WriteLine("Le fichier n'existe pas");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
             
        }




    }

    
}
