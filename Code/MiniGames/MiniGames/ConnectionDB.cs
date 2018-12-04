using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Threading.Tasks;
using System.IO;

namespace MiniGames
{
    /// <summary>
    /// Utilisé pour intéragire pour avec la base de données
    /// </summary>
    class ConnectionDB
    {
        
        private SQLiteConnection m_dbConnection;
<<<<<<< HEAD
        public int NumberPlayer;

=======
>>>>>>> Cyril_branch
        /// <summary>
        /// Utilise le fichier sqlite si il existe / le crée si il n'existe pas
        /// </summary>
        public ConnectionDB()
        {
<<<<<<< HEAD
            //Verifie que le fichier existe
            if (File.Exists("MiniGames.sqlite"))
            {
                //ouvre une connextion à la base de données
=======
            if (File.Exists("MiniGames.sqlite"))
            {
>>>>>>> Cyril_branch
                m_dbConnection = new SQLiteConnection("Data Source=MiniGames.sqlite;Version=3;");
                m_dbConnection.Open();
            }
            else
            {
<<<<<<< HEAD
                //Crée le fichier et ouvre une connexion à la base de données
                SQLiteConnection.CreateFile("MiniGames.sqlite");
                m_dbConnection = new SQLiteConnection("Data Source=MiniGames.sqlite;Version=3;");
                m_dbConnection.Open();
            }

=======
                SQLiteConnection.CreateFile("Splendor.sqlite");
                m_dbConnection = new SQLiteConnection("Data Source=MiniGames.sqlite;Version=3;");
                m_dbConnection.Open();

            }
>>>>>>> Cyril_branch
        }
    }
}
