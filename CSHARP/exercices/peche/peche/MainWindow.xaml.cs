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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace peche
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<Operation> operation = new List<Operation>();

            operation.Add(new Operation("erge", "erge", "iu", "uik", "eytj", "test"));

            testGrid.ItemsSource = operation;
        }

        public class Operation
        {
            public Operation(string caracteristique, string valeur, string unite, string support, string fraction, string methode)
            {
                Caracteristique = caracteristique;
                Valeur = valeur;
                Unite = unite;
                Support = support;
                Fraction = fraction;
                Methode = methode;
            }

            public string Caracteristique { get; set; }
            public string Valeur { get; set; }
            public string Unite { get; set; }
            public string Support { get; set; }
            public string Fraction { get; set; }
            public string Methode { get; set; }
        }
    }

   
}
