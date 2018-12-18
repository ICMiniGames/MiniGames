using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MiniGames
{
    [TestClass]
    public class UnitTestBataille
    {
        #region private attributes
        MiniGames.FrmBataille frmBataille = new FrmBataille();

        #endregion private attributes

        /// <summary>
        /// This test method initializes variables and objects needed for the next test session.
        /// Run before each test method.
        /// </summary>
        [TestInitialize]
        public void Init()
        {

        }

        /// <summary>
        /// This test method is verify if two card which follow each other are equal
        /// to read is correctly filled.
        /// </summary>
        [TestMethod]
        public void TestMethodShuffleCard()
        {
            frmBataille.CreateCardList();
            Assert.AreNotEqual(frmBataille.ListCards[1].GetValeur(), frmBataille.ListCards[2].GetValeur());
        }

        /// <summary>
        /// This test method is verify if Bots are a number of card are equal
        /// to read is correctly filled.
        /// </summary>
        [TestMethod]
        public void TestMethodParsingCard()
        {
            int NbCardBot1 = frmBataille.CardBot1.Count;
            int NbCardBot2 = frmBataille.CardBot2.Count;
            Assert.AreEqual(NbCardBot1, NbCardBot2);
        }

        /// <summary>
        /// This test method is designed to test the json connector when the json file
        /// to read is correctly filled.
        /// </summary>
        [TestMethod]
        public void TestMethodVictoryBot()
        {
            object sender = new object() ;
            EventArgs e = new EventArgs();
            frmBataille.WinBot1 = 55;
            frmBataille.cmdStartBet_Click(sender, e);
            Assert.AreEqual(frmBataille.StatRound, "Bot1");
        }

        /// <summary>
        /// This test method is designed to test the json connector when the json file
        /// to read is correctly filled.
        /// </summary>
        [TestMethod]
        public void TestMethodVictoryPlayer()
        {
            frmBataille.ListWinPlayer[0] = 4;
            frmBataille.WinBot("Bot1");


            Assert.AreEqual(frmBataille.ListWinPlayer[0], 5);
        }
    }
}
