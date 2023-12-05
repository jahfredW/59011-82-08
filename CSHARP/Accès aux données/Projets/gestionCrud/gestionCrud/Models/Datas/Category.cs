using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestionCrud.Models.Datas
{
    public class Category : IEntity
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
        public virtual ICollection<Product> ProductList { get; set;}
    }
}
