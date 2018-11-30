using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace MiniGames
{
    class ConnectionDB
    {
       /* //connection to the database
        private SQLiteConnection m_dbConnection;
        public int NumberPlayer;
        int NumberForget = 0;
        /// <summary>
        /// constructor : creates the connection to the database SQLite
        /// </summary>
        public ConnectionDB()
        {
            if (File.Exists("Splendor.sqlite"))
            {
                m_dbConnection = new SQLiteConnection("Data Source=Splendor.sqlite;Version=3;");
                m_dbConnection.Open();
                //NumberPlayer = GetCountPlayer();

            }
            else
            {
                SQLiteConnection.CreateFile("Splendor.sqlite");
                m_dbConnection = new SQLiteConnection("Data Source=Splendor.sqlite;Version=3;");
                m_dbConnection.Open();
                //create and insert players
                //modifier après rendu
                CreateInsertPlayer();
                //
                //Create and insert cards
                CreateInsertCards();
                //Create and insert ressources
                CreateInsertRessources();
            }
        }*/



    }
}
