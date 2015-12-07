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
