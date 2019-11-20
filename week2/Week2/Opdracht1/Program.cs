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
        void Start()
        {
            int[,] matrix1 = new int[5, 5];
            int[,] matrix2 = new int[5, 5];

            InitMatrix2D(ref matrix1);
            InitMatrixLinear(ref matrix2);

            PrintMatrix(matrix1);
            Console.WriteLine();
            PrintMatrix(matrix2);

            Console.ReadKey();
        }
    }
}
