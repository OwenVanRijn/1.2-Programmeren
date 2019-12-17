using System;

namespace CandyLogic
{
    public class CandyCrusher
    {
        public static bool ScoreRijAanwezig(RegularCandies[,] speelveld)
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

        public static bool ScoreKolomAanwezig(RegularCandies[,] speelveld)
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
    }
}
