using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Opdracht1
{
    class Program
    {
        Utils util = new Utils();
        Persoon LeesPersoon()
        {
            Persoon pers = new Persoon();

            pers.naam = util.LeesString("Wat is uw naam?: ");
            pers.woonplaats = util.LeesString("Wat is uw woonplaats?: ");
            pers.leeftijd = util.LeesInt("Wat is uw leeftijd?: ");

            return pers;
        }
        void ToonPersoon(Persoon p)
        {
            Console.WriteLine($"{"Naam",-10}: {p.naam}");
            Console.WriteLine($"{"Woonplaats",-10}: {p.woonplaats}");
            Console.WriteLine($"{"Leeftijd",-10}: {p.leeftijd}");
        }
        void SchrijfPersoon(Persoon p, string bestandNaam)
        {
            StreamWriter writer = new StreamWriter($"{bestandNaam}.txt");

            writer.WriteLine($"{p.naam}");
            writer.WriteLine($"{p.woonplaats}");
            writer.WriteLine($"{p.leeftijd}");

            writer.Close();
        }
        Persoon LeesPersoon(string bestandNaam)
        {
            StreamReader reader = new StreamReader($"{bestandNaam}.txt");
            Persoon pers = new Persoon();

            pers.naam = reader.ReadLine();
            pers.woonplaats = reader.ReadLine();
            pers.leeftijd = int.Parse(reader.ReadLine());

            reader.Close();
            return pers;
        }
        static void Main(string[] args)
        {
            Program yeet = new Program();
            yeet.Start();
        }
        void Start()
        {
            string naam;
            Persoon p;

            naam = util.LeesString("Wat is uw naam? ");
            if (File.Exists($"{naam}.txt"))
            {
                Console.WriteLine("Welcome back!");
                p = LeesPersoon(naam);
                ToonPersoon(p);
            }
            else
            {
                Console.WriteLine("Welcome new person!");
                p = LeesPersoon();
                SchrijfPersoon(p, naam);
                Console.WriteLine("Uw gegevens zijn gestolen, hartelijk dank");
            }

            Console.ReadKey();
        }
    }
}
