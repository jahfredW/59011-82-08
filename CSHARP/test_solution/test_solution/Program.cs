using System;
using System.Reflection.Metadata.Ecma335;
using tests;

namespace tests
{
    internal class MainClass
    {

        static void Main(string[] args)
        {
            Losange(25);
        }


        public static void Losange(int longueur )
        {
            double middle = Math.Floor(Convert.ToDouble(longueur) / 2);
            double indexFlotant = 0;

            // partie haute du losange
            for (int i = 0; i <= longueur; i++)
            {
                DrawTwoPixels(middle - indexFlotant, middle + indexFlotant, longueur);
                
                if(i < middle)
                {
                    indexFlotant++;
                } else
                {
                    indexFlotant--;
                }
                
            }
        }

        public static void Cross(int longueur)
        {
            double middle = Math.Floor(Convert.ToDouble(longueur) / 2);
            double indexFlotant = 0;

            // partie haute du losange
            for (int i = 0; i <= longueur; i++)
            {
                DrawTwoPixels(middle - indexFlotant, middle + indexFlotant, longueur);

                if (i <= middle)
                {
                    indexFlotant++;
                }
                else
                {
                    indexFlotant--;
                }

            }
        }


        public static void DrawCarre(int number)
        {
            for( int i = 0; i < number; i++ )
            {
                if( i == 0 || i == number - 1 ) {
                    DrawLine(number);
                 
                }
                else
                {
                    for (int j = 0; j < number; j++)
                    {
                        if (j == 0 || j == number - 1)
                        {
                            DrawOnePixel();
                        }
                        else
                        {
                            DrawOneSpace();
                        }
                    }
                }

                
                Console.WriteLine();
            }
        }

        public static void DrawLine( int longueur )
        {
            for( int i = 0; i < longueur; i++ ) 
            {
                Console.Write("*");
            }
        }

        public static void DrawTwoPixels(double a, double b, int longueur)
        {
            for (int j = 0; j <= longueur; j++)
            {
                if(j == a || j == b)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine();

        }

        public static void GoToLine()
        {
            Console.WriteLine();
        }

        public static void DrawPixel(int longueur)
        {
            for(int i = 0; i < longueur; i++ )
            {
                Console.Write("*");
            }
            
        }

        public static void DrawOnePixel()
        {
            Console.Write("*");
        }

        public static void DrawOneSpace()
        {
            Console.Write(" ");
        }


        
    }


    
}
