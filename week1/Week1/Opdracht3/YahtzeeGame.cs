using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht3
{
    class YahtzeeGame
    {
        Dobbelsteen[] dobbelstenen = new Dobbelsteen[5];

        public void Init()
        {
            for (int i = 0; i < dobbelstenen.Length; i++)
                dobbelstenen[i] = new Dobbelsteen();
        }

        public void Gooi()
        {
            for (int i = 0; i < dobbelstenen.Length; i++)
                dobbelstenen[i].Gooi();
        }

        public void ToonWorp()
        {
            for (int i = 0; i < dobbelstenen.Length; i++)
            {
                dobbelstenen[i].ToonWaarde();
                Console.Write(" ");
            }
            Console.WriteLine();
        }
        bool CheckForAmount(int amount)
        {
            int[] waarden = new int[6];
            bool isWaarde = false;

            for (int i = 0; i < waarden.Length; i++)
                waarden[i] = 0;

            foreach (Dobbelsteen dobbel in dobbelstenen)
                waarden[dobbel.waarde - 1]++;

            foreach (int waarde in waarden)
                if (waarde == amount)
                {
                    isWaarde = true;
                    break;
                }

            return isWaarde;
        }

        public bool Yahtzee()
        {
            return CheckForAmount(5);
            /*
            if (
                dobbelstenen[0].waarde == dobbelstenen[1].waarde &&
                dobbelstenen[1].waarde == dobbelstenen[2].waarde &&
                dobbelstenen[2].waarde == dobbelstenen[3].waarde &&
                dobbelstenen[3].waarde == dobbelstenen[4].waarde
                ) return true;
            else
                return false;
            */
        }
        public bool ThreeOfAKind()
        {
            return CheckForAmount(3);
        }
        public bool FourOfAKind()
        {
            return CheckForAmount(4);
        }
    }
}
