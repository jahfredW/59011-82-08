using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    internal class Exercices
    {

        // exercice 3-1 
        static void majorite(int age)
        {
            Console.WriteLine(age >= 18 ? "Vous êtes majeur" : "Vous êtes mineur");
        }

        // exercice 3-2 
        static void valeurAbsolue(int num)
        {
            Console.WriteLine(Math.Abs(num));
        }

        // exercie 3-3 
        static void admissions(int note)
        {
            string status = "";

            if (note <= 8)
            {
                status = "ajourné";
            }
            else if (note < 10)
            {
                status = "rattrapage";
            }
            else
            {
                status = "admis";
            }

            Console.WriteLine(status);
        }





        // exercice 2-4 
        static void calculMonnaie()
        {
            double userSomme = 0.99;
            int nombrePieces = 0;
            double[] listeMonnaie;
            listeMonnaie = new double[] { 0.5, 0.2, 0.1, 0.05, 0.02, 0.01 };
            IDictionary<double, int> detailMonnaie;


            detailMonnaie = new Dictionary<double, int>();
            while (userSomme > 0)
            {
                for (int i = 0; i < listeMonnaie.Length; i++)
                {
                    if (listeMonnaie[i] <= userSomme)
                    {
                        userSomme -= listeMonnaie[i];
                        userSomme = Math.Round(userSomme, 2);
                        nombrePieces++;

                        // alimentation du dictionnaire contenant les pièces utilisées. 
                        if (detailMonnaie.ContainsKey(listeMonnaie[i]))
                        {
                            // La clé existe, incrémentez la valeur associée
                            detailMonnaie[listeMonnaie[i]]++;
                        }
                        else
                        {
                            // La clé n'existe pas, ajoutez-la avec une valeur initiale
                            detailMonnaie.Add(listeMonnaie[i], 1);
                        }
                        Console.WriteLine("1 pièce de :" + listeMonnaie[i]);
                        Console.WriteLine("Reste :" + userSomme);
                        break;
                    }
                }
            }

            Console.WriteLine("Vosu avez utilisé :");

            foreach (var paire in detailMonnaie)
            {
                Console.WriteLine($"Valeur : {paire.Key} , nombre : {paire.Value}");
            }


        }

        // exercice 2-3 Cartons et camions
        static double calculCartons()
        {
            double camionCapacite = 0;
            double poidsCarton = 0;
            int nombreCarton = 0;

            nombreCarton = (int)Math.Round(camionCapacite / poidsCarton);

            return nombreCarton;


        }


        // exercice 6
        static double calculSurface(double longueur, double largeur)
        {
            return largeur * longueur;
        }


        // exercice 7 
        static void unicode()
        {
            int successeur;

            // initialiser un array méthode 1 -> les array ne sont aps dynamiquqes ici. 
            char[] tableauChar;
            tableauChar = new char[] { '1', '2', '3', '4', '5' };

            // méthode 2 : 
            char[] tabChar = { '1', '2', '3', '4', '5' };

            // parcours du tab : 
            foreach (char c in tableauChar)
            {
                Console.WriteLine("Unicode :" + Convert.ToInt32(c));
            }

            // list 
            // IList<int> list = new List<int>();
            // list.Insert(1, 12); // insère le nombre entier 12 à la position 1 
            // list.Add(5); // ajoute un nouvel élément à la fin de la liste 
            // list.RemoveAt(0); // supprimer l'élement se situant à l'index 0. 

            // dictionnaires 
            IDictionary<string, int> myDict = new Dictionary<string, int>();



            // WriteLine vas à la ligne, Write Non. 
            char a = 'a';
            Console.WriteLine("Unicode : " + (int)a); // ou Convert.ToInt32()
            Console.WriteLine("Majuscule : " + char.ToUpper(a));

            // successeur dans la table unicode 
            successeur = (int)a + 1;
            Console.WriteLine("Successeur : " + successeur + ", " + "Lettre :" + (char)successeur);

            // unicode dans un array : 

            int[] array2 = { 1, 2, 3, 4, 5, 6 };

            // parcours du tableau est affichage 
            foreach (int i in array2)
            {
                Console.WriteLine("nombre: " + i);
            }



        }

        // exercice 3-1-4 
        static void Assurance(double montantDegats)
        {
            double montantARembourser;
            double franchise;

            // calcul de la franchise
            franchise = montantDegats * 0.1;

            if (franchise >= 4000)
            {
                Console.WriteLine("C'est Mort");
            } else
            {
                montantARembourser = montantDegats - franchise;
                Console.WriteLine("Franchise : " + franchise);
                Console.WriteLine("Montant à vous rembourser : " + montantARembourser);
            }

        }

        // exercice 3-1-6 
        static void ValeursDistinctes()
        {
            string v1 = "";
            string v2 = "";

            Console.WriteLine("Entrez valeur 1 :");
            v1 = Console.ReadLine();

            Console.WriteLine("Entrez valeur 2 :");
            v2 = Console.ReadLine();

            Console.WriteLine(v1 == v2 ? "Valeurs identiques" : "Valeurs différentes");
        }

        // exercice 3-1-7
        static void plusPetitValeur()
        {
            string v1 = "";
            string v2 = "";
            string v3 = "";

            Console.WriteLine("Entrez valeur 1 :");
            v1 = Console.ReadLine();


            Console.WriteLine("Entrez valeur 2 :");
            v2 = Console.ReadLine();

            Console.WriteLine("Entrez valeur 3 :");
            v3 = Console.ReadLine();




        }

        // exercice 3-2 matrice 
        static void echiquier()
        {


            int x;
            int y;

            // déclaration d'un tableau à deux dimensions 
            string[,] matrice = new string[8, 8];

            // on boucle sur les X et les Y 
            for (int i = 1; i < matrice.GetLength(0) + 1; i++)
            {
                for (int j = 1; j < matrice.GetLength(1) + 1; j++)
                {
                    // Si somme des index  est paire, alors noire
                    if ((i + j) % 2 == 0)
                    {
                        matrice[i - 1, j - 1] = "noire";
                    }
                    // sinon case blanche 
                    else
                    {
                        matrice[i - 1, j - 1] = "blanche";
                    }
                }
            }

            // input Utilisateur 
            Console.WriteLine("coordonnée x de la case ?");

            do
            {
                Console.WriteLine("coordonnée y de la case x ?");
            }
            while (int.TryParse(Console.ReadLine(), out x));

            do
            {
                Console.WriteLine("coordonnée y de la case y ?");
            }
            while (int.TryParse(Console.ReadLine(), out y));



            // calcul et sortie, attention, on inver -> [y, x] car x = ligne, y = colonne 
            string value = matrice[Convert.ToInt32(y) - 1, Convert.ToInt32(x) - 1];
            Console.WriteLine("valeur de la case: " + value);



            /*for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    string valeur = matrice[i, j];
                    Console.WriteLine($"Ligne {i}, Colonne {j} : {valeur}");
                }
            }
            */


        }
        static void Cavalier(int deplacementX, int deplacementY, int initX, int initY)
        {
            if ((Math.Abs(deplacementX - initX) == 2 && Math.Abs(deplacementY - initY) == 1) || (Math.Abs(deplacementX - initX) == 1 && Math.Abs(deplacementY - initY) == 2))
            {
                Console.WriteLine("Déplacement possible");
            }
            else
            {
                Console.WriteLine("Déplacement impossible");
            }
        }

        static bool Fou(int deplacementX, int deplacementY, int initX, int initY)
        {
            if (Math.Abs(initY - deplacementY) == Math.Abs(initX - deplacementX))
            {
                return true;
            }
            return false;
        }

        static bool Tour(int deplacementX, int deplacementY, int initX, int initY)
        {
            if ((initY == deplacementY) || (initX == deplacementX))
            {
                return true;
            }
            return false;
        }

        static bool Queen(int deplacementX, int deplacementY, int initX, int initY)
        {
            if ((initY == deplacementY) || (initX == deplacementX) || (Math.Abs(initY - deplacementY) == Math.Abs(initX - deplacementX)))
            {
                return true;
            }
            return false;
        }

        static bool King(int deplacementX, int deplacementY, int initX, int initY)
        {
            if ((initY == deplacementY) || (initX == deplacementX) || (Math.Abs(initY - deplacementY) == Math.Abs(initX - deplacementX)
                && (Math.Abs(initY - deplacementY) == 1 || Math.Abs(initX - deplacementX) == 1)))
            {
                return true;
            }
            return false;
        }

        static void heureEtDate()
        {
            string heureDebut;
            string heureFin;
            string minutesDebut;
            string minutesFin;
            int heureDebutInt;
            int minutesDebutInt;
            int heureFinInt;
            int minutesFinInt;


            do
            {
                Console.WriteLine("heure de début ? ");
                heureDebut = Console.ReadLine();
                heureDebutInt = Convert.ToInt32(heureDebut);
            } while (heureDebutInt < 0);

            do
            {
                Console.WriteLine("Minutes de début ?");
                minutesDebut = Console.ReadLine();
                minutesDebutInt = Convert.ToInt32(minutesDebut);
            } while (minutesDebutInt >= 60 || minutesDebutInt < 0);

            do
            {
                Console.WriteLine("heure de fin ? ");
                heureFin = Console.ReadLine();
                heureFinInt = Convert.ToInt32(heureFin);
            } while (heureFinInt < 0);

            do
            {
                Console.WriteLine("minutes de fin ?");
                minutesFin = Console.ReadLine();
                minutesFinInt = Convert.ToInt32(minutesFin);
            } while (minutesFinInt >= 60 || minutesFinInt < 0);



            // gestion de l'heure de fin supérieure 
            if (heureFinInt > heureDebutInt)
            {
                throw new InvalidOperationException("L'heure de fin ne peut pas être supérieure à l'heure de début.");
            }



            // convertion des minutes de début en heure : 
            int diffDebut = 60 - minutesDebutInt;
            int diffheure = heureFinInt - (heureDebutInt + 1);
            int diffMinutes = minutesFinInt + diffDebut;

            // reconversion des minutes et init 
            if (diffMinutes == 60)
            {
                diffheure += 1;
                diffMinutes = 0;
            }

            // sortie
            Console.WriteLine("Temps écoulé : " + diffheure + " heures et : " + diffMinutes + " minutes");
        }


        static void calculDate()
        {
            string day;
            string month;
            string year;
            int dayInt;
            int monthInt;
            int yearInt;
            int[] month31days = { 1, 3, 5, 7, 8, 10, 12 };
            int[] biYears = { 2024, 2028, 2032, 2036, 2040 };

            do
            {
                Console.WriteLine("jour ?");
                day = Console.ReadLine();
                dayInt = Convert.ToInt32(day);
            } while (dayInt > 31 || dayInt < 0);

            do
            {
                Console.WriteLine("mois ?");
                month = Console.ReadLine();
                monthInt = Convert.ToInt32(month);
            } while (monthInt > 12 || monthInt < 0 || (!month31days.Contains(monthInt) && dayInt == 31));

            do
            {
                Console.WriteLine("année ?");
                year = Console.ReadLine();
                yearInt = Convert.ToInt32(year);
            } while (yearInt > 2050 || yearInt < 2000);


            // si fin du mois
            if (month31days.Contains(monthInt))
            {
                if (dayInt <= 30)
                {
                    dayInt += 1;
                }
                else
                {
                    dayInt = 1;
                    monthInt += 1;
                }
            }
            else if (!month31days.Contains(monthInt) && monthInt != 2)
            {
                if (dayInt <= 29)
                {
                    dayInt += 1;
                }
                else
                {
                    dayInt = 1;
                    monthInt += 1;

                }
            }
            else
            {
                if (dayInt <= 27 && !biYears.Contains(yearInt))
                {
                    dayInt += 1;
                }
                else if (dayInt == 28 && !biYears.Contains(yearInt) || (dayInt == 29 && biYears.Contains(yearInt)))
                {
                    dayInt = 1;
                    monthInt += 1;
                }
                else
                {
                    dayInt += 1;
                }

            }

            if (monthInt == 13)
            {
                dayInt = 1;
                monthInt = 1;
                yearInt += 1;
            }


            Console.WriteLine("jour : " + dayInt + " mois : " + monthInt + " année : " + yearInt);


        }

        // exercice 13
        static void borne()
        {

            int a;
            int b;
            int x;

            do
            {
                Console.WriteLine("Entrez un nombre a ?");
                int.TryParse(Console.ReadLine(), out a);
                Console.WriteLine("Entrez un nombre b ?");
                int.TryParse(Console.ReadLine(), out b);

            } while (a > b);

            // exercie 14 Appartenance 
            Console.WriteLine("Entrez un nombre x");
            int.TryParse(Console.ReadLine(), out x);

            Console.WriteLine(x >= a && x <= b ? "Dans l'intervalle" : "Hors intervalle");

        }

        // exercice 15 rectangles 
        static void rectangles()
        {
            int x1;
            int y1;
            int x2;
            int y2;
            int x;
            int y;

            do
            {
                Console.WriteLine("Entrez un nombre x1 ?");
                int.TryParse(Console.ReadLine(), out x1);
                Console.WriteLine("Entrez un nombre y1 ?");
                int.TryParse(Console.ReadLine(), out y1);
                Console.WriteLine("Entrez un nombre x2 ?");
                int.TryParse(Console.ReadLine(), out x2);
                Console.WriteLine("Entrez un nombre y2 ?");
                int.TryParse(Console.ReadLine(), out y2);

            } while (x2 <= x1 && y2 <= y1);

            // Exercice 16 
            Console.WriteLine("Coordonnées x?");
            int.TryParse(Console.ReadLine(), out x);

            Console.WriteLine("Coordonnées y?");
            int.TryParse(Console.ReadLine(), out y);

            Console.WriteLine(x >= x1 && x <= x2 && y >= y1 && y <= y2 ? " Dedans" : " Dehors");


        }


        // Exercice 4-1 
        // 5 - 10

        // exercice 4-2 
        // 2,3,18,6

        // exercice 4-3 

        // exercice 4-2-4 compte à rebours
        static int Cab(int a)
        {
            if (a >= 0)
            {
                Console.WriteLine(a);
                return a - Cab(a - 1);
            }
            return a;
        }




        // exercice 4-2-5 factorielle
        static double factorielle(double a)
        {

            if (a >= 1)
            {
                return a * factorielle(a - 1);
            }

            return 1;

        }

        // exercice 4-3-6 tables de multiplication 
        static void Multiplication()
        {
            int number;

            do
            {
                Console.WriteLine("Entrez un nombre entre 1 et 10 ");
            } while (!int.TryParse(Console.ReadLine(), out number) || number > 10 || number < 0);


            for (int i = 1; i < 11; i++)
            {
                Console.WriteLine(i + " * " + number + " = " + number * i);
            }
        }

        // exercice 4-3-7 tables de multiplication
        static void Multiplication2d()
        {

            int[,] tables = new int[10, 10];
            for (int i = 1; i < 11; i++)
            {
                for (int j = 1; j < 11; j++)
                {
                    tables[i - 1, j - 1] = i * j;
                    Console.Write(i * j);
                }
                Console.WriteLine();
            }
        }

        // exercice 4-3-8 Puissance
        static void puissance()
        {
            int b;
            int n;

            do
            {
                Console.WriteLine("Entre un nombre entier");
            } while (!int.TryParse(Console.ReadLine(), out b));

            do
            {
                Console.WriteLine("Entre un nombre entier positif");
            } while (!int.TryParse(Console.ReadLine(), out n) || n <= 0);

            Console.WriteLine("Résultat" + Math.Pow(b, n));

        }

        // exercice 4-3-9 Joli carré 
        static void JoliCarre()
        {
            int number;


            do
            {
                Console.WriteLine("Entre un nombre entier");
            } while (!int.TryParse(Console.ReadLine(), out number));


            for (int i = 0; i < number; i++)
            {
                for (int j = 0; j < number; j++)
                {
                    Console.Write(" X ");
                }
                Console.WriteLine();
            }
        }

        // exercice 4-4-10 Calculatrice de poche
        static void Calculatrice()
        {
            double a = 0;
            double result = 0;
            string op = "";
            string[] opListe = { "-", "+", "*", "/", "=", "$", "µ", "fac" };


            do
            {
                Console.Write("nombre 1: ");
            } while (!double.TryParse(Console.ReadLine(), out result) || result < 0);


            while (op != "=")
            {
                do
                {
                    Console.Write("opérateur: ");
                    op = Console.ReadLine();
                } while (!opListe.Contains(op));


                if (op != "=" && op != "µ" && op != "fac")
                {
                    Console.WriteLine("nombre 2: ");
                    double.TryParse(Console.ReadLine(), out a);

                };


                switch (op)
                {
                    case "+":
                        result += a;
                        break;
                    case "-":
                        result -= a;
                        break;
                    case "/":
                        result /= a;
                        break;
                    case "*":
                        result *= a;
                        break;
                    case "$":
                        result = Math.Pow(result, a);
                        break;
                    case "µ":
                        result = Math.Sqrt(result);
                        break;
                    case "fac":
                        result = factorielle(result);
                        break;
                }

                Console.WriteLine("resultat : " + result);

            }



        }
        // exercice 5-1
        static void affichage()
        {
            string toDisplay = "mes couilles sont poilues";

            foreach (var car in toDisplay)
            {
                Console.WriteLine(car);
            }
        }

        // exercice 5-2
        static void Extraction()
        {
            string t = "hello world";
            int index_1;
            int index_2;
            int i = 0;

            do
            {
                Console.WriteLine("index 1 ?");
            } while (!int.TryParse(Console.ReadLine(), out index_1));

            do
            {
                Console.WriteLine("index 2 ?");
            } while (!int.TryParse(Console.ReadLine(), out index_2));

            while (i <= (index_2 - index_1))
            {
                Console.Write(t[index_1 + i]);
                i++;

            }


        }

        // exercice 5-3
        static void ExtractionBis()
        {

            string t;

            Console.WriteLine("quelle est votre phrase ? ");
            t = Console.ReadLine();

            string u;
            int index_1;
            int index_2;
            StringBuilder sb;


            do
            {
                Console.WriteLine("index 1 ?");
            } while (!int.TryParse(Console.ReadLine(), out index_1));

            do
            {
                Console.WriteLine("index 2 ?");
            } while (!int.TryParse(Console.ReadLine(), out index_2));


            sb = new StringBuilder("", index_2);

            for (int i = index_1; i < index_2; i++)
            {
                sb.Insert(i - index_1, t[i]);
            }


            Console.WriteLine(sb);

        }

        // exercice 5-4
        static void Replace()
        {
            string t;
            char a = 'a';
            char b = 'b';

            Console.WriteLine("Saisissez une chaine de caractère :");
            t = Console.ReadLine();

            string s = t.Replace(b, a);

            Console.WriteLine("Votre nouvelle chaine de caractère : " + s);
        }

        // exercice 5-5 
        static void SubWithoutReplace()
        {
            string t;
            StringBuilder sb;
            int l;
            char a = 'a';
            char b = 'b';

            Console.WriteLine("Saisissez une phrase");
            t = Console.ReadLine();

            sb = new StringBuilder(t);
            l = sb.Length;

            for (int index = 0; index < l; index++)
            {
                if (sb[index] == a)
                {
                    sb.Remove(index, 1);
                    sb.Insert(index, b);
                }
            }

            Console.WriteLine(sb);
        }

        // Exercice 6 
        static void getExtension()
        {
            string str = "hello.zip";
            string substr;
            char car = '.';
            bool find = false;
            int index;
            int splitIndex = 0;

            index = str.Length - 1;

            while (index > 0 && !find)
            {
                if (str[index] == car)
                {
                    find = true;
                    splitIndex = index;
                } else
                {
                    index--;
                }
                

            }

            substr = str.Substring(splitIndex + 1, str.Length - splitIndex - 1);

            Console.WriteLine(substr);
        }

        // test array 

        static void testArray()
        {
            List<int> test = new List<int>();

            void inPlace(List<int> testFunction)
            {
                testFunction.Add(5);
            }

            Console.WriteLine(test.Count);
            inPlace(test);
            Console.WriteLine(test[0]);

        }


        // exercice 6-1-1
        // 'a', 'R', 'k', 'J'
        // 'b', 'S', 'l', 'K'

        // exercice 6-2 Prise en main
        static void affichageArray()
        {
            int[] myTab = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

            foreach( var item in myTab)
            {
                Console.WriteLine(item);
            }
        }

        // exercice 6-5
        static void initArray()
        {
            int[] myArray = new int[10];

            for( int index = 0; index < myArray.Count(); index ++ )
            {
                myArray[index] = index + 1;
            }

        }

        // exercice 6 - 6 
        static void ArraySum()
        {
            int[] myArray = { 4, 5, 11 };
            int sum = 0;

            // Console.WriteLine(myArray.Sum());

            foreach( var item in myArray)
            {
                sum += item;
            }
        }

        // exercice 6 - 7 
        static void InArray()
        {
            int[] myArray = { 10, 15, 2 };
            int input;

            do
            {
                Console.WriteLine("Entrez un nombre");
            } while (int.TryParse(Console.ReadLine(), out input));

            Console.WriteLine(myArray.Contains(input) ? " Nombre trouvé " : "non trouvé");
        }

        // exercice 6 - 8 permutation circulaire
        static void Circulaire()
        {
            int[] tab1 = { 1, 2, 3, 4, 5 };
            int[] tab2 = new int[5];

            for ( int index = 0; index < tab1.Count(); index ++)
            {
                if(index == 0)
                {
                    tab2[index] = tab1[tab1.Count() - 1];
                } else
                {
                    tab2[index] = tab1[index - 1];
                }
                
            }

            foreach( var item in tab2)
            {
                Console.WriteLine(item);
            } 
        }

        // exercice 6-9 permutation circulaire sans tableau 
        static void Circulaire2()
        {
            int[] tab1 = { 1, 2, 3, 4, 5 };
            // 5 2 3 4 5
            // 
            int tampon;
            int t;
            int u;

            tampon = tab1[tab1.Count() - 1];
            for (int index = tab1.Count() - 1; index > 0 ; index --)
            {
                tab1[index] = tab1[index - 1];
                
            }
            tab1[0] = tampon;
            foreach (var item in tab1)
            {
                Console.WriteLine(item);
            }
        }

        // exercice 6-10 Miroir 
        static void Mirror()
        {
            int[] tab = { 1, 2, 3, 4, 5, 6 };
            int middle;
            int tampon;

            // SI le tableau n'est pas pair 
            
            
            middle = Convert.ToInt32(Math.Floor((double)tab.Count() / 2));
            for( int index = 0 ; index < middle ; index ++ )
            {
                tampon = tab[index];
                tab[index] = tab[tab.Count() - 1 - index];
                tab[tab.Count() - 1 - index] = tampon;
            }
           

            foreach(var item in tab)
            {
                Console.WriteLine(item);
            }
        }



        // exercice 11-12-13 Modification tableau
        static void ModifArray()
        {
            double[] myArray = new double[20];
            double a;

            for ( int index = 0; index < myArray.Count(); index ++)
            {
                myArray[index] = (Math.Pow(index, 2)) % 17;
            }

            // 
            Console.WriteLine("Minimum : " + myArray.Min());
            Console.WriteLine("Maximum : " + myArray.Max());

            do
            {
                Console.WriteLine("Entrez un nombre");
            } 
            while( !double.TryParse(Console.ReadLine(), out a));

            for ( int index = 0; index < myArray.Count(); index ++)
            {
                if(myArray[index] == a)
                {
                    Console.WriteLine("indices : " + index);
                }
            }

        }

        // exercice 15 




        /**
         * regex  
         * 
         * 1 - chercher les multiplicateurs
         * 2 - les parenthèses
         * 3 - les crochets auquels ils se rapportent
         * 4 - * 0 ou 1
         * 5 - + 1 ou +, mais à cette position
         * 6 - *? au moins 1 
         * 7 - number : il en faut le number,   number, au moins number,    ,number : au plus regex.  
         * 5 - ? : 0 ou 1 
         * 
         * 
         * 
         * 
         * 
         */



        static void Main(string[] args)
        {
            // double surface = 0;

            // Console.WriteLine("Hello World");

            // surface = calculSurface(5, 7);

            // Console.WriteLine("La surface est de : " +  surface + " m2");

            // unicode();

            // calculMonnaie();

            // majorite(14);

            // valeurAbsolue(-14);

            // admissions(8);

            // Assurance(40000);

            // ValeursDistinctes();

            // echiquier();

            // cavalier(3, 3, 4, 1);

            // Tour(2, 3, 4, 2);

            // Console.WriteLine(Queen(2, 4, 3, 3));

            // heureEtDate();

            // calculDate();

            // borne();

            // rectangles();

            // Console.WriteLine(factorielle(4));
            // Cab(9);

            // multiplication();

            // Multiplication2d();

            // JoliCarre();

            // Calculatrice();

            // affichage();

            // Extraction();

            // ExtractionBis();

            // Replace();

            // SubWithoutReplace();

            // getExtension();

            // testArray();

            // ArraySum();

            // Circulaire();

            // Circulaire2();

            // Mirror();

            ModifArray();
        }
    }

    
}
