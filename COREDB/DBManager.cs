using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;
using Dapper;
using System.Reflection;

namespace COREDB
{
    public class DBManager : IDisposable
    {
        private bool _dbExist { get; set; }
        
        private SqlConnection sqlClient { get; set; }


        public DBManager()
        {
            sqlClient = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = master; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
        }

        private void CreateDataBase()
        {

        }

        public void Dispose()
        {
            sqlClient.Close();
            sqlClient.Dispose();
        }
    }
}
