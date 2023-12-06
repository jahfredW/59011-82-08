using gestionCrud.Models.Datas;
using gestionCrud.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using gestionCrud.Controllers;
using System.Diagnostics;


namespace gestionCrud
{
    /// <summary>
    /// Logique d'interaction pour Details.xaml
    /// </summary>
    public partial class Details : Window
    {
        public MainWindow Mw;
        public string Data {  get; set; }

        private ProductsController _controller;
        private CategoriesController _categoriesController;

        public ProductsDTOout Product {  get; set; }
        
        
        /// <summary>
        /// Constructeur 
        /// </summary>
        /// <param name="mainWindow">Instance de la fenêtre parent</param>
        /// <param name="product"></param>
        public Details(MainWindow mainWindow, ProductsDTOout? product)
        {
            
            InitializeComponent();

            _controller = new ProductsController();
            _categoriesController = new CategoriesController();

            // récupération de la liste des catégories 
            List<CategoriesDTOout> categoryList = _categoriesController.GetAllCategories();

            Mw = mainWindow;

            // alimentation de la comboBox
            cbo_cat.ItemsSource = categoryList;
            

            if(product != null)
            {
                Product = product;
                txt_Name1.Text = product.Name;
                txt_Description1.Text = product.Description;
                txt_Serial1.Text = product.Serial;
                txt_Date1.Text = product.Date.ToString();

            }

        }

        public void Btn_update_Click1(object sender, RoutedEventArgs e) 
        {
            if(Product != null)
            {
                Product.Name = txt_Name1.Text;
                Product.Description = txt_Description1.Text;
                Product.Serial = txt_Serial1.Text;
                Product.Date = Convert.ToDateTime(txt_Date1.Text);
                Product.Category.Name = cbo_cat.Text;
            } 
            else
            {
                Mw.UpdateFields(txt_Name1.Text, txt_Description1.Text, txt_Serial1.Text, txt_Date1.Text, cbo_cat.Text);
            }
            

            this.Close();
        }

       
   



    }
}
