using gestionCrudBonnesPratiques.Datas;
using gestionCrudBonnesPratiques.Services;
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

namespace gestionCrudBonnesPratiques
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FillGrid();
            
        }

        // Méthode de remplissage de la grid
        private void FillGrid()
        {
            dtgProduits.ItemsSource = ProductsService.getAllProducts();
        }

        // méthode d'action des boutons
        private void btnActionClick(object sender, RoutedEventArgs e)
        {
            Product item;
            // test du bouton qui a été cliqué
            if(((Button)sender).Name == "btnAjouter")
            {
                item = new Product();
            }
            else
            {
                item = dtgProduits.SelectedItem as Product;
            }

            // instanciation de la fenêtre de détails : 

            Details detailWindow = new Details(item, this, (string)((Button)sender).Content);

            detailWindow.ShowDialog();
        }

        private void Row_DoubleClick(object sender, RoutedEventArgs e)
        {
           btnActionClick(sender, e);
        }
    }
}