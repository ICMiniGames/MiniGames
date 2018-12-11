using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
<<<<<<< HEAD
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
=======

using System.Threading.Tasks;

namespace MiniGames
{
    class ConnectionDB
    {
        List<string> NamesPlayer = new List<string>();
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
                ListPlayerAlreadyExist();

            }
            else
            {
                SQLiteConnection.CreateFile("MiniGames.sqlite");
                m_dbConnection = new SQLiteConnection("Data Source=MiniGames.sqlite;Version=3;");
                m_dbConnection.Open();

               
                //Create a table in the Data Base for players, Scores and Cards.
                CreateTablePlayer();
                CreateTableScore();
                CreateInsertCard();
            }
        }

        /// <summary>
        /// create the "player" table and insert data
        /// </summary>
        private void CreateTablePlayer()
        {
            string sql = "CREATE TABLE Player (IdPlayer INTEGER PRIMARY KEY AUTOINCREMENT, UserName VARCHAR(100))";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// create the "player" table and insert data
        /// </summary>
        private void CreateTableScore()
        {
            string sql = "CREATE TABLE Score (IdScore INT PRIMARY KEY, BestTimeSolitaire INT, NbWinSolitaire INT, NbDefeatSolitaire INT, NbWinBataille INT, NbDefeatBataille INT, NbWinMorpion INT, NbDefeatMorpion INT, FkPlayer INT , FOREIGN KEY(FkPlayer) REFERENCES Player(IdPlayer))";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// create the "Card" table and insert data
        /// </summary>
        private void CreateInsertCard()
        {
            string sql = "CREATE TABLE Card (IdCard INT PRIMARY KEY, Name VARCHAR(100), LinkImage VARCHAR(255), Symbole VARCHAR(50), Valeur INT)";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (1,'As','CœurAs.png','Cœur',1)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (2,'Deux','CœurDeux.png','Cœur',2)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (3,'Trois','CœurTrois.png','Cœur',3)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (4,'Quatre','CœurQuatre.png','Cœur',4)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (5,'Cinq','CœurCinq.png','Cœur',5)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (6,'Six','CœurSix.png','Cœur',6)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (7,'Sept','CœurSept.png','Cœur',7)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (8,'Huit','CœurHuit.png','Cœur',8)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (9,'Neuf','CœurNeuf.png','Cœur',9)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (10,'Dix','CœurDix.png','Cœur',10)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (11,'Valet','CœurValet.png','Cœur',11)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (12,'Dame','CœurDame.png','Cœur',12)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (13,'Roi','CœurRoi.png','Cœur',13)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (14,'As','PiqueAs.png','Pique',1)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (15,'Deux','PiqueDeux.png','Pique',2)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (16,'Trois','PiqueTrois.png','Pique',3)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (17,'Quatre','PiqueQuatre.png','Pique',4)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (18,'Cinq','PiqueCinq.png','Pique',5)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (19,'Six','PiqueSix.png','Pique',6)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (20,'Sept','PiqueSept.png','Pique',7)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (21,'Huit','PiqueHuit.png','Pique',8)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (22,'Neuf','PiqueNeuf.png','Pique',9)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (23,'Dix','PiqueDix.png','Pique',10)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (24,'Valet','PiqueValet.png','Pique',11)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (25,'Dame','PiqueDame.png','Pique',12)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (26,'Roi','PiqueRoi.png','Pique',13)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (27,'As','CarreauAs.png','Carreau',1)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (28,'Deux','CarreauDeux.png','Carreau',2)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (29,'Trois','CarreauTrois.png','Carreau',3)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (30,'Quatre','CarreauQuatre.png','Carreau',4)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (31,'Cinq','CarreauCinq.png','Carreau',5)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (32,'Six','CarreauSix.png','Carreau',6)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (33,'Sept','CarreauSept.png','Carreau',7)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (34,'Huit','CarreauHuit.png','Carreau',8)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (35,'Neuf','CarreauNeuf.png','Carreau',9)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (36,'Dix','CarreauDix.png','Carreau',10)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (37,'Valet','CarreauValet.png','Carreau',11)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (38,'Dame','CarreauDame.png','Carreau',12)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (39,'Roi','CarreauRoi.png','Carreau',13)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (40,'As','TrèfleAs.png','Trèfle',1)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (41,'Deux','TrèfleDeux.png','Trèfle',2)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (42,'Trois','TrèfleTrois.png','Trèfle',3)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (43,'Quatre','TrèfleQuatre.png','Trèfle',4)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (44,'Cinq','TrèfleCinq.png','Trèfle',5)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (45,'Six','TrèfleSix.png','Trèfle',6)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (46,'Sept','TrèfleSept.png','Trèfle',7)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (47,'Huit','TrèfleHuit.png','Trèfle',8)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (48,'Neuf','TrèfleNeuf.png','Trèfle',9)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (49,'Dix','TrèfleDix.png','Trèfle',10)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (50,'Valet','TrèfleValet.png','Trèfle',11)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (51,'Dame','TrèfleDame.png','Trèfle',12)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (52,'Roi','TrèfleRoi.png','Trèfle',13)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();

        }

        public void InsertPlayer(string Name)
        {
            if (!NamesPlayer.Contains(Name))
            {
                string sql = "INSERT INTO Player (UserName) VALUES ('" + Name + "')";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
            
                NamesPlayer.Add(Name);
            }
        }

        private void ListPlayerAlreadyExist()
        {
            string sql = "SELECT UserName FROM Player";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                NamesPlayer.Add(reader["UserName"].ToString());
            }
>>>>>>> Cyril_branch
        }
    }
}
