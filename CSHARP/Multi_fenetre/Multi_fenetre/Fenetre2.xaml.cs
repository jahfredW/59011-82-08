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

namespace Multi_fenetre
{
    /// <summary>
    /// Logique d'interaction pour Fenetre2.xaml
    /// </summary>
    public partial class Fenetre2 : Window
    {
        public Fenetre2(MainWindow main, string test)
        {
            Mw = main;
            InitializeComponent();
            lbl_Message.Content = test;
        }

        public MainWindow Mw { get; set; }
        public string MessageToParent { get; set; } 


        private void Tbx_Changed(object sender, TextChangedEventArgs e)
        {
            MessageToParent = tbx_Message.Text;
        }
    }
}
