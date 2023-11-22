using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace space_invader
{
    internal class Invader
    {
        public Invader(char motif)
        {
            Motif = motif;
        }

        public char Motif { get; set; } = '#';
        public int PositionX { get; set; }
        public int PositionY { get; set; }

        public override string ToString()
        {
            return Convert.ToString(Motif);
        }
    }
}
