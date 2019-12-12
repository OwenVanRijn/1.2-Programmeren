using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht1
{
    class Program
    {
        Utils utils = new Utils();

        PraktijkBeoordeling LeesPraktijkBeoordeling(string vraag)
        {
            return (PraktijkBeoordeling)utils.LeesInt(vraag);
        }
        void ToonPraktijkBeoordeling(PraktijkBeoordeling praktijk_cijfer)
        {
            Console.Write(praktijk_cijfer);
        }
        Vak LeesVak(string vraag)
        {
            Vak vak = new Vak();
            Console.WriteLine(vraag);

            vak.naam = utils.LeesString("Voer de naam van het vak in: ");
            vak.theorie_cijfer = utils.LeesInt("Voer het TheorieCijfer in: ");
            vak.praktijk_cijfer = LeesPraktijkBeoordeling("0: Geen 1. Absent 2. Onvoldoende 3. Voldoende 4. Goed\nVoer het PrakticumCijfer in: ");

            return vak;
        }
        void ToonVak(Vak vak)
        {
            Console.WriteLine($"{vak.naam,-10} : {vak.theorie_cijfer}, {vak.praktijk_cijfer}");
        }
        List<Vak> LeesRapport(int aantalVakken)
        {
            List<Vak> rapport = new List<Vak>();

            for (int i = 0; i < aantalVakken; i++)
            {
                rapport.Add(LeesVak($"Voer vak nummer {i + 1} in:"));
                Console.WriteLine();
            }

            return rapport;    
        }
        void ToonRapport(List<Vak> rapport)
        {
            bool IsCumLaudeGeslaagd = true, IsGeslaagd = true;
            int herkansingen = 0;

            foreach (Vak vak in rapport)
            {
                ToonVak(vak);

                if (!vak.IsCumLaude())
                    IsCumLaudeGeslaagd = false;

                if (!vak.IsBehaald())
                {
                    IsGeslaagd = false;
                    herkansingen++;
                }
            }

            if (IsCumLaudeGeslaagd)
                Console.WriteLine("Gefeliciteerd, je bent Cumlaude geslaagd");
            else if (IsGeslaagd)
                Console.WriteLine("Gefeliciteerd, je bent geslaagd");
            else
                Console.WriteLine($"Helaas, je bent gezakt en hebt {herkansingen} herkansingen");
        }
        static void Main(string[] args)
        {
            Program yeet = new Program();
            yeet.Start();
        }

        void Start()
        {
            List<Vak> rapport;

            rapport = LeesRapport(3);
            ToonRapport(rapport);

            Console.ReadKey();
        }
    }
}
