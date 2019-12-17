using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ToolLib;

namespace Opdracht3
{
    class Program
    {
        Dictionary<string, string> ReadWords(string filename)
        {
            StreamReader reader = new StreamReader(filename);
            Dictionary<string, string> woordenboek = new Dictionary<string, string>();
            string lastreadline;

            while (!reader.EndOfStream)
            {
                lastreadline = reader.ReadLine();
                string[] translation = lastreadline.Split(';');
                woordenboek.Add(translation[0], translation[1]);
            }

            reader.Close();
            return woordenboek;
        }

        void TranslateWords(Dictionary<string, string> words)
        {
            string invoer = "";

            while (invoer != "stop")
            {
                invoer = LeesUtils.LeesString("Enter a word: ");

                switch (invoer)
                {
                    case "stop":
                        break;
                    case "listall":
                        ListAllWords(words);
                        break;
                    default:
                        if (words.ContainsKey(invoer.ToLower()))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"{invoer} => {words[invoer.ToLower()]}");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"word '{invoer}' not found");
                        }
                        Console.ResetColor();
                        break;
                }
            }
        }

        void ListAllWords(Dictionary<string, string> words)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach(KeyValuePair<string, string> word in words)
            {
                Console.WriteLine($"{word.Key} => {word.Value}");
            }
            Console.ResetColor();
        }

        static void Main(string[] args)
        {
            Program yeet = new Program();
            yeet.Start();
        }
        void Start()
        {
            Dictionary<string, string> woordenboek;
            woordenboek = ReadWords("../../dictionary.csv");
            TranslateWords(woordenboek);

            Console.ReadKey();
        }
    }
}