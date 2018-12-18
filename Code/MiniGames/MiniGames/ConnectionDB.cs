using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace MiniGames
{
    public class ConnectionDB
    {
        #region private attribut
        List<string> NamesPlayer = new List<string>();
        private SQLiteConnection m_dbConnection;
        List<Card> cards = new List<Card>();
        #endregion private attribut

        #region constructor
        /// <summary>
        /// constructor : creates the connection to the database SQLite
        /// </summary>
        public ConnectionDB()
        {
            VerifyFileOpen("MiniGames.sqlite");
        }
        #endregion constructor

        #region public method

        /// <summary>
        /// Method checking whether the file already exists or not.
        /// </summary>
        /// <param name="FileSqlite"></param>
        public void VerifyFileOpen(string FileSqlite)
        {
            if (File.Exists(FileSqlite))
            {
                m_dbConnection = new SQLiteConnection("Data Source=" + FileSqlite + ";Version=3;");
                m_dbConnection.Open();
                ListPlayerAlreadyExist();

            }
            else
            {
                SQLiteConnection.CreateFile(FileSqlite);
                m_dbConnection = new SQLiteConnection("Data Source=" + FileSqlite + "; Version=3;");
                m_dbConnection.Open();

                //Create a table in the Data Base for players, Scores and Cards.
                CreateTablePlayer();
                CreateTableScore();
                CreateInsertCard();
            }
        }

        /// <summary>
        /// Insert data  for the game Morpion  in Score table
        /// </summary>
        /// <param name="NameWinner"></param>
        /// <param name="NameLoser"></param>
        public void InsertScoreMorpion(string NameWinner, string NameLoser)
        {
            string sqlWinner = "SELECT IdPlayer FROM Player WHERE UserName = '" + NameWinner + "'";
            SQLiteCommand commandWinner = new SQLiteCommand(sqlWinner, m_dbConnection);
            SQLiteDataReader readerWinner = commandWinner.ExecuteReader();
            int IdWinner = 0;
            while (readerWinner.Read())
            {
                IdWinner = Convert.ToInt16(readerWinner["IdPlayer"]);
            }

            string sqlLoser = "SELECT IdPlayer FROM Player WHERE UserName = '" + NameLoser + "'";
            SQLiteCommand commandLoser = new SQLiteCommand(sqlLoser, m_dbConnection);
            SQLiteDataReader readerLoser = commandLoser.ExecuteReader();
            int IdLoser = 0;
            while (readerLoser.Read())
            {
                IdLoser = Convert.ToInt16(readerLoser["IdPlayer"]);
            }

            string sqlScoreWinner = "UPDATE Score SET NbWinMorpion = NbWinMorpion + 1 WHERE FkPlayer = " + IdWinner;
            SQLiteCommand commandScoreWinner = new SQLiteCommand(sqlScoreWinner, m_dbConnection);
            commandScoreWinner.ExecuteNonQuery();

            string sqlScoreLoser = "UPDATE Score SET NbDefeatMorpion = NbDefeatMorpion + 1  WHERE FkPlayer = " + IdLoser;
            SQLiteCommand commandScoreLoser = new SQLiteCommand(sqlScoreLoser, m_dbConnection);
            commandScoreLoser.ExecuteNonQuery();
        }

        /// <summary>
        /// Insert data for the game Bataille in Score table
        /// </summary>
        /// <param name="NameWinner"></param>
        /// <param name="NameLoser1"></param>
        /// <param name="NameLoser2"></param>
        /// <param name="NameLoser3"></param>
        /// <param name="NbUsers"></param>
        /// <param name="NbMinBet"></param>
        public void InsertScoreBataille(string NameWinner, string NameLoser1, string NameLoser2, string NameLoser3, int NbUsers, int NbBet)
        {
            string sqlWinner = "SELECT IdPlayer FROM Player WHERE UserName = '" + NameWinner + "'";
            SQLiteCommand commandWinner = new SQLiteCommand(sqlWinner, m_dbConnection);
            SQLiteDataReader readerWinner = commandWinner.ExecuteReader();
            int IdWinner = 0;
            while (readerWinner.Read())
            {
                IdWinner = Convert.ToInt16(readerWinner["IdPlayer"]);
            }

            string sqlScoreWinner = "UPDATE Score SET NbWinBataille = NbWinBataille + 1, NbBetBataille = " + NbBet + " WHERE FkPlayer = " + IdWinner;
            SQLiteCommand commandScoreWinner = new SQLiteCommand(sqlScoreWinner, m_dbConnection);
            commandScoreWinner.ExecuteNonQuery();

            if (NbUsers >= 2)
            {
                string sqlLoser1 = "SELECT IdPlayer FROM Player WHERE UserName = '" + NameLoser1 + "'";
                SQLiteCommand commandLoser1 = new SQLiteCommand(sqlLoser1, m_dbConnection);
                SQLiteDataReader readerLoser1 = commandLoser1.ExecuteReader();
                int IdLoser1 = 0;
                while (readerLoser1.Read())
                {
                    IdLoser1 = Convert.ToInt16(readerLoser1["IdPlayer"]);
                }

                string sqlScoreLoser1 = "UPDATE Score SET NbDefeatBataille = NbDefeatBataille + 1, NbBetBataille = " + NbBet + "  WHERE FkPlayer = " + IdLoser1;
                SQLiteCommand commandScoreLoser1 = new SQLiteCommand(sqlScoreLoser1, m_dbConnection);
                commandScoreLoser1.ExecuteNonQuery();

                if (NbUsers >= 3)
                {

                    string sqlLoser2 = "SELECT IdPlayer FROM Player WHERE UserName = '" + NameLoser2 + "'";
                    SQLiteCommand commandLoser2 = new SQLiteCommand(sqlLoser2, m_dbConnection);
                    SQLiteDataReader readerLoser2 = commandLoser2.ExecuteReader();
                    int IdLoser2 = 0;
                    while (readerLoser2.Read())
                    {
                        IdLoser2 = Convert.ToInt16(readerLoser2["IdPlayer"]);
                    }

                    string sqlScoreLoser2 = "UPDATE Score SET NbDefeatBataille = NbDefeatBataille + 1, NbBetBataille = " + NbBet + "  WHERE FkPlayer = " + IdLoser2;
                    SQLiteCommand commandScoreLoser2 = new SQLiteCommand(sqlScoreLoser2, m_dbConnection);
                    commandScoreLoser2.ExecuteNonQuery();

                    if (NbUsers == 4)
                    {
                        string sqlLoser3 = "SELECT IdPlayer FROM Player WHERE UserName = '" + NameLoser3 + "'";
                        SQLiteCommand commandLoser3 = new SQLiteCommand(sqlLoser3, m_dbConnection);
                        SQLiteDataReader readerLoser3 = commandLoser3.ExecuteReader();
                        int IdLoser3 = 0;
                        while (readerLoser3.Read())
                        {
                            IdLoser3 = Convert.ToInt16(readerLoser3["IdPlayer"]);
                        }

                        string sqlScoreLoser3 = "UPDATE Score SET NbDefeatBataille = NbDefeatBataille + 1, NbBetBataille = " + NbBet + "  WHERE FkPlayer = " + IdLoser3;
                        SQLiteCommand commandScoreLoser3 = new SQLiteCommand(sqlScoreLoser3, m_dbConnection);
                        commandScoreLoser3.ExecuteNonQuery();
                    }
                }
            }
        }

        /// <summary>
        /// Insert data  for the game Solitaire  in Score table
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Time"></param>
        /// <param name="Win"></param>
        public void InsertScoreSolitaire(string Name, int Time, bool Win)
        {
            string sql = "SELECT IdPlayer FROM Player WHERE UserName = '" + Name + "'";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            int IdPlayer = 0;
            while (reader.Read())
            {
                IdPlayer = Convert.ToInt16(reader["IdPlayer"]);
            }

            if (Win)
            {
                string sqlScore = "UPDATE Score SET NbWinSolitaire = NbWinSolitaire + 1, BestTimeSolitaire = " + Time + "  WHERE FkPlayer = " + IdPlayer;
                SQLiteCommand commandScore = new SQLiteCommand(sqlScore, m_dbConnection);
                commandScore.ExecuteNonQuery();
            }
            else
            {
                string sqlScore = "UPDATE Score SET NbDefeatSolitaire = NbDefeatSolitaire + 1 WHERE FkPlayer = " + IdPlayer;
                SQLiteCommand commandScore = new SQLiteCommand(sqlScore, m_dbConnection);
                commandScore.ExecuteNonQuery();
            }

        }

        /// <summary>
        /// Retrieves the information from each card.
        /// </summary>
        /// <returns></returns>
        public List<Card> GetCard()
        {
            string sql = "SELECT Name, LinkImage, Symbole, Valeur FROM Card";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                //ListCardName.Add(reader["Name"].ToString());
                Card card = new Card(reader["Name"].ToString(), reader["LinkImage"].ToString(), reader["Symbole"].ToString(), Convert.ToInt16(reader["Valeur"].ToString()));
                cards.Add(card);
            }

            return cards;
        }

        #endregion public method

        #region private method

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
            string sql = "CREATE TABLE Score (IdScore INTEGER PRIMARY KEY AUTOINCREMENT, FkPlayer INTEGER, BestTimeSolitaire INT, NbWinSolitaire INT, NbDefeatSolitaire INT, NbWinBataille INT, NbDefeatBataille INT , NbBetBataille INT, NbWinMorpion INT, NbDefeatMorpion INT, FOREIGN KEY(FkPlayer) REFERENCES Player(IdPlayer))";
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

        /// <summary>
        /// Insert data in Player table
        /// </summary>
        /// <param name="Name"></param>
        public void InsertPlayer(string Name)
        {
            if (!NamesPlayer.Contains(Name))
            {
                string sqlPlayer = "INSERT INTO Player (UserName) VALUES ('" + Name + "')";
                SQLiteCommand commandPlayer = new SQLiteCommand(sqlPlayer, m_dbConnection);
                commandPlayer.ExecuteNonQuery();

                string sqlIdPlayer = "SELECT IdPlayer FROM Player Where UserName = '" + Name + "'";
                SQLiteCommand commandIdPlayer = new SQLiteCommand(sqlIdPlayer, m_dbConnection);
                SQLiteDataReader readerIdPlayer = commandIdPlayer.ExecuteReader();
                int IdPlayer = 0;
                while (readerIdPlayer.Read())
                {
                    IdPlayer = Convert.ToInt16(readerIdPlayer["IdPlayer"]);
                }

                string sqlScore = "INSERT INTO Score (FkPlayer, BestTimeSolitaire, NbWinSolitaire, NbDefeatSolitaire, NbWinBataille, NbDefeatBataille, NbBetBataille, NbWinMorpion, NbDefeatMorpion) VALUES (" + IdPlayer + ", 1000, 0, 0, 0, 0, 1000, 0, 0)";
                SQLiteCommand commandScore = new SQLiteCommand(sqlScore, m_dbConnection);
                commandScore.ExecuteNonQuery();

                NamesPlayer.Add(Name);
            }
        }

        /// <summary>
        /// Verify if a player exist already
        /// </summary>
        private void ListPlayerAlreadyExist()
        {
            string sql = "SELECT UserName FROM Player";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                NamesPlayer.Add(reader["UserName"].ToString());
            }
        }
        
        #endregion private method










        
    }
}
