using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo
{
    class Program
    {
        // fonction exercice 1 
        public static void inputString()
        {
            string userInput;
            int nb;

            Console.WriteLine("Saisissez une nom");
            userInput = Console.ReadLine();
            Console.WriteLine(userInput);

            try
            {
                nb = Convert.ToInt32(userInput);
                Console.WriteLine(nb.GetType());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception :" + ex.Message);
            }
        }

        // fonction exercice 2 
        public static void inputInt()
        {
            string userInput;
            int nb;
            bool flag = false;


            do
            {
                Console.WriteLine("Saisissez un entier");
                userInput = Console.ReadLine();
                try
                {
                    flag = false;
                    nb = Convert.ToInt32(userInput);
                   
                } catch ( Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    flag = true;
                }
                

            } while (flag);

        }

        // function exercice 3 
        public static void calcul()
        {
            string a;
            string b;
            double numA;
            double numB;
            double resultAddition;
            double resultQuotient;

            Console.WriteLine("Saisissez un nombre");
            a = Console.ReadLine();
            Console.WriteLine("Saisissez un deuxième nombre");
            b = Console.ReadLine();

            numA = Convert.ToInt32(a);
            numB = Convert.ToInt32(b);

            resultAddition = numA + numB;

            if(numB == 0)
            {
                Console.WriteLine(" Division impossible");
            } else
            {
                resultQuotient = numA / numB;
                Console.WriteLine(" Resultat de la division : " + resultQuotient);
            }

            Console.WriteLine(" Resultat de l'addition : " + resultAddition);
            
        }



        // méthode exercice 4 
        public static void displayFloat()
        {
            string arg;
            float argFloat;

            Console.WriteLine("Saisissez un nombre flottant");

            arg = Console.ReadLine();

            argFloat = Convert.ToSingle(arg);

            Console.WriteLine(argFloat.GetType());

        }

        // méthode exercice 5 
        public static void calculAvg()
        {
            string a;
            string b;
            string c;
            double avg = 0;

            Console.WriteLine("Saisir valeur 1");
            a = Console.ReadLine();

            Console.WriteLine("Saisir valeur 2");
            b = Console.ReadLine();

            Console.WriteLine("Saisir nombre 3");
            c = Console.ReadLine();

            avg = (Convert.ToDouble(a) * Convert.ToDouble(b) * Convert.ToDouble(c)) / 3;

            Console.WriteLine("Votre moyenne :" + Math.Round(avg));
            
        }

        static void Main(string[] args)
        {
            // exercice 1 
            // Program.inputString();

            // exercice 2 
            // Program.inputInt();

            // exercice 3 
            // Program.calcul();

            // exercice 4 
            // Program.displayFloat();

            // exercice 5 
            Program.calculAvg();
            
        }

        
    }
}
