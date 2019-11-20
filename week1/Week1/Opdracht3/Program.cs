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
            Program prog = new Program();
            prog.Start();
        }
        
        void Start()
        {
            YahtzeeGame yahtzee = new YahtzeeGame();
            int aantalPogingen = 0;
            yahtzee.Init();

            do
            {
                yahtzee.Gooi();
                yahtzee.ToonWorp();

                aantalPogingen++;
            } while (!yahtzee.Yahtzee());

            Console.WriteLine($"Aantal pogingen: {aantalPogingen}");

            Console.ReadKey();
        }
    }
}
