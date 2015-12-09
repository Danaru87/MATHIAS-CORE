using System;
using System.Data.SQLite;
using System.Configuration;
using System.IO;
using Dapper;

namespace COREDB
{
    public class DBManager : IDisposable
    {
        private bool _dbExist { get; set; }
        
        private SQLiteConnection sqlClient { get; set; }


        public DBManager()
        {
            bool exist = File.Exists("C:\\MATHIAS\\database\\mathias.sqlite");
            if (!exist)
            {
                SQLiteConnection.CreateFile("C:\\MATHIAS\\database\\mathias.sqlite");
                sqlClient = new SQLiteConnection("Data Source = C:\\MATHIAS\\database\\mathias.sqlite; Version = 3;");
                CreateDataBase();
            }
            else
            {
                sqlClient = new SQLiteConnection("Data Source = C:\\MATHIAS\\database\\mathias.sqlite; Version = 3;");
            }

        }

        public static bool InstallDB()
        {
            
            bool existFolderMathias = Directory.Exists("C:\\MATHIAS");
            bool existDatabaseFodler = Directory.Exists("C:\\MATHIAS\\database");
            bool exist = File.Exists("C:\\MATHIAS\\database\\mathias.sqlite");

            if (!existFolderMathias)
            {
                Console.WriteLine("Création du dossier d'installation MATHIAS");
                Directory.CreateDirectory("C:\\MATHIAS");
            }
            if (!existDatabaseFodler)
            {
                Console.WriteLine("Création du dossier database");
                Directory.CreateDirectory("C:\\MATHIAS\\databse");
            }
            if (!exist)
            {
                Console.WriteLine("Création du fichier de la base de données sqlite.");
                SQLiteConnection.CreateFile("C:\\MATHIAS\\database\\mathias.sqlite");
            }
            Console.WriteLine("Connection à la base nouvellement créé...");
            SQLiteConnection sqlClient = new SQLiteConnection("Data Source = C:\\MATHIAS\\database\\mathias.sqlite; Version = 3;");

            Console.WriteLine("Création des tables et des enregistrements");
            string line;
            StreamReader file = new StreamReader("Scripts/InstallDB.ini");
            while ((line = file.ReadLine()) != null)
            {
                string queries = File.ReadAllText(Path.Combine("Scripts", line));
                queries = queries.Replace("\n", "");
                sqlClient.Execute(queries);
            }
            Console.WriteLine("Fin de l'installation de la base de données Mathias");
            return true;
        }
        private void CreateDataBase()
        {
            string line;
            StreamReader file = new StreamReader("Scripts/InstallDB.ini");
            while((line =file.ReadLine()) != null)
            {
                string queries = File.ReadAllText(Path.Combine("Scripts", line));
                queries = queries.Replace("\n", "");
                sqlClient.Execute(queries);
            }
        }

        public void Dispose()
        {
            sqlClient.Close();
            sqlClient.Dispose();
        }
    }
}
