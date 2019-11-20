using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht0
{
    class Program
    {
        int LeesInt(string vraag)
        {
            int ret;

            Console.Write(vraag);
            ret = int.Parse(Console.ReadLine());

            return ret;
        }

        int LeesInt(string vraag, int min, int max)
        {
            int ret;

            do
            {
                ret = LeesInt(vraag);
            } while (ret < min || ret > max);

            return ret;
        }

        string LeesString(string vraag)
        {
            string ret;
          
            Console.Write(vraag);
            ret = Console.ReadLine();

            return ret;
        }

        static void Main(string[] args)
        {
            Program Opdracht = new Program();
            Opdracht.Start();
        }

        void Start()
        {
            int getal = LeesInt("Geeft een getal: ");
            Console.WriteLine($"Getal: {getal}");

            int leeftijd = LeesInt("Geef een leeftijd: ", 0, 120);
            Console.WriteLine($"Leeftijd: {leeftijd}");

            string naam = LeesString("Naam: ");
            Console.WriteLine($"Naam: {naam}");

            Console.ReadKey();
        }
    }
}
