using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht3
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

        bool ScoreRijAanwezig(RegularCandies[,] speelveld)
        {
            bool drierij = false;
            int counter = -1;
            RegularCandies laatsteCandy = RegularCandies.JellyBean; // Compiler yells if i don't define anything

            for (int y = 0; y < speelveld.GetLength(1) && !drierij; y++)
                for (int x = 0; x < speelveld.GetLength(0) && !drierij; x++)
                {
                    if (x == 0)
                    {
                        laatsteCandy = speelveld[x, y];
                        counter = 1;
                        continue;
                    }

                    if (laatsteCandy == speelveld[x, y])
                        counter++;
                    else
                    {
                        counter = 1;
                        laatsteCandy = speelveld[x, y];
                    }   

                    if (counter >= 3)
                        drierij = true;
                }

            return drierij;
        }

        bool ScoreKolomAanwezig(RegularCandies[,] speelveld)
        {
            bool drierij = false;
            int counter = -1;
            RegularCandies laatsteCandy = RegularCandies.JellyBean; // Compiler yells if i don't define anything

            for (int x = 0; x < speelveld.GetLength(0) && !drierij; x++)
                for (int y = 0; y < speelveld.GetLength(1) && !drierij; y++)
                {
                    if (y == 0)
                    {
                        laatsteCandy = speelveld[x, y];
                        counter = 1;
                        continue;
                    }

                    if (laatsteCandy == speelveld[x, y])
                        counter++;
                    else
                    {
                        counter = 1;
                        laatsteCandy = speelveld[x, y];
                    }

                    if (counter >= 3)
                        drierij = true;
                }

            return drierij;
        }


        void Start()
        {
            RegularCandies[,] speelveld = new RegularCandies[9, 9];

            InitCandies(ref speelveld);

            PrintCandies(speelveld);
            Console.WriteLine($"Horizontal: {ScoreRijAanwezig(speelveld)}\nVertical: {ScoreKolomAanwezig(speelveld)}"); 

            Console.ReadKey();
        }
    }
}
