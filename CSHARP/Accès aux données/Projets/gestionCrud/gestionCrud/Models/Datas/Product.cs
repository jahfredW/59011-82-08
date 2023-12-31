﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace gestionCrud.Models.Datas
{
    public class Product : IEntity
    {
        public Product(int id, string name, string description, string serial, DateTime date, Category category)
        {
            Id = id;
            Name = name;
            Description = description;
            Serial = serial;
            Date = date;
            Category = category;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public string Serial {  get; set; }

        public DateTime Date { get; set; }

        public Category Category  { get; set; }
    }
}
