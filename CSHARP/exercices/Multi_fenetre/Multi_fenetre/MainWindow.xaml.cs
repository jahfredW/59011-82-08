using Microsoft.VisualBasic;
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

namespace Multi_fenetre
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

        private void Open_Window(object sender, RoutedEventArgs e)
        {
            string test = "hello from parent";
            Fenetre2 f = new Fenetre2(this, test);

            f.Show();

            lbl_Message.Content = f.MessageToParent;

            
        }

        public void Show_Message(string mot)
        {
            lbl_Message.Content = mot;
        }
    }
}
