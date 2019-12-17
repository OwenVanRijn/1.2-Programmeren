using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolLib;

namespace Opdracht1
{
    class Program
    {
        static void Main(string[] args)
        {
            Program yeet = new Program();
            yeet.Start();
        }
        void Start()
        {
            int getal = LeesUtils.LeesInt("Yeet een getal: ");
            string naam = LeesUtils.LeesString("Yeet een naam: ");

            Console.WriteLine($"\n{naam}: {getal}");
            Console.ReadKey();
        }
    }
}
