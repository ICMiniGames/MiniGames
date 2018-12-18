using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGames
{
    public class Card
    {
        #region private attribut
        string Name;
        string LinkImage;
        string Symbole;
        int Valeur;
        #endregion private attribut



        #region public method
        /// <summary>
        /// This constructor initializes a new instance of a card.
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="LinkImage"></param>
        /// <param name="Symbole"></param>
        /// <param name="Valeur"></param>
        public Card(string Name, string LinkImage, string Symbole, int Valeur)
        {
            this.Name = Name;
            this.LinkImage = LinkImage;
            this.Symbole = Symbole;
            this.Valeur = Valeur;
        }

        /// <summary>
        /// Method that returns the name of a card.
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            return Name;
        }

        /// <summary>
        /// Method that returns the link of a card.
        /// </summary>
        /// <returns></returns>
        public string GetLink()
        {
            return LinkImage;
        }

        /// <summary>
        /// Method that returns the symbole of a card.
        /// </summary>
        /// <returns></returns>
        public string GetSymbole()
        {
            return Symbole;
        }

        /// <summary>
        /// Method that returns the value of a card.
        /// </summary>
        /// <returns></returns>
        public int GetValeur()
        {
            return Valeur;
        }
        #endregion public method
    }
}
