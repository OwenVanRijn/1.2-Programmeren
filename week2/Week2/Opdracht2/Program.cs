using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht2
{
    class Program
    {
        void InitMatrixRandom(ref int[,] matrix, int min, int max)
        {
            Random rnd = new Random();

            for (int r = 0; r < matrix.GetLength(0); r++)
                for (int k = 0; k < matrix.GetLength(1); k++)
                    matrix[r, k] = rnd.Next(min, max + 1);
        }

        void PrintMatrix(int[,] matrix)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int k = 0; k < matrix.GetLength(1); k++)
                    Console.Write($"{matrix[r, k],3} ");

                Console.WriteLine();
            }
        }

        Positie ZoekGetal(int[,] matrix, int zoekGetal)
        {
            Positie res = new Positie();

            for (int k = 0; k < matrix.GetLength(1) && !res.gevonden; k++)
                for (int r = 0; r < matrix.GetLength(0) && !res.gevonden; r++)
                    if (matrix[r, k] == zoekGetal)
                    {
                        res.gevonden = true;
                        res.rij = r;
                        res.kolom = k;
                    }

            return res;
        }

        Positie ZoekGetalBackwards(int[,] matrix, int zoekGetal)
        {
            Positie res = new Positie();

            for (int k = matrix.GetLength(1) - 1; k >= 0 && !res.gevonden; k--)
                for (int r = matrix.GetLength(0) - 1; r >= 0 && !res.gevonden; r--)
                    if (matrix[r, k] == zoekGetal)
                    {
                        res.gevonden = true;
                        res.rij = r;
                        res.kolom = k;
                    }

            return res;
        }

        static void Main(string[] args)
        {
            Program yeet = new Program();
            yeet.Start();
        }

        void Start()
        {
            int[,] matrix = new int[15, 25];
            int zoekWaarde;
            Positie pos;

            InitMatrixRandom(ref matrix, 1, 100);
            PrintMatrix(matrix);

            Console.Write("\nGeef een int waarde: ");
            zoekWaarde = int.Parse(Console.ReadLine());

            pos = ZoekGetal(matrix, zoekWaarde);

            if (pos.gevonden)
                Console.Write($"\nForwards:\nx={pos.kolom + 1}\ny={pos.rij + 1}");
            else
                Console.Write("\nGetal niet gevonden!");

            pos = ZoekGetalBackwards(matrix, zoekWaarde);

            if (pos.gevonden)
                Console.Write($"\nBackwards:\nx={pos.kolom + 1}\ny={pos.rij + 1}");
            else
                Console.Write("\nGetal niet gevonden!");

            Console.ReadKey();
        }
    }
}
