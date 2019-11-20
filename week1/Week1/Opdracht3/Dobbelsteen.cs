using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht3
{
    class Dobbelsteen
    {
        public int waarde;
        static Random rnd = new Random();

        public void Gooi()
        {
            waarde = rnd.Next(1, 7);
        }

        public void ToonWaarde()
        {
            Console.Write($"{waarde}");
        }
    }
}
