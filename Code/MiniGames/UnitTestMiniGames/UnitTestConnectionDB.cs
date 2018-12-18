using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniGames;

namespace MiniGames
{
    [TestClass]
    public class UnitTestConnectionDB
    {
        #region private attributes
        MiniGames.ConnectionDB connection = new ConnectionDB();
        private string testSqliteFileName = "TestMiniGames.sqlite";
        #endregion private attributes

        /// <summary>
        /// This test method initializes variables and objects needed for the next test session.
        /// Run before each test method.
        /// </summary>
        [TestInitialize]
        public void Init()
        {

        }

        /*/// <summary>
        /// This test method is designed to test the json connector when the json file
        /// to read is correctly filled.
        /// </summary>
        [TestMethod]
        public void TestMethodCreateSQLFile()
        {
           
            connection.VerifyFileOpen(testSqliteFileName);

            Assert.AreEqual(File.Exists("MiniGames.sqlite"), false);
        }*/









        /*/// <summary>
        /// This test method cleanup variables and objects used for the last test session.
        /// Run after each test method.
        /// </summary>
        [TestCleanup]
        public void Cleanup()
        {
            this.connection = null;
            if (File.Exists(this.testSqliteFileName))
            {
                File.Delete(this.testSqliteFileName);
            }
        }*/
    }
}
