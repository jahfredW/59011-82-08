using gestionCrudBonnesPratiques.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace gestionCrudBonnesPratiques
{
    /// <summary>
    /// Logique d'interaction pour Details.xaml
    /// </summary>
    public partial class Details : Window
    {
        public string Mode { get; set; }
        public Details(Product p, MainWindow mw, string mode)
        {
            InitializeComponent();
            Mode = mode;
            // Remplissage des champs lors de la construction
            // Pas obligé d'écouter l'evt Loaded
            FillInForm(p);
        }

        private void FillInForm(Product p)
        {
            if(Mode != "ajouter")
            {
                libelleProduit.Text = p.Name;
                numeroProduit.Text = p.Serial;
                dateProduit.Text = p.Date.ToString();
                desriptionProduit.Text = p.Description;
                // categorieProduit = p.Category.ToString();

            }
            else
            {
                idProduit.Content = "0";
            }

        }
    }
}
