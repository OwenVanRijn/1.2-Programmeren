using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolLib;

namespace Chess
{
    public static class PosTools
    {
        public static Position ReadPosition(string question)
        {
            bool isValid = false;
            string lastRead;
            Position pos = new Position();

            while (!isValid)
            {
                lastRead = ToolLib.LeesUtils.LeesString(question).ToUpper();

                if (lastRead.Length < 2)
                    Console.WriteLine("Invalid Input");
                else if (lastRead[0] - 'A' >= 0 && lastRead[0] - 'A' <= 8 && int.Parse(lastRead[1].ToString()) > 0 && int.Parse(lastRead[1].ToString()) <= 8)
                {
                    pos.y = lastRead[0] - 'A';
                    pos.x = int.Parse(lastRead[1].ToString()) - 1; 
                    isValid = true;
                }
                else
                    Console.WriteLine("Invalid Input");
            }

            return pos;
        }
        
        public static Position getPos(int x, int y)
        {
            Position pos = new Position();
            pos.x = x;
            pos.y = y;
            return pos;
        }
    }
    public class Position
    {
        public int x, y;
    }
}
