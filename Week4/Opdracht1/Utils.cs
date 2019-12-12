using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht1
{
    class Utils
    {
        public int LeesInt(string vraag)
        {
            int ret;

            Console.Write(vraag);
            ret = int.Parse(Console.ReadLine());

            return ret;
        }
        public int LeesInt(string vraag, int min, int max)
        {
            int ret;

            do
            {
                ret = LeesInt(vraag);
            } while (ret < min || ret > max);

            return ret;
        }
        public string LeesString(string vraag)
        {
            string ret;

            Console.Write(vraag);
            ret = Console.ReadLine();

            return ret;
        }
    }
}
