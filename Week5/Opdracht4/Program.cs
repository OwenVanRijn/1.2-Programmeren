using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolLib;

namespace Opdracht4
{
    class Program
    {
        void PrintGeradenWoord(LetterKleuren[] letters, string woord)
        {
            for (int i = 0; i < woord.Length; i++)
            {
                switch (letters[i])
                {
                    case LetterKleuren.GREEN:
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Black;
                        break;
                    case LetterKleuren.YELLOW:
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        break;
                }

                Console.Write(woord[i]);
                Console.ResetColor();
            }
            Console.WriteLine();
        }
        bool PlayLingo(ref LingoGame game)
        {
            int pogingen = 5;
            string invoer;
            LetterKleuren[] letters;

            while (!game.HeeftGewonnen() && pogingen > 0)
            {
                Console.WriteLine($"Aantal pogingen: {pogingen}");
                invoer = LeesUtils.LeesString("Geef een 5 letter woord: ", 5, 5);
                letters = game.GuessAttempt(invoer);
                PrintGeradenWoord(letters, invoer);
                pogingen--;
            }

            return game.HeeftGewonnen();
        }
        static void Main(string[] args)
        {
            Program yeet = new Program();
            yeet.Start();
        }
        void Start()
        {
            LingoGame game = new LingoGame();
            bool gewonnen;

            game.Init(LeesUtils.LeesString("Geef mij een LingoWoord: ", 5, 5));
            Console.Clear();

            gewonnen = PlayLingo(ref game);

            if (gewonnen)
                Console.WriteLine("U heeft gewonnen! :D");
            else
                Console.WriteLine("U heeft verloren! :(");

            Console.ReadKey();
        }
    }
}