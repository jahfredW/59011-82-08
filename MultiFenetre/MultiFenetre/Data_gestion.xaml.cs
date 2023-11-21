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

namespace MultiFenetre
{
    /// <summary>
    /// Logique d'interaction pour Data_gestion.xaml
    /// </summary>
    public partial class Data_gestion : Window
    {
        public Data_gestion()
        {
            InitializeComponent();
            PhotosList = PhotosManager.getAll();
            dtg_Photos.ItemsSource = PhotosList;
            

        }

        private List<Photos> PhotosList { get; set; }

        private List<Photos> BuildPhotos()
        {
            List<Photos> listePhotos = new List<Photos>();
            for (int index = 0; index < 10; index++)
            {
                Photos p = new Photos(index, "Photos" + index, new DateTime());
                listePhotos.Add(p);
            }

            return listePhotos;

        }

        private void dtg_Photos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // ((DataGrid)sender).SelectedItem.Dump();
                 dtg_Photos.ItemsSource =  PhotosManager.getAll();

            
        }
    }
}
