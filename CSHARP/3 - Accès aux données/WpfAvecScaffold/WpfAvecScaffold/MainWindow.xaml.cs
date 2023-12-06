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

    }
}
