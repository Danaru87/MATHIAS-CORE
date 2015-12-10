using COREDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBInstaller
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Installation de la base de données en cours...");
            DBManager.InstallDB();
            Console.WriteLine("Installation terminée, merci de rester sympa avec votre nouvelle IA");
            Console.WriteLine("Appuyer sur une touche pour quitter");
            Console.ReadKey();
        }
    }
}
