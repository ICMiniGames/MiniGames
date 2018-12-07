using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniGames;

namespace MiniGames
{
    [TestClass]
    public class UnitTestPlayers
    {
        #region private attributes
        MiniGames.FrmPlayers players;
       
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
        public void TestMethodNbUserVisible()
        {
            int expectedAmountOfUserBoxEnabled = 3;
            int actualAmountOfUserBoxEnabled = 0;
            //given
            players = new FrmPlayers(1, expectedAmountOfUserBoxEnabled);

            //then
            actualAmountOfUserBoxEnabled = players.NbUserVisible(expectedAmountOfUserBoxEnabled);

            //when

            Assert.AreEqual(expectedAmountOfUserBoxEnabled, actualAmountOfUserBoxEnabled);

        }
        
        /// <summary>
        /// This test method is designed to test the json connector when the json file
        /// to read is correctly filled.
        /// </summary>
        [TestMethod]
        public void TestMethodTxtBoxEmpty()
        {
            int expectedAmountOfUserBoxEnabled = 1;
            string actualAmountOfUserBoxEnabled = "";
            //given
            players = new FrmPlayers(1, expectedAmountOfUserBoxEnabled);

            //then
            string TextBox1 = players.txtNameUser1.Text;


            //when

            Assert.AreEqual(TextBox1, actualAmountOfUserBoxEnabled);


        }
        
        /// <summary>
        /// This test method is designed to test the json connector when the json file
        /// to read is correctly filled.
        /// </summary>
        [TestMethod]
        public void TestMethodTxtBoxFull()
        {
            int expectedAmountOfUserBoxEnabled = 1;
            string actualAmountOfUserBoxEnabled = "";
            string TextToTextBox1 = "Salut";
            //given
            players = new FrmPlayers(1, expectedAmountOfUserBoxEnabled);
            players.txtNameUser1.Text = TextToTextBox1;
            //then
            string TextBox1 = players.txtNameUser1.Text;


            //when

            Assert.AreNotEqual(TextBox1, actualAmountOfUserBoxEnabled);



        }
        /// <summary>
        /// This test method is designed to test the json connector when the json file
        /// to read is correctly filled.
        /// </summary>
        [TestMethod]
        public void TestMethodTxtBoxTextDifferent()
        {
            int expectedAmountOfUserBoxEnabled = 1;
            string TextToTextBox1 = "Salut";
            string TextToTextBox2 = "yi";
            //given
            players = new FrmPlayers(1, expectedAmountOfUserBoxEnabled);
            players.txtNameUser1.Text = TextToTextBox1;
            players.txtNameUser2.Text = TextToTextBox2;
            //then
            string TextBox1 = players.txtNameUser1.Text;
            string TextBox2 = players.txtNameUser2.Text;


            //when

            Assert.AreNotEqual(TextBox1, TextBox2);



        }
    }
}
