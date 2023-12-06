using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;
using gestionCrud.Models.Datas;
using gestionCrud.Models.DTOs;


namespace gestionCrud.Models.DTOs
{
    public class ProductsDTOout : INotifyPropertyChanged
    {
        private string _name;
        private string _description;
        private string _serial;

        public ProductsDTOout(int id, string name, string description, string serial, DateTime date, CategoriesDTOout category)
        {
            Id = id;
            Name = name;
            Description = description;
            Serial = serial;
            Date = date;
            Category = category;
        }

        public CategoriesDTOout Category { get; set; }
        public int Id { get; set; }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string Description {
            get
            {
                return _description;
            } 
             set {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public string Serial
        {
            get => _serial;
            set
            {
                _serial = value;
                OnPropertyChanged(nameof(Serial));
            }
        }

        public DateTime Date { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class ProductsDTOin
    {
        public ProductsDTOin(string name, string description, string serial, DateTime date, CategoriesDTOout category)
        {
            Name = name;
            Description = description;
            Serial = serial;
            Date = date;
            Category = category;
        }

        // public int Id { get; set; }
        public string Name {  get; set; }
        public string Description {  get; set; }
        public string Serial { get; set; }
        public DateTime Date { get; set; }
        public CategoriesDTOout Category { get; set; }
        


    }











    //public class ObservableObject : INotifyPropertyChanged
    //{


    //    //public int Id { get; set; }
    //    //public string Name { get; set; }
    //    //public string Description { get; set; }
    //    //public string Serial { get; set; }
    //    //public DateTime Date { get; set; }

    //    // déclaration de l'evt d'écoute
    //    public event PropertyChangedEventHandler PropertyChanged;

    //    // méthode qui implémente le comportement de PropertyChanged
    //    protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
    //    {
    //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
    //    }

    //    protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
    //    {
    //        if (!EqualityComparer<T>.Default.Equals(field, value))
    //        {
    //            field = value;
    //            OnPropertyChanged(propertyName);
    //            return true;
    //        }
    //        return false;
    //    }


    //}


    //public class ProductsDTOout : 
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public string Description { get; set; }
    //    public string Serial { get; set; }
    //    public DateTime Date { get; set; }
    //}


}
