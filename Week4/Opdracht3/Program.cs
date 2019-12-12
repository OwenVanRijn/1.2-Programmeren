using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Opdracht3
{
    class Program
    {
        Utils util = new Utils();
        bool ZitWoordInRegel(string regel, string woord)
        {
            foreach (string woordinregel in regel.Split(' '))
            {
                if (woord.ToLower() == woordinregel.ToLower())
                    return true;
            }
            return false;
        }
        int ZoekWoordInBestand(string bestandsnaam, string woord)
        {
            StreamReader reader = new StreamReader(bestandsnaam);
            int regels = 0;
            string gelezenRegel;

            while (!reader.EndOfStream)
            {
                gelezenRegel = reader.ReadLine();
                if (ZitWoordInRegel(gelezenRegel, woord))
                {
                    ToonWoordInRegel(gelezenRegel, woord);
                    regels++;
                }
            }

            reader.Close();
            return regels;
        }
        void ToonWoordInRegel(string regel, string inwoord)
        {
            string prewoord, afterwoord, woord;
            int woordlocatie;

            woordlocatie = regel.ToLower().IndexOf(inwoord.ToLower());

            prewoord = regel.Substring(0, woordlocatie);
            woord = regel.Substring(woordlocatie, inwoord.Length);
            afterwoord = regel.Substring(woordlocatie + inwoord.Length);

            Console.Write(prewoord);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(woord);
            Console.ResetColor();
            Console.WriteLine(afterwoord);
        }
        static void Main(string[] args)
        {
            Program yeet = new Program();
            yeet.Start();
        }
        void Start()
        {
            string search;
            int amount;

            search = util.LeesString("Enter a word to search: ");
            amount = ZoekWoordInBestand("trump2018.txt", search);
            Console.WriteLine($"\n\nNumber of lines containing the word: {amount}");
            Console.ReadKey();
        }
    }
}