using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestionCrud.Models.DTOs
{
    public class ProductsDTOout
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string Serial { get; set; }

        public DateTime Date { get; set; }
    }

    public class ProductsDTOin
    {
        //public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string Serial { get; set; }

        public DateTime Date { get; set; }
    }
}
