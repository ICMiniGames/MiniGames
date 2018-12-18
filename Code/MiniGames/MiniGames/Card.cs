using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGames
{
    public class Card
    {
        string Name;
        string LinkImage;
        string Symbole;
        int Valeur;
        public Card(string Name, string LinkImage, string Symbole, int Valeur)
        {
            this.Name = Name;
            this.LinkImage = LinkImage;
            this.Symbole = Symbole;
            this.Valeur = Valeur;
        }

        public string GetName()
        {
            return Name;
        }

        public string GetLink()
        {
            return LinkImage;
        }

        public string GetSymbole()
        {
            return Symbole;
        }

        public int GetValeur()
        {
            return Valeur;
        }

    }
}
