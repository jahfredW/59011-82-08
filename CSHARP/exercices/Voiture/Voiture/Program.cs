using Exercices;

namespace Voiture
{
    class Program
    {
        static void Main(string[] args)
        {
            Voiture v1 = new Voiture("Citroen", "C4", null, null, 10000);
            Voiture v2 = new Voiture("Renault", "Kadjar", null, "rouge", 0);
            Console.WriteLine(v1.ToString());
            Console.Write(v2.ToString());

            v1.Rouler(150);
            Console.WriteLine(v1.ToString());

            Client Client1 = new Client("1234", "GRUWE", "Frédéric", "0785858985");
            Console.WriteLine(Client1.ToString());

            Compte Compte = new Compte(10000, Client1);
            Compte.Crediter(200);
            Compte.Debiter(200, Compte);

        }
    }
}