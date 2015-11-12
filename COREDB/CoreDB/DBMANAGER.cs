using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace CoreDB
{
    public class DBMANAGER
    {
        static SQLiteConnection connection;
        public static SQLiteConnection CONNECT()
        {
            if (!File.Exists("MDB.sqlite"))
            {
                CreateDB();
            }
            else
            {
                OpenDB();
            }
            return connection;
        }

        private static void OpenDB()
        {
            connection = new SQLiteConnection("DataSource = MDB.sqlite;Version=3;New=False;Compress=True;");
        }

        public static void PopulateDB()
        {
            connection.Open();
            SQLiteCommand cmd = connection.CreateCommand();
            cmd.CommandText = @"--
            -- Fichier généré par SQLiteStudio v3.0.6sur jeu. nov. 12 15:48:36 2015
            --
            -- Encodage texte utilisé: UTF-8
            --
            PRAGMA foreign_keys = off;
            BEGIN TRANSACTION;

            -- Table: USERS
            DROP TABLE IF EXISTS USERS;
            CREATE TABLE USERS (ID VARCHAR (32) PRIMARY KEY NOT NULL UNIQUE, FIRSTNAME VARCHAR (255) NOT NULL, LASTNAME VARCHAR (254), USERNAME VARCHAR (254) UNIQUE, PASSWD VARCHAR (254));

            COMMIT TRANSACTION;
            PRAGMA foreign_keys = on;";

            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public static void CreateDB()
        {
            connection = new SQLiteConnection("DataSource = MDB.sqlite;Version=3;New=True;Compress=True;");
            PopulateDB();
        }
    }
}
