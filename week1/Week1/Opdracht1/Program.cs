using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht1
{
    class Program
    {
        void PrintMaand(Maand maand)
        {
            Console.WriteLine(maand);
        }

        void PrintMaanden()
        {
            for (int i = 1; i <= 12; i++)
            {
                Console.Write($"{i,2}. ");
                PrintMaand((Maand)i);
            }
        }

        Maand VraagMaand(string vraag)
        {
            int intMaand = -1;
            bool validMaand = false;


            while (!validMaand)
            {
                Console.Write(vraag);
                intMaand = int.Parse(Console.ReadLine());

                validMaand = Enum.IsDefined(typeof(Maand), (Maand)intMaand);

                if (!validMaand)
                    Console.WriteLine($"{intMaand} is geen geldige waarde");
            }

            return (Maand) intMaand;
        }

        static void Main(string[] args)
        {
            Program Opdracht = new Program();
            Opdracht.Start();
        }

        void Start()
        {
            Maand res;

            PrintMaand(Maand.September);
            PrintMaand((Maand)4);

            PrintMaanden();

            res = VraagMaand("Geef een maand: ");
            PrintMaand(res);

            Console.ReadKey();
        }
    }
}