using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht2
{
    class Program
    {
        Utils utils = new Utils();

        static void Main(string[] args)
        {
            Program Opdracht = new Program();
            Opdracht.Start();
        }
        GeslachtType LeesGeslact(string vraag)
        {
            string geslachtstring;
            GeslachtType geslacht;

            do
            {
                geslachtstring = utils.LeesString(vraag);
            } while (geslachtstring.ToLower() != "m" && geslachtstring.ToLower() != "v");

            if (geslachtstring.ToLower() == "m")
                geslacht = GeslachtType.Man;
            else
                geslacht = GeslachtType.Vrouw;

            return geslacht;
        }

        Persoon LeesPersoon()
        {
            Persoon pers;

            pers.Voornaam = utils.LeesString("Geef Voornaam: ");
            pers.Achternaam = utils.LeesString("Geef Achternaam: ");
            pers.Geslacht = LeesGeslact("Geef Geslacht (m/v): ");
            pers.Leeftijd = utils.LeesLimtedInt("Geef leeftijd: ", 0, 120);
            pers.Woonplaats = utils.LeesString("Geef Woonplaats: ");

            return pers;
        }

        void PrintGeslacht(GeslachtType geslacht)
        {
            string geslachtstring;

            if (geslacht == GeslachtType.Man)
                geslachtstring = "m";
            else
                geslachtstring = "v";

            Console.WriteLine($"({geslachtstring})");
        }

        void PrintPersoon(Persoon p)
        {
            Console.Write($"{p.Voornaam} {p.Achternaam} ");
            PrintGeslacht(p.Geslacht);
            Console.WriteLine($"{p.Leeftijd} jaar, {p.Woonplaats}");
        }

        void VierVerjaardag(ref Persoon p)
        {
            Console.WriteLine($"Verjaardag vieren van {p.Voornaam} {p.Achternaam}");
            p.Leeftijd++;
        }

        void Start()
        {
            Persoon[] personen = new Persoon[3];

            for (int i = 0; i < personen.Length; i++)
            {
                personen[i] = LeesPersoon();
                Console.WriteLine();
            }

            foreach (Persoon persoon in personen)
            {
                PrintPersoon(persoon);
                Console.WriteLine();
            }

            VierVerjaardag(ref personen[0]);
            PrintPersoon(personen[0]);

            Console.ReadKey();
        }
    }
}
