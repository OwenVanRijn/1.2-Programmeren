using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht1
{
    enum PraktijkBeoordeling
    {
        Geen,
        Absent,
        Onvoldoende,
        Voldoende,
        Goed
    }
    class Vak
    {
        public string naam;
        public int theorie_cijfer;
        public PraktijkBeoordeling praktijk_cijfer;

        public bool IsBehaald()
        {
            if (praktijk_cijfer >= PraktijkBeoordeling.Voldoende && theorie_cijfer >= 55)
                return true;
            else
                return false;
        }
        public bool IsCumLaude()
        {
            if (praktijk_cijfer >= PraktijkBeoordeling.Goed && theorie_cijfer >= 80)
                return true;
            else
                return false;
        }
    }
}
