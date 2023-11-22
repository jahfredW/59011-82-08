using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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
using System.Xml.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.RegularExpressions;

namespace Calculatrice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            lblAfficheur.Content = "";

            // On définit un total qui sera mis à jour à chaque fois qu'un
            // opérateur sera cliqué
            Total = 0;
            Contents = "";
            
        }

        public double Total {  get; set; }
        public string Contents { get; set; }
        


        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //Faire apparaitre les tailles dans la sortie
            ((Window)sender).ActualHeight.Dump();
            ((Window)sender).ActualWidth.Dump();

            ((Window)sender).Height=4/3* ((Window)sender).ActualWidth; // garder les proportions



        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
           

            // on regarde si présence d'un opérateur avant la virgule
            string[] myArray = { "+", "-", "/", "*" };


            // caractère d'entrée
            string entry;

            entry = (string)((Button)sender).Content;

            bool isInArray = myArray.Contains(entry);


            if (entry == ",")
            {
                if (sender is Button)
                {
                    btnVirgule.IsEnabled = false;
                }

            }
            else if (isInArray)
            {

                btnVirgule.IsEnabled = true;
            }

            lblAfficheur.Content += (string)((Button)sender).Content;
            Contents += entry;

        }


        private void submit_Click(object sender, RoutedEventArgs e)
        {
            // parser la chaine de caractère.
            // pour cela on va spliter et récupérer les caractères 

            string output = Contents;
            List<double> subArrayOfNumbers =  new List<double>();
            List <char> subArrayOfOperators = new List<char>();
            int indexOfChar;
            string extracted;

            // le offset est le nouvel index de départ
            int offset = 0;

            int lastIndex = 0;

            char[] myArray = { '+', '-', '/', '*' };

            for( int index = 0; index < output.Length; index++ )
            {
                if (myArray.Contains(output[index]))
                {
                    indexOfChar = index;
                    extracted = output.Substring(offset, indexOfChar-offset);

                    // on met l'offset à indexOfChar
                    offset = indexOfChar + 1;

                    // on alimente les tableaux
                    double extractedToDouble;
                    if (double.TryParse(extracted, out extractedToDouble))
                    {
                        subArrayOfNumbers.Add(extractedToDouble);
                        subArrayOfOperators.Add(output[index]);
                    }

                    lastIndex = index;

                }

                else if(index == output.Length - 1) 
                {
                    extracted = output.Substring(lastIndex+1);
                    subArrayOfNumbers.Add(Convert.ToDouble(extracted));
                }

                
            }

            // on effectue le calcul
            makeOperation(subArrayOfNumbers, subArrayOfOperators);




        }

        // effectue l'opération de calcul
        // prends la liste des nombres et la liste des opérateurs
        private void makeOperation(List<double> numberList, List<char> operatorList)
        {
            
            // conversion des listes en Array
            double[] numberTabArray = numberList.ToArray();
            char[] operatorTabArray = operatorList.ToArray();

            // affectation du premier nombre à la propriété Total 
            Total = numberTabArray[0];

            // Itération sur les nombres et les opérateurs
            for (int index = 1 ; index < numberTabArray.Length; index++) 
            {
                Total = operationTable(Total, numberTabArray[index], operatorTabArray[index - 1]);
            }

            // mise à jour de label
            lblAfficheur.Content = Total;



        }

        private double operationTable(double number1, double number2, char operator1)
        {
            double result = 0;

            switch (operator1)
            {
                
                case '+':
                    result =  number1 + number2;
                    break;
                case '-':
                    result = number1 - number2;
                    break;
                case '*':
                    result =  number1 * number2;
                    break;
                case '/':
                    result = number1 / number2;
                    break;

                    
            }
            return result;

        }


        private string operation_Type(string calcul)
        {
            if (calcul.Contains("+")) {
                return "addition";
            } else if (calcul.Contains(""))
            {
                return "soustraction";
            }
            return "";
        }

        private bool check_Virgule(string calcul)
        {
            if(calcul.Contains(",")) {
                return false;
            }
            return true;
        }

    }
}
