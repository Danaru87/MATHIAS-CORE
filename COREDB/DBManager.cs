using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Data;

namespace COREDB
{
    public class DBManager : IDisposable
    {
        private bool _dbExist { get; set; }
        private SQLiteConnection _sqlite { get; set; }

        public ConnectionState STATE { get; set; }

        public DBManager()
        {
            STATE = ConnectionState.Closed;
            _dbExist = SQLiteDBExist();
            VerifyIntegrity();
        }

        private void VerifyIntegrity()
        {
            throw new NotImplementedException();
        }

        public void Connect()
        {
            _sqlite = new SQLiteConnection("DataSource = MDB.sqlite;Version=3;New=True;Compress=True;");
            STATE = _sqlite.State;
        }

        private bool SQLiteDBExist()
        {
            if (File.Exists("MathiasDB.sqlite"))
            {
                return true;
            }
            return false;
        }

        public void Dispose()
        {
            _sqlite.Close();
            STATE = ConnectionState.Closed;
        }
    }
}
