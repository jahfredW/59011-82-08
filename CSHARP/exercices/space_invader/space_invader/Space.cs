using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace space_invader
{
    internal class Space
    {
        public Space(int lignes, int colonnes) {
            NbColonnes = colonnes;
            NbLignes = lignes;
            Grille = new List<List<char>>();
            Canon = new Canon('╩');
         
            this.gridInit();
            
        
        }

        public int NbLignes { get; set; }
        public int NbColonnes { get; set; }
        public List<List<char>> Grille { get; set;}
        public Canon Canon { get; set; }

        public List<Invader> InvaderList { get; set; } = new List<Invader>();

        public void gridInit()
        {
            for (int lignes = 0;  lignes < NbLignes + 4; lignes ++)
            {
                List<char> list = new List<char>();
                Grille.Add(list);
                for ( int colonnes = 0; colonnes < NbColonnes + 4; colonnes ++)
                {
                    char cell = ' ';
                    if(lignes == 0)
                    {
                        
                        if(colonnes == 0)
                        {
                            cell = '┌';
                            
                        } else if ( colonnes == NbColonnes + 3)
                        {
                            cell = '┐';
                        } 
                        else
                        {
                            cell = '─';
                        }
                        list.Add(cell);



                    }
                    else if(lignes == 1 & colonnes > 1 && colonnes < NbColonnes + 2)
                    {
                        // instanciation d'un nouvel invader
                        Invader invader = new Invader('#');

                        // passages de coordonnées au invaders
                        invader.PositionX = colonnes;
                        invader.PositionY = lignes;

                        InvaderList.Add(invader);

                        // ajout des motif des invader dans la grille 
                        list.Add(Convert.ToChar(invader.ToString()));
                    } 

                    else if( lignes == NbLignes + 3)
                    {
                        if (colonnes == 0)
                        {
                            cell = '└';
                        }
                        else if (colonnes == NbColonnes + 3)
                        {
                            cell = '┘';
                        }
                        else
                        {
                            cell = '─';
                        }
                        list.Add(cell);
                    }
                    

                    else if ( colonnes == 0 || colonnes == NbColonnes + 3 ) 
                    {
                        cell = '|';
                        list.Add(cell);
                    }
                    else
                    {
                        if(colonnes == 3 && lignes == NbLignes + 2)
                        {
                            list.Add(Convert.ToChar(Canon.Motif));
                            Canon.Position[0] = lignes;
                            Canon.Position[1] = colonnes;
                        } else
                        {
                            list.Add(cell);
                        }
                        
                    }
                    

                }
            }
        }

        public void display()
        {
            foreach( var item in Grille)
            {
                foreach ( var item2 in item)
                {
                    Console.Write(item2);
                }
                Console.WriteLine();
            }
        }

        public void tirer()
        {
            char missile = '^';
            int departY = NbLignes - 1;

            // tant que le missile n'a pas touché un alien 
            
            while ( departY > 0 )
            {
                // clear de la console
                Console.Clear();

                // redéfinition de la position du missile
                Grille[departY][Canon.Position[1]] = missile;

                // missile bouge vers le haut 
                departY --;
                
                // affichage 
                this.display();

                // sleep pour effet de latence 
                Thread.Sleep(100);
                
                // La cellule arrière se vide  
                Grille[departY + 1][Canon.Position[1]] = ' ';

                
                Grille[Canon.Position[0]][Canon.Position[1]] = Canon.Motif;
            }

        }

         public void Deplacer(ConsoleKey key)
         {
            Grille[Canon.Position[0]][Canon.Position[1]] = ' ';
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    if (Canon.Position[1] > 2) Canon.Position[1]--;

                    
                    break;
                case ConsoleKey.RightArrow:
                    if (Canon.Position[1] < NbColonnes + 1) Canon.Position[1]++;
                    break;

                case ConsoleKey.Spacebar:
                    this.tirer();
                    break;
                
            }

            // on change au niveau de la grille
            Grille[Canon.Position[0]][Canon.Position[1]] = Canon.Motif;

          }

        public async Task InvaderMove()
        {
            
            // Définir un mouvement horizontal
            foreach( var invader in InvaderList)
            {
       
                // ajout +1 à la position de X 
                invader.PositionY += 1;
              
                // affichage 
                Console.Clear();
                Grille[invader.PositionX][invader.PositionY] = invader.Motif;


                this.display();

                await Task.Delay(200);

            }
        }



    }
}
