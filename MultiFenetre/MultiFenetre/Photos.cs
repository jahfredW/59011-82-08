using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiFenetre
{
    internal class Photos
    {
        public Photos(int id, string name, DateTime date)
        {
            Id = id;
            Name = name;
            Date = date;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}
