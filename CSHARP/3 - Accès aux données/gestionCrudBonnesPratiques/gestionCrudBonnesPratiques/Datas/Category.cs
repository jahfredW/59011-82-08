using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace gestionCrudBonnesPratiques.Datas
{
    public class Category
    {
        public Category(int id, string name, string description, DateTime date, ICollection<Product> productList)
        {
            Id = id;
            Name = name;
            Description = description;
            Date = date;
            ProductList = productList;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime Date { get; set; }
        public virtual ICollection<Product> ProductList { get; set; }
    }
}
