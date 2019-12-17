using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht4
{
    public enum LetterKleuren
    {
        NONE = 0,
        YELLOW,
        GREEN
    }
    class LingoGame
    {
        private string laatstIngevoerdeWoord;
        private string geheimwoord;

        public void Init(string woord)
        {
            geheimwoord = woord;
            laatstIngevoerdeWoord = "";
        }

        public LetterKleuren[] GuessAttempt(string woord)
        {
            LetterKleuren[] letters = new LetterKleuren[woord.Length];
            laatstIngevoerdeWoord = woord;

            for (int i = 0; i < letters.Length; i++)
                letters[i] = LetterKleuren.NONE;

            for (int guess = 0; guess < woord.Length; guess++)
            {
                if (geheimwoord[guess] == woord[guess])
                    letters[guess] = LetterKleuren.GREEN;

                else for (int posSecret = 0; posSecret < geheimwoord.Length; posSecret++)
                {
                    if (geheimwoord[posSecret] == woord[guess])
                    {
                        letters[guess] = LetterKleuren.YELLOW;
                    }
                }
            }

            return letters;
        }

        public bool HeeftGewonnen()
        {
            return (geheimwoord == laatstIngevoerdeWoord);
        }
    }
}