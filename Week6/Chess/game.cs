using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// small big error. x is now the vertical value, y is the horizontal value

namespace Chess
{
    class Game
    {
        public ChessPiece[,] chessBoard;
        public ChessPieceColor whoIsActive;
        public ChessPieceColor winner;

        public void Init()
        {
            chessBoard = new ChessPiece[8, 8];

            for (int x = 0; x < chessBoard.GetLength(0); x++)
                for (int y = 0; y < chessBoard.GetLength(1); y++)
                    chessBoard[x, y] = null;

            ChessPieceHelper.InitChessPieces(ref chessBoard);

            whoIsActive = ChessPieceColor.White;
            winner = ChessPieceColor.None;
        }

        public void Display()
        {
            Console.Clear();
            Console.WriteLine("   A  B  C  D  E  F  G  H");

            for (int x = 0; x < chessBoard.GetLength(0); x++)
            {
                Console.Write($"{x + 1} ");

                for (int y = 0; y < chessBoard.GetLength(1); y++)
                {
                    Console.BackgroundColor = ((x + y) % 2 == 0) ? ConsoleColor.DarkCyan : ConsoleColor.DarkGray;
                    ChessPieceHelper.DisplayChessPiece(chessBoard[x, y]);
                }

                Console.WriteLine();
                Console.ResetColor();
            }
        }
        public void MovePawn(Position fromPos, Position toPos)
        {
            chessBoard[toPos.x, toPos.y] = chessBoard[fromPos.x, fromPos.y];
            chessBoard[fromPos.x, fromPos.y] = null;
            whoIsActive = (whoIsActive == ChessPieceColor.White) ? ChessPieceColor.Black : ChessPieceColor.White;
        }
        private bool PathGen(Position fromPos, Position toPos)
        {
            bool isValid;
            int xchange = fromPos.x - toPos.x, ychange = fromPos.y - toPos.y;
            int xsinglechange, ysinglechange;

            xsinglechange = (xchange == 0) ? 0 : ((xchange < 0) ? 1 : -1);
            ysinglechange = (ychange == 0) ? 0 : ((ychange < 0) ? 1 : -1);

            Position looppos = PosTools.getPos(fromPos.x + xsinglechange, fromPos.y + ysinglechange);

            isValid = true;
            while ((looppos.x != toPos.x || looppos.y != toPos.y) && isValid)
            {
                if (chessBoard[looppos.x, looppos.y] != null)
                    isValid = false;

                looppos.x += xsinglechange;
                looppos.y += ysinglechange;
            }

            return isValid;
        }
        public bool CheckMove(Position fromPos, Position toPos)
        {
            bool isValid = false;

            if (chessBoard[fromPos.x, fromPos.y] != null)
            {
                if (chessBoard[fromPos.x, fromPos.y].color != whoIsActive)
                {
                    Console.WriteLine("Invalid from position (fromPos is not your color)");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Invalid from position (fromPos is nothing)");
                return false;
            }

            if (chessBoard[toPos.x, toPos.y] != null)
            {
                if (chessBoard[toPos.x, toPos.y].color == whoIsActive)
                {
                    Console.WriteLine("Invalid to position (ToPos is the same color of pawn as you!)");
                    return false;
                }
            }
            switch (chessBoard[fromPos.x, fromPos.y].type)
            {
                case ChessPieceType.pawn:
                    if (chessBoard[toPos.x, toPos.y] == null)
                    {
                        if (fromPos.y != toPos.y)
                        {
                            isValid = false;
                        }
                        else if (toPos.x - fromPos.x == ((whoIsActive == ChessPieceColor.White) ? 1 : -1))
                        {
                            chessBoard[fromPos.x, fromPos.y].firstTurn = false;
                            isValid = true;
                        }
                        else if (toPos.x - fromPos.x == ((whoIsActive == ChessPieceColor.White) ? 2 : -2) && chessBoard[fromPos.x, fromPos.y].firstTurn)
                        {
                            chessBoard[fromPos.x, fromPos.y].firstTurn = false;
                            isValid = true;
                        }
                        else
                            isValid = false;
                    }
                    else
                    {
                        if ((fromPos.x + ((whoIsActive == ChessPieceColor.White) ? 1 : -1) == toPos.x) && (Math.Abs(fromPos.y - toPos.y) == 1))
                            isValid = true;
                        else
                            isValid = false;
                    }
                    break;
                case ChessPieceType.rook:
                    if (fromPos.x == toPos.x || fromPos.y == toPos.y)
                    {
                        isValid = this.PathGen(fromPos, toPos);
                    }
                    else
                        isValid = false;
                    break;
                case ChessPieceType.knight:
                    if (Math.Abs(fromPos.y - toPos.y) == 1 && Math.Abs(fromPos.x - toPos.x) == 2)
                    {
                        isValid = true;
                    }
                    else if (Math.Abs(fromPos.y - toPos.y) == 2 && Math.Abs(fromPos.x - toPos.x) == 1)
                    {
                        isValid = true;
                    }
                    else
                        isValid = false;
                    break;
                case ChessPieceType.King:
                    if (Math.Abs(fromPos.y - toPos.y) <= 1 && Math.Abs(fromPos.x - toPos.x) <= 1)
                        isValid = true;
                    else
                        isValid = false;
                    break;
                case ChessPieceType.bishop:
                    if (Math.Abs(fromPos.x - toPos.x) == Math.Abs(fromPos.y - toPos.y))
                    {
                        isValid = this.PathGen(fromPos, toPos);
                    }
                    else
                        isValid = false;
                    break;
                case ChessPieceType.Queen:
                    if (fromPos.x == toPos.x || fromPos.y == toPos.y || Math.Abs(fromPos.x - toPos.x) == Math.Abs(fromPos.y - toPos.y))
                    {
                        isValid = this.PathGen(fromPos, toPos);
                    }
                    else
                        isValid = false;
                    break;
            }

            if (chessBoard[toPos.x, toPos.y] != null && isValid)
            {
                if (chessBoard[toPos.x, toPos.y].type == ChessPieceType.King)
                    winner = whoIsActive;
            }

            if (!isValid)
                Console.WriteLine("Your character cannot move like this!");

            return isValid;
        }
    }
}
