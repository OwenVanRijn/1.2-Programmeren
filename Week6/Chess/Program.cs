using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Program
    {
        void PlayChess(Game chessGame)
        {
            Position fromPos = null, toPos = null;
            
            chessGame.Init();
          
            while (chessGame.winner == ChessPieceColor.None)
            {
                chessGame.Display();
                Console.WriteLine($"{chessGame.whoIsActive}, you're up!\n");
                do
                {
                    fromPos = PosTools.ReadPosition("From: ");
                    toPos = PosTools.ReadPosition("To: ");
                } while (!chessGame.CheckMove(fromPos, toPos));

                chessGame.MovePawn(fromPos, toPos);

                Console.WriteLine("Press any key to swap turns");
                Console.ReadKey();
            }

            chessGame.Display();
            Console.WriteLine($"{chessGame.winner} won the game!");

        }
        static void Main(string[] args)
        {
            Program yeet = new Program();
            yeet.Start();
        }
        void Start()
        {
            Game chessGame = new Game();
            PlayChess(chessGame);
         
            Console.ReadKey();
        }
    }
}
