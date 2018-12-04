using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MiniGames
{
    [TestClass]
    public class UnitTestChoixBataille
    {
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
        public void TestMethodListOfArtistsSucessAmountOfArtistsObject()
        {
            int expectedAmountOfArtists = 2;
            int actualAmountOfArtists = -1;

            //given
            this.strWriter = new StreamWriter(this.testJsonFileName);
            strWriter.Write("[{\"pictureName\":\"Pic1.png\",\"name\":\"Artiste1\",\"listOfSongs\":[{\"title\":\"SongA1\",\"duration\":1},{\"title\":\"SongA2\",\"duration\":2}]},{\"pictureName\":\"Pic2.png\",\"name\":\"Artiste1\",\"listOfSongs\":[{\"title\":\"SongB1\",\"duration\":3},{\"title\":\"SongB2\",\"duration\":4}]}]");
            strWriter.Close();
            this.testJsonConnector = new JsonConnector(this.testJsonFileName);

            //then
            this.listOfArtists = this.testJsonConnector.ListOfArtists();
            actualAmountOfArtists = this.listOfArtists.Count;

            //when
            Assert.AreEqual(expectedAmountOfArtists, actualAmountOfArtists);
        }
    }
}
