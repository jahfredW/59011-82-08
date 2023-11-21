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

namespace MultiFenetre
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string code = "toto";
            // Fenetre2 f2 = new Fenetre2(this,code);
            Data_gestion d = new Data_gestion();
            code.Dump();
            this.Opacity = 0.7;
            d.ShowDialog();
            this.Opacity = 1;
            // lblTitre.Content = f2.MotARecuperer; 


        }
        public void appelF2(string mot)
        {
            lblTitre.Content = mot;
        }

    }
}
