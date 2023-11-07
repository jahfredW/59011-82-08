using System;

namespace employe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employe employe1 = new Employe("GRUWE", "Prénom", new DateTime(2015, 11, 10), "cadre", 1500.00, "compta");
            Employe employe2 = new Employe("DIDOLLA", "David", new DateTime(2015, 11, 10), "cadre", 1500.00);

            Console.WriteLine(employe1.ToString());
            Console.WriteLine(employe2.ToString());

            Console.WriteLine(employe1.Seniority());
            employe1.primeVersement(new DateTime(2022, 10, 30));


            Console.WriteLine(Employe.employes);

            var employesTries = Employe.employes.OrderBy(e => e.Nom).ToList();

            foreach(var employe in employesTries)
            {
                Console.WriteLine(employe.ToString());
            }


        }
    }
}
