using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace MiniGames
{
    class ConnectionDB
    {
        
        private SQLiteConnection m_dbConnection;
        /// <summary>
        /// constructor : creates the connection to the database SQLite
        /// </summary>
        public ConnectionDB()
        {
            if (File.Exists("MiniGames.sqlite"))
            {
                m_dbConnection = new SQLiteConnection("Data Source=MiniGames.sqlite;Version=3;");
                m_dbConnection.Open();
                //NumberPlayer = GetCountPlayer();

            }
            else
            {
                SQLiteConnection.CreateFile("Splendor.sqlite");
                m_dbConnection = new SQLiteConnection("Data Source=MiniGames.sqlite;Version=3;");
                m_dbConnection.Open();

            }
        }
    }
}
