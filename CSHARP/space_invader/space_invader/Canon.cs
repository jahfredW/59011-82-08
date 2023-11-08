using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace space_invader
{
    internal class Canon
    {
        public Canon(char motif )
        {
            Motif = motif;
            
        }

        public char Motif { get; set; } = '╩';
        public int[] Position { get; set; } = new int[2];

       

        
        

    }
}
