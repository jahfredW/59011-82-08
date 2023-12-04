using gestionCrud.Controllers;
using gestionCrud.Models.Services;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Net.Http.Json;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using gestionCrud.Models;
using gestionCrud.Models.DTOs;
using gestionCrud.Models.Datas;

namespace gestionCrud
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private ProductsController _controller;
        public MainWindow()
        {
            InitializeComponent();
            _controller = new ProductsController();
            DataContext = getListeProducts();
            
            
        }

        public List<ProductsDTOout> DataContext { get; private set; }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDatas();
        }

        private void LoadDatas()
        {
            // récupération de la liste des objets 
            // ObjectBuilder.productBuilder();

            // récupération des datas en bdd :
  
            //ProductsController p = new ProductsController();

            //List<ProductsDTOout> listeproducts = p.GetAllProducts();


            dtg_products.ItemsSource = DataContext;
        }

        private List<ProductsDTOout> getListeProducts()
        {
            

            List<ProductsDTOout> listeproducts = _controller.GetAllProducts();

            return listeproducts;
        }

        private void test_click(object sender, RoutedEventArgs e)
        {
            ProductsDTOout p = dtg_products.SelectedItem as ProductsDTOout;
           
            txt_Name.Text = p.Name;
            txt_Description.Text = p.Description;
            txt_Serial.Text = p.Serial;
            txt_Date.Text = p.Date.ToString();

            Console.Write(p.Id);

        }

        private void btn_update_Click(object sender, RoutedEventArgs e) 
        {
            ProductsDTOout p = dtg_products.SelectedItem as ProductsDTOout;

            // attribution des inputs ) l'objet 
            
            p.Name = txt_Name.Text;
            p.Description = txt_Description.Text;
            p.Serial = txt_Serial.Text;
            p.Date = Convert.ToDateTime(txt_Date.Text);

            Console.Write(p.Id);

            

            _controller.UpdateProduct(p.Id, p);

            // récupération de la liste des produits 
            getListeProducts();

            // chargement de la nouvelle datagrid
            LoadDatas();
            
            
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            ProductsDTOout d = dtg_products.SelectedItem as ProductsDTOout;
            _controller.DeleteProduct(d.Id);
        }
    }
}