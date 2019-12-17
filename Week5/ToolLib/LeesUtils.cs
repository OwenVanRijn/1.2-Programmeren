using System;

namespace ToolLib
{
    public class LeesUtils
    {
        static public int LeesInt(string vraag)
        {
            int ret;

            Console.Write(vraag);
            ret = int.Parse(Console.ReadLine());

            return ret;
        }
        static public int LeesInt(string vraag, int min, int max)
        {
            int ret;

            do
            {
                ret = LeesInt(vraag);
            } while (ret < min || ret > max);

            return ret;
        }
        static public string LeesString(string vraag)
        {
            string ret;

            Console.Write(vraag);
            ret = Console.ReadLine();

            return ret;
        }
        static public string LeesString(string vraag, int min, int max)
        {
            string ret;

            do
            {
                ret = LeesString(vraag);
            } while (ret.Length < min || ret.Length > max);

            return ret;
        }
    }
}
