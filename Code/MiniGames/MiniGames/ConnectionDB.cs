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
        public List<string> NamesPlayer = new List<string>();
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
            int NbBetUpdate = 0;

            string sqlWinner = "SELECT IdPlayer FROM Player WHERE UserName = '" + NameWinner + "'";
            SQLiteCommand commandWinner = new SQLiteCommand(sqlWinner, m_dbConnection);
            SQLiteDataReader readerWinner = commandWinner.ExecuteReader();
            int IdWinner = 0;
            while (readerWinner.Read())
            {
                IdWinner = Convert.ToInt16(readerWinner["IdPlayer"]);
            }

            string sqlBetPlayer = "SELECT NbBetBataille FROM Score WHERE FkPlayer = " + IdWinner;
            SQLiteCommand commandBet = new SQLiteCommand(sqlBetPlayer, m_dbConnection);
            SQLiteDataReader readerBet = commandBet.ExecuteReader();
            int NbBetWinner = 0;
            while (readerBet.Read())
            {
                NbBetWinner = Convert.ToInt16(readerBet["NbBetBataille"]);
            }

            if(NbBet < NbBetWinner)
            {
                NbBetUpdate = NbBet;
            }
            else
            {
                NbBetUpdate = NbBetWinner;
            }

            string sqlScoreWinner = "UPDATE Score SET NbWinBataille = NbWinBataille + 1, NbBetBataille = " + NbBetUpdate + " WHERE FkPlayer = " + IdWinner;
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

                string sqlBetLoser1 = "SELECT NbBetBataille FROM Score WHERE FkPlayer = " + IdLoser1;
                SQLiteCommand commandBetLoser1 = new SQLiteCommand(sqlBetLoser1, m_dbConnection);
                SQLiteDataReader readerBetLoser1 = commandBet.ExecuteReader();
                int NbBetLoser1 = 0;
                while (readerBetLoser1.Read())
                {
                    NbBetLoser1 = Convert.ToInt16(readerBet["NbBetBataille"]);
                }

                if (NbBet < NbBetLoser1)
                {
                    NbBetUpdate = NbBet;
                }
                else
                {
                    NbBetUpdate = NbBetLoser1;
                }

                string sqlScoreLoser1 = "UPDATE Score SET NbDefeatBataille = NbDefeatBataille + 1, NbBetBataille = " + NbBetUpdate + "  WHERE FkPlayer = " + IdLoser1;
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

                    string sqlBetLoser2 = "SELECT NbBetBataille FROM Score WHERE FkPlayer = " + IdLoser2;
                    SQLiteCommand commandBetLoser2 = new SQLiteCommand(sqlBetLoser2, m_dbConnection);
                    SQLiteDataReader readerBetLoser2 = commandBetLoser2.ExecuteReader();
                    int NbBetLoser2 = 0;
                    while (readerBetLoser2.Read())
                    {
                        NbBetLoser2 = Convert.ToInt16(readerBetLoser2["NbBetBataille"]);
                    }

                    if (NbBet < NbBetLoser2)
                    {
                        NbBetUpdate = NbBet;
                    }
                    else
                    {
                        NbBetUpdate = NbBetLoser2;
                    }

                    string sqlScoreLoser2 = "UPDATE Score SET NbDefeatBataille = NbDefeatBataille + 1, NbBetBataille = " + NbBetUpdate + "  WHERE FkPlayer = " + IdLoser2;
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

                        string sqlBetLoser3 = "SELECT NbBetBataille FROM Score WHERE FkPlayer = " + IdLoser3;
                        SQLiteCommand commandBetLoser3 = new SQLiteCommand(sqlBetLoser3, m_dbConnection);
                        SQLiteDataReader readerBetLoser3 = commandBetLoser3.ExecuteReader();
                        int NbBetLoser3 = 0;
                        while (readerBetLoser3.Read())
                        {
                            NbBetLoser3 = Convert.ToInt16(readerBetLoser2["NbBetBataille"]);
                        }

                        if (NbBet < NbBetLoser3)
                        {
                            NbBetUpdate = NbBet;
                        }
                        else
                        {
                            NbBetUpdate = NbBetLoser3;
                        }

                        string sqlScoreLoser3 = "UPDATE Score SET NbDefeatBataille = NbDefeatBataille + 1, NbBetBataille = " + NbBetUpdate + "  WHERE FkPlayer = " + IdLoser3;
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

        /// <summary>
        /// Get data from player selected in the listbox
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Dictionary<string, string> Get_Player(string name)
        {

            string sql = "SELECT IdPlayer FROM Player WHERE UserName = '" + name + "'";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();

            int id = 0;

            while (reader.Read())
            {

                id = Convert.ToInt16(reader["IdPlayer"]);


            }

            string sql2 = "SELECT BestTimeSolitaire, NbWinSolitaire, NbDefeatSolitaire, NbWinBataille, NbBetBataille, NbDefeatBataille, NbWinMorpion, NbDefeatMorpion FROM Score WHERE FkPlayer = " + id.ToString();
            SQLiteCommand command2 = new SQLiteCommand(sql2, m_dbConnection);
            SQLiteDataReader reader2 = command2.ExecuteReader();

            Dictionary<string, string> DataFromPlayer = new Dictionary<string, string>();

            while (reader2.Read())
            {
                //Solitaire
                DataFromPlayer["TempsSolitaire"] = reader2["BestTimeSolitaire"].ToString();
                DataFromPlayer["VictoireSolitaire"] = reader2["NbWinSolitaire"].ToString();
                DataFromPlayer["DefSolitaire"] = reader2["NbDefeatSolitaire"].ToString();

                //Battaile
                DataFromPlayer["BetBat"] = reader2["NbBetBataille"].ToString();
                DataFromPlayer["VictoireBat"] = reader2["NbWinBataille"].ToString();
                DataFromPlayer["DefBat"] = reader2["NbDefeatBataille"].ToString();

                //Morpion
                DataFromPlayer["VictoireMorp"] = reader2["NbWinMorpion"].ToString();
                DataFromPlayer["DefMorp"] = reader2["NbDefeatMorpion"].ToString();

            }

            return DataFromPlayer;
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
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (1,'As','1Coeur','Coeur',1)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (2,'Deux','2Coeur','Coeur',2)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (3,'Trois','3Coeur','Coeur',3)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (4,'Quatre','4Coeur','Coeur',4)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (5,'Cinq','5Coeur','Coeur',5)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (6,'Six','6Coeur','Coeur',6)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (7,'Sept','7Coeur','Coeur',7)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (8,'Huit','8Coeur','Coeur',8)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (9,'Neuf','9Coeur','Coeur',9)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (10,'Dix','10Coeur','Coeur',10)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (11,'Valet','11Coeur','Coeur',11)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (12,'Dame','12Coeur','Coeur',12)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (13,'Roi','13Coeur','Coeur',13)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (14,'As','1Pique','Pique',1)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (15,'Deux','2Pique','Pique',2)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (16,'Trois','3Pique','Pique',3)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (17,'Quatre','4Pique','Pique',4)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (18,'Cinq','5Pique','Pique',5)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (19,'Six','6Pique','Pique',6)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (20,'Sept','7Pique','Pique',7)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (21,'Huit','8Pique','Pique',8)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (22,'Neuf','9Pique','Pique',9)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (23,'Dix','10Pique','Pique',10)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (24,'Valet','11Pique','Pique',11)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (25,'Dame','12Pique','Pique',12)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (26,'Roi','13Pique','Pique',13)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (27,'As','1Carreau','Carreau',1)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (28,'Deux','2Carreau','Carreau',2)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (29,'Trois','3Carreau','Carreau',3)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (30,'Quatre','4Carreau','Carreau',4)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (31,'Cinq','5Carreau','Carreau',5)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (32,'Six','6Carreau','Carreau',6)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (33,'Sept','7Carreau','Carreau',7)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (34,'Huit','8Carreau','Carreau',8)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (35,'Neuf','9Carreau','Carreau',9)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (36,'Dix','10Carreau','Carreau',10)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (37,'Valet','11Carreau','Carreau',11)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (38,'Dame','12Carreau','Carreau',12)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (39,'Roi','13Carreau','Carreau',13)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (40,'As','1Trefle','Trèfle',1)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (41,'Deux','2Trefle','Trèfle',2)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (42,'Trois','3Trefle','Trèfle',3)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (43,'Quatre','4Trefle','Trèfle',4)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (44,'Cinq','5Trefle','Trèfle',5)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (45,'Six','6Trefle','Trèfle',6)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (46,'Sept','7Trefle','Trèfle',7)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (47,'Huit','8Trefle','Trèfle',8)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (48,'Neuf','9Trefle','Trèfle',9)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (49,'Dix','10Trefle','Trèfle',10)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (50,'Valet','11Trefle','Trèfle',11)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (51,'Dame','12Trefle','Trèfle',12)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();
            sql = "insert into Card (IdCard, Name, LinkImage, Symbole, Valeur) values (52,'Roi','13Trefle','Trèfle',13)"; command = new SQLiteCommand(sql, m_dbConnection); command.ExecuteNonQuery();


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
