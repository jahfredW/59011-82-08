using account;
class Program
    {
        static void Main(string[] args)
        {

            Client Client1 = new Client("1234", "GRUWE", "Frédéric", "0785858985");
            Console.WriteLine(Client1.ToString());

            Compte Compte = new Compte(10000, Client1);
            Compte.Crediter(200);
            Compte.Debiter(200, Compte);

        }
    }

