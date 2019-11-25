using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht1
{
    class Program
    {
        static void Main(string[] args)
        {
            Program prog = new Program();
            prog.Start();
        }
        void InitMatrix2D(ref int[,] matrix)
        {
            int waarde = 1;

            for (int r = 0; r < matrix.GetLength(0); r++)
                for (int k = 0; k < matrix.GetLength(1); k++)
                    matrix[r, k] = waarde++;
        }
        void InitMatrixLinear(ref int[,] matrix)
        {
            int r = 0, k = 0;

            for (int waarde = 1; waarde <= matrix.Length; waarde++)
            {
                if (k >= matrix.GetLength(1))
                {
                    r++;
                    k = 0;
                }

                matrix[r, k] = waarde;
                k++;
            }
        }
        void PrintMatrix(int[,] matrix)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int k = 0; k < matrix.GetLength(1); k++)
                    Console.Write($"{matrix[r, k], 3} ");

                Console.WriteLine();
            }
        }

        int InvertNumber(int number, int max)
        { // think of this as reversing the x axis of a grid, if input is 4 and 4 it's result should be 0, and 0 and 4 and it's result should be 4
            return System.Math.Abs(number - max);
        }

        void PrintMatrixWithCross(int[,] matrix)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    Console.ResetColor();

                    if (r == k)
                        Console.ForegroundColor = ConsoleColor.Red;

                    if (InvertNumber(k, matrix.GetLength(1) - 1) == r)
                        Console.BackgroundColor = ConsoleColor.Yellow;

                    Console.Write($"{matrix[r, k],3} ");
                }

                Console.WriteLine();
            }
        }

        void Start()
        {
            int[,] matrix1 = new int[25, 5];
            int[,] matrix2 = new int[25, 25];

            InitMatrix2D(ref matrix1);
            InitMatrixLinear(ref matrix2);

            PrintMatrix(matrix1);
            Console.WriteLine();
            PrintMatrixWithCross(matrix2);

            Console.ReadKey();
        }
    }
}
