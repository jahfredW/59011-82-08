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
using System.Collections.ObjectModel;

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
            DataContext = new ObservableCollection<ProductsDTOout>(getListeProducts());


        }

        // public List<ProductsDTOout> DataContext { get; private set; }

        public ObservableCollection<ProductsDTOout> DataContext { get; private set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDatas();
            // Réinitialiser le SelectedItem à null

        }

        /// <summary>
        /// Permet de loader les première FAKE DATAS si la BDD est vierge. 
        /// </summary>
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

        /// <summary>
        /// Ecoute sur la dataGrid afin de procéder au chargement de ses éléments. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void load_Item(object sender, RoutedEventArgs e)
        {
            // Cast direct : récupération du sender et cast en DataGrid. 
            // De base le sender est de type générique Object
            //DataGrid datagrid = (DataGrid)sender;

            // as-cast: 
            DataGrid dataGrid = sender as DataGrid;

            // Vérifiez si des éléments sont sélectionnés dans la DataGrid
            if (dataGrid.SelectedItems.Count > 0)
            {
                // Activez le bouton
                btn_update.IsEnabled = true;
                btn_delete.IsEnabled = true; ;
            }
            else
            {
                // Désactivez le bouton
                btn_update.IsEnabled = false;
                btn_delete.IsEnabled = false;
            }




            ProductsDTOout p = dataGrid.SelectedItem as ProductsDTOout;

            txt_Name.Text = p.Name;
            txt_Description.Text = p.Description;
            txt_Serial.Text = p.Serial;
            txt_Date.Text = p.Date.ToString();

            Console.Write(p.Id);

        }

        /// <summary>
        /// Bouton update : Appel de la sous fenêtre lors de la mise à jour 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            ProductsDTOout p = dtg_products.SelectedItem as ProductsDTOout;

            // attribution des inputs ) l'objet 
            Details details = new Details(this, p);

            this.Opacity = 0.7;

            details.ShowDialog();

            this.Opacity = 1;

            // dtg_products.SelectedItem = null;

            // Mise à jour des champs après la fermeture de la sous-fenêtre
            txt_Name.Text = p.Name;
            txt_Description.Text = p.Description;
            txt_Serial.Text = p.Serial;
            txt_Date.Text = p.Date.ToString();

            //p.Name = txt_Name.Text;
            //p.Description = txt_Description.Text;
            //p.Serial = txt_Serial.Text;
            //p.Date = Convert.ToDateTime(txt_Date.Text);

            Console.Write(p.Id);
        }



        /// <summary>
        /// Mets à jours les champs du parent à partir de l'enfant.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="serial"></param>
        /// <param name="date"></param>
        public void UpdateFields(string name, string description, string serial, string date)
        {
            txt_Name.Text = name;
            txt_Description.Text = description;
            txt_Serial.Text = serial;
            txt_Date.Text = date;
        }


        /// <summary>
        /// Méthode d'appel du formulaire pour une création 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_create_Click(object sender, RoutedEventArgs e)
        {
            ProductsDTOin p = dtg_products.SelectedItem as ProductsDTOin;

            // attribution des inputs ) l'objet 
            Details details = new Details(this, null);

            this.Opacity = 0.7;

            details.ShowDialog();

            this.Opacity = 1;

            // dtg_products.SelectedItem = null;

            // Mise à jour des champs après la fermeture de la sous-fenêtre
            //txt_Name.Text = p.Name;
            //txt_Description.Text = p.Description;
            //txt_Serial.Text = p.Serial;
            //txt_Date.Text = p.Date.ToString();

            //if (p != null)
            //{
            //    p.Name = txt_Name.Text;
            //    p.Description = txt_Description.Text;
            //    p.Serial = txt_Serial.Text;
            //    p.Date = Convert.ToDateTime(txt_Date.Text);

            //}
            //else
            //{
            //    p = new ProductsDTOin(txt_Name.Text, txt_Description.Text, txt_Serial.Text, Convert.ToDateTime(txt_Date.Text), 1);
            //}

            // Console.Write(p.Id);



            // _controller.CreateProduct(p);

            // récupération de la liste des produits 
            //getListeProducts();

            // chargement de la nouvelle datagrid
            //LoadDatas();

        }

        /// <summary>
        /// Méthode de suppression d'un élément
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            ProductsDTOout d = dtg_products.SelectedItem as ProductsDTOout;
            _controller.DeleteProduct(d.Id);
        }



        /// <summary>
        /// Sauvegarde ; mise à jour de l'élément sélectionné OU création
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            // récupération d'un DTO out du dataGrid
            ProductsDTOout p = dtg_products.SelectedItem as ProductsDTOout;

            // SI il existe, alors on update en BDD 
            if (p != null)
            {
                p.Name = txt_Name.Text;
                p.Description = txt_Description.Text;
                p.Serial = txt_Serial.Text;
                p.Date = Convert.ToDateTime(txt_Date.Text);
                _controller.UpdateProduct(p.Id, p);

            }
            // Sinon instanciation d'un DTO in est création d'un élement en BDD ( data.json). 
            else
            {
                
                ProductsDTOin d = new ProductsDTOin(txt_Name.Text, txt_Description.Text, txt_Serial.Text, Convert.ToDateTime(txt_Date.Text), 1);
                _controller.CreateProduct(d);
            }

        }




    }
}