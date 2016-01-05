using COREMODEL;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.IO;

namespace COREDB
{
    public class DBContext: IDisposable
    {
        private SQLiteConnection sqLite { get; set; }
        public DBContext()
        {
            sqLite = new SQLiteConnection(String.Format("Data Source = {0}\\database\\mathias.sqlite; Version = 3;", Directory.GetCurrentDirectory()));
        }

        /// <summary>
        /// Vérifie le login et le pass de l'utilisateur
        /// </summary>
        /// <param name="login"></param>
        /// <param name="passwd"></param>
        /// <returns></returns>
        public bool CheckUser(string login, string passwd)
        {
            try
            {
                USERS user = sqLite.Query<USERS>("Select * FROM USERS where USERNAME=@USERNAME AND PASSWD = @PASSWORD", new { USERNAME = login, PASSWORD = passwd }).FirstOrDefault();
                return true;
            }
            catch (SQLiteException exception) { return false; }
        }

        public void Dispose()
        {
            sqLite.Close();
            sqLite.Dispose();
            sqLite = null;
        }
    }
}
