using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Opdracht2
{
    class Program
    {
        List<string> WoordenLijst()
        {
            List<String> woordenlijst = new List<string>();
            StreamReader reader = new StreamReader("words.txt");

            while (!reader.EndOfStream)
            {
                woordenlijst.Add(reader.ReadLine());
            }

            reader.Close();
            return woordenlijst;
        }
        string SelecteerWoord(List<string> woorden)
        {
            int randomnumb;
            Random rnd = new Random();
            do
            {
                randomnumb = rnd.Next(0, woorden.Count());
            } while (woorden[randomnumb].Length <= 3);

            return woorden[randomnumb];
        }
        bool SpeelGalgje(GalgjeSpel galgje)
        {
            List<Char> ingevoerdeLetters = new List<char>();
            int pogingen = 10;
            char laatstechar;

            while (!galgje.IsGeraden() && pogingen > 0)
            {
                Console.Write("\nGeradenwoord: ");
                ToonWoord(galgje.geradenwoord);
                Console.WriteLine("\n");

                laatstechar = LeesLetter(ingevoerdeLetters);
                ingevoerdeLetters.Add(laatstechar);

                if (!galgje.RaadLetter(laatstechar))
                    pogingen--;

                Console.WriteLine($"\nAantal pogingen over: {pogingen}\nIngevoerde letters: ");
                ToonLetters(ingevoerdeLetters);
            }


            Console.WriteLine($"\n\nWoord is {galgje.geheimwoord}");

            return galgje.IsGeraden();
        }
        void ToonLetters(List<char> letters)
        {
            foreach (char letter in letters)
                Console.Write($"{letter} ");
        }
        void ToonWoord(string woord)
        {
            foreach (char letter in woord)
                Console.Write($"{letter} ");
        }
        char LeesLetter(List<char> verbodenLetters)
        {
            char lastchar = '0';
            bool isvalid = false;

            Console.Write("\nGeef een char: ");
            while (!isvalid)
            {
                lastchar = Console.ReadKey().KeyChar;

                if (verbodenLetters.Contains(lastchar))
                    Console.Write("\nVerboden invoer: ");
                else
                    isvalid = true;
            }

            return lastchar;
        }
        static void Main(string[] args)
        {
            Program yeet = new Program();
            yeet.Start();
        }

        void Start()
        {
            bool gewonnen;
            GalgjeSpel galgje = new GalgjeSpel();
            galgje.Init(SelecteerWoord(WoordenLijst()));

            gewonnen = SpeelGalgje(galgje);

            if (gewonnen)
                Console.WriteLine("\nJe hebt gewonnen!");
            else
                Console.WriteLine("\nje hebt verloren :(");

            Console.ReadKey();
        }
    }
}
