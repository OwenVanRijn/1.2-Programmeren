using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CandyLogic;

namespace Opdracht2
{
    class Program
    {
        static void Main(string[] args)
        {
            Program yeet = new Program();
            yeet.Start();
        }

        void InitCandies(ref RegularCandies[,] speelveld)
        {
            Random rnd = new Random();

            for (int x = 0; x < speelveld.GetLength(0); x++)
                for (int y = 0; y < speelveld.GetLength(1); y++)
                    speelveld[x, y] = (RegularCandies)rnd.Next(0, 7);
        }

        void PrintCandies(RegularCandies[,] speelveld)
        {
            for (int y = 0; y < speelveld.GetLength(1); y++)
            {
                for (int x = 0; x < speelveld.GetLength(0); x++)
                {
                    switch (speelveld[x, y])
                    {
                        case RegularCandies.JellyBean:
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        case RegularCandies.Lozenge:
                            Console.ForegroundColor = ConsoleColor.Gray;
                            break;
                        case RegularCandies.LemonDrop:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                        case RegularCandies.GumSquare:
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;
                        case RegularCandies.LollipopHead:
                            Console.ForegroundColor = ConsoleColor.Blue;
                            break;
                        case RegularCandies.JujubeCluster:
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            break;
                    }
                    Console.Write("# ");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }

        void SchrijfSpeelveld(RegularCandies[,] speelveld, string bestandsnaam)
        {
            StreamWriter writer = new StreamWriter(bestandsnaam);

            writer.WriteLine($"{speelveld.GetLength(0)} {speelveld.GetLength(1)}");

            for (int y = 0; y < speelveld.GetLength(1); y++)
            {
                for (int x = 0; x < speelveld.GetLength(0); x++)
                {
                    writer.Write($"{(int)speelveld[x, y]} ");
                }
                writer.WriteLine();
            }

            writer.Close();
        }

        RegularCandies[,] LeesSpeelveld(ref StreamReader reader)
        {
            string gelezenregel;
            int xmax, ymax;

            gelezenregel = reader.ReadLine();

            string[] xyparams = gelezenregel.Split(' ');
            xmax = int.Parse(xyparams[0]);
            ymax = int.Parse(xyparams[1]);

            RegularCandies[,] speelveld = new RegularCandies[xmax, ymax];

            for (int y = 0; y < ymax; y++)
            {
                gelezenregel = reader.ReadLine();
                string[] nummers = gelezenregel.Split(' ');
                for (int x = 0; x < xmax; x++)
                {
                    speelveld[x, y] = (RegularCandies)int.Parse(nummers[x]);
                }
            }

            reader.Close();
            return speelveld;
        }

        void Start()
        {
            RegularCandies[,] speelveld = null;
            bool error = false, rij, kolom;

            if (File.Exists("speelveld.txt"))
            {
                StreamReader reader = new StreamReader("speelveld.txt");

                try
                {
                    speelveld = LeesSpeelveld(ref reader);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Something went wrong: {e.Message}");
                    error = true;
                }
                finally
                {
                    reader.Close();
                }
            }
            
            if (!File.Exists("speelveld.txt") || error) //1 "unneeded if statement". This is the fallback if the catch is run.
            {
                speelveld = new RegularCandies[20, 20];
                InitCandies(ref speelveld);
                SchrijfSpeelveld(speelveld, "speelveld.txt");
            }

            PrintCandies(speelveld);
            rij = CandyCrusher.ScoreRijAanwezig(speelveld);
            kolom = CandyCrusher.ScoreKolomAanwezig(speelveld);

            Console.WriteLine($"Horizontal: {rij}\nVertical: {kolom}");
            

            Console.ReadKey();
        }
    }
}
