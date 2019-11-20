using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht2
{
    struct Persoon
    {
        public string Voornaam;
        public string Achternaam;
        public int Leeftijd;
        public string Woonplaats;
        public GeslachtType Geslacht;
    }

    public enum GeslachtType
    {
        Man, Vrouw
    }
}
