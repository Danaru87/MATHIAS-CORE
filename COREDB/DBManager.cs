using System;
using System.Data.SQLite;
using System.Configuration;
using System.IO;
using Dapper;
using System.Reflection;

namespace COREDB
{
    public class DBManager
    {
        private bool _dbExist { get; set; }
        private String DBPATH {get;set;}
        private SQLiteConnection sqlClient { get; set; }
        private String SQLCHAIN = String.Format("Data Source = {0}\\database\\mathias.sqlite; Version = 3;", Directory.GetCurrentDirectory());

        /// <summary>
        /// Contructor with default database path
        /// </summary>
        public DBManager()
        {
            DBPATH = Path.Combine(Directory.GetCurrentDirectory(), "database");
            CheckFolders();
            CheckDBFile();
        }

        /// <summary>
        /// Constructo with custom database path
        /// </summary>
        /// <param name="PathToDB"></param>
        public DBManager(string PathToDB)
        {
            DBPATH = PathToDB;
            CheckFolders();
            CheckDBFile();
        }
        /// <summary>
        /// Vérification de la présence du dossier database dans le dossier d'installation
        /// </summary>
        private void CheckFolders()
        {
            bool databaseDirectory = Directory.Exists(Path.Combine(DBPATH));
            if (!databaseDirectory)
            {
                //TODO : Log DEBUG
                Directory.CreateDirectory(Path.Combine(DBPATH));
            }
        }

        /// <summary>
        /// Vérification de la présence de la base de donnée embarquée
        /// </summary>
        private void CheckDBFile()
        {
            bool exist = File.Exists(Path.Combine(DBPATH, "mathias.sqlite"));
            if (!exist)
            {
                SQLiteConnection.CreateFile(Path.Combine(DBPATH, "mathias.sqlite"));
                CreateDataBase();
            }

        }

        /// <summary>
        /// Création des tables et des enregistrements dans la base de données
        /// </summary>
        private void CreateDataBase()
        {
            string line;
            StreamReader file = new StreamReader("Scripts/InstallDB.ini");
            while((line =file.ReadLine()) != null)
            {
                try
                {
                    string queries = File.ReadAllText(Path.Combine("Scripts", line));
                    queries = queries.Replace("\n", "");
                    using (sqlClient = new SQLiteConnection(SQLCHAIN))
                    {
                        sqlClient.Execute(queries);

                    }
                }
                catch (SQLiteException e)
                {
                    Console.WriteLine(e);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                } 
            }
        }
    }
}
