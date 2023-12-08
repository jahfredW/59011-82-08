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
using WpfAvecScaffold.Models.DTOs;
using WpfAvecScaffold.Models.Data;
using WpfAvecScaffold.Controllers;
using WpfAvecScaffold.Models;

namespace WpfAvecScaffold
{
    /// <summary>
    /// Logique d'interaction pour Details.xaml
    /// </summary>
    public partial class Details : Window
    {
        private MainWindow _mainWindow;
        private DronesDTOOut _drone;
        private string _mode;
        private DronesController _dronesController;
        private TypeDronesController _typeDronesController;
        private DronesDbContext _dbContext;



        public Details(MainWindow mw, DronesDTOOut drone, string mode, DronesDbContext context)
        {
            InitializeComponent();
            _mainWindow = mw;
            _mode = mode;
            _drone = drone;
            _dbContext = context;
            _dronesController = new DronesController(context);
            _typeDronesController = new TypeDronesController(context);
            cbo_Type.ItemsSource = _typeDronesController.GetAllTypeDrones();

            // On met à jour les champs au chargement de la page 
            FillInForm(_drone);

        }

        private void FillInForm(DronesDTOOut drone)
        {
            if( _mode != "Ajouter" )
            {
                txt_Nom.Text = drone.Nom;
                txt_Prix.Text = drone.Prix.ToString();
                cbo_Type.SelectedValue = drone.LeTypeDeDrone;
            }
            
        }

        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            // récupérer les infos de la BDD pour créer un DTOIn


            DronesDTOIn droneDTOIn = new DronesDTOIn();


            droneDTOIn.Nom = txt_Nom.Text;
            droneDTOIn.Prix = Convert.ToDecimal(txt_Prix.Text);

            

            // récupération de l'id du type de Drone
            int idTypeDrone = _typeDronesController.GetTypeDroneByName(cbo_Type.Text);
            droneDTOIn.IdTypeDrone = idTypeDrone;


            // Utiliser un controller pour update en BDD
            _dronesController.UpdateDrone(_drone.IdDrone, droneDTOIn);
            
        }
    }
}
