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
using WpfAvecScaffold.Controllers;
using WpfAvecScaffold.Models;
using WpfAvecScaffold.Models.DTOs;

namespace WpfAvecScaffold
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DronesDbContext _context;
        private DronesController _controller;
        public MainWindow()
        {
            InitializeComponent();
            _context = new DronesDbContext();
            _controller = new DronesController(_context);
            test.ItemsSource = _controller.GetAllDrones();
            
        }

        private void Action_Click(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).Name == "btn_Add") {
                string mode = (string)((Button)sender).Content;
                // Ajouter un Drone : Créer un nouveau Drone 
                DronesDTOOut drone = new DronesDTOOut();
                // passe la drone à la fenêtre de l'enfant 
                Details detailsWindow = new Details(this, drone, mode) ;

                detailsWindow.ShowDialog();


                
                
            } 
            else if (((Button)sender).Name == "btn_Update")
            {
                // Mettre à jour un Drone
                string mode = (string)((Button)sender).Content;
                // Ajouter un Drone : Créer un nouveau Drone 
                DronesDTOOut drone = test.SelectedItem as DronesDTOOut;
                // passe la drone à la fenêtre de l'enfant 
                Details detailsWindow = new Details(this, drone, mode);

                detailsWindow.ShowDialog();

            }
            else
            {
                // Supprimer un Drone

            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            // Effectuer l'action de suppression -> 
        }

    }
}
