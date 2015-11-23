using COREMODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;

namespace COREDB.SqlBuilders
{
    public class UserSqlBuilder
    {
        private SqlConnection sqlClient { get; set; }
        public UserSqlBuilder()
        {
            CheckTableInDatabase();
        }

        private void CheckTableInDatabase()
        {
            using (sqlClient = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = master; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False"))
            {
                SqlCommand cmd = new SqlCommand("Select name from sysobject where name='USERS')", sqlClient);
                String tableName = sqlClient.Query<String>("Select name from sysobject where name = 'USERS'").First();
                if (String.IsNullOrEmpty(tableName))
                {
                    CreateUsersTable();
                }
            }
        }

        public static void CreateUsersTable()
        {
            
            String sqlCreate = "CREATE TABLE USERS (";
            List<PropertyInfo> properties = typeof(USERS).GetProperties().ToList();

            foreach (PropertyInfo prop in properties)
            {
                if (prop.PropertyType == typeof(Int32))
                {
                    sqlCreate += "" + prop.Name + " " + "int,";
                }
                else if (prop.PropertyType == typeof(String))
                {
                    sqlCreate += "" + prop.Name + " " + "ntext";
                }
                else if (prop.PropertyType == typeof(DateTime))
                {
                    sqlCreate += "" + prop.Name + " " + "datetime";
                }
                
            }
            sqlCreate = sqlCreate.Substring(0, sqlCreate.Length - 1);
        }



        public static void CheckIntegrity()
        {
            List<PropertyInfo> properties = typeof(USERS).GetProperties().ToList();
            //GetDBScheme();
        }
    }
}
