﻿using System;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MiniGames
{
    [TestClass]
    public class UnitTestMorpion
    {
        #region private attributes
        MiniGames.FrmMorpion morpion = new FrmMorpion();

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
        /// This test method is designed to test the json connector when the json file
        /// to read is correctly filled.
        /// </summary>
        [TestMethod]
        public void TestMethodClicker()
        {
            Control Button = new Control();
            Button.MouseClick += Button_MouseClick;
        }

        /// <summary>
        /// This test method is designed to test the json connector when the json file
        /// to read is correctly filled.
        /// </summary>
        [TestMethod]
        public void TestMethodVictoryHorizontal()
        {
            morpion.NbTour = 6;
            morpion.Winner = false;
            morpion.TabMorpion[0] = "X";
            morpion.TabMorpion[1] = "X";
            morpion.TabMorpion[2] = "X";

            morpion.VerifyWinner();
            Assert.AreEqual(morpion.Winner, true);
        }

        /// <summary>
        /// This test method is designed to test the json connector when the json file
        /// to read is correctly filled.
        /// </summary>
        [TestMethod]
        public void TestMethodVictoryVertical()
        {
            morpion.NbTour = 6;
            morpion.Winner = false;
            morpion.TabMorpion[0] = "X";
            morpion.TabMorpion[3] = "X";
            morpion.TabMorpion[6] = "X";

            morpion.VerifyWinner();
            Assert.AreEqual(morpion.Winner, true);
        }

        /// <summary>
        /// This test method is designed to test the json connector when the json file
        /// to read is correctly filled.
        /// </summary>
        [TestMethod]
        public void TestMethodVictoryDiagonal()
        {
            morpion.NbTour = 6;
            morpion.Winner = false;
            morpion.TabMorpion[0] = "X";
            morpion.TabMorpion[4] = "X";
            morpion.TabMorpion[8] = "X";

            morpion.VerifyWinner();
            Assert.AreEqual(morpion.Winner, true);
        }


        /// <summary>
        /// This test method is designed to test the json connector when the json file
        /// to read is correctly filled.
        /// </summary>
        [TestMethod]
        public void TestMethodMatchNull()
        {
            morpion.Win = false;
            morpion.NbTour = 9;
            morpion.TabMorpion[0] = "X";
            morpion.TabMorpion[1] = "O";
            morpion.TabMorpion[2] = "X";
            morpion.TabMorpion[3] = "O";
            morpion.TabMorpion[4] = "X";
            morpion.TabMorpion[5] = "O";
            morpion.TabMorpion[6] = "O";
            morpion.TabMorpion[7] = "X";
            morpion.TabMorpion[8] = "O";
            
            bool TestWinner = morpion.Win;
            Assert.AreEqual(TestWinner, false);
        }

        /// <summary>
        /// This test method is designed to test the json connector when the json file
        /// to read is correctly filled.
        /// </summary>
        [TestMethod]
        public void TestMethodClearGround()
        {
            morpion.TabMorpion[0] = "X";
            morpion.TabMorpion[4] = "X";
            morpion.TabMorpion[8] = "X";

            morpion.VerifyWinner();
            Assert.AreEqual(morpion.TabMorpion[0], null);
        }

        private void Button_MouseClick(object sender, MouseEventArgs e)
        {
            morpion.Clicker(sender, e);
        }
    }
}
