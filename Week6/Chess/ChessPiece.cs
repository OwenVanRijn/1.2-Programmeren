using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public enum ChessPieceColor
    {
        Black,
        White,
        None
    }
    public enum ChessPieceType
    {
        pawn,
        rook,
        knight,
        bishop,
        King,
        Queen
    }
    public static class ChessPieceHelper 
    {
        public static ChessPieceType[] order =
        {
            ChessPieceType.rook,
            ChessPieceType.knight,
            ChessPieceType.bishop,
            ChessPieceType.King,
            ChessPieceType.Queen,
            ChessPieceType.bishop,
            ChessPieceType.knight,
            ChessPieceType.rook
        };
        public static void DisplayChessPiece(ChessPiece piece)
        {
            if (piece == null)
                Console.Write("   ");
            else
            {
                Console.ForegroundColor = (piece.color == ChessPieceColor.White) ? ConsoleColor.White : ConsoleColor.Black;
                Console.Write($" {piece.type.ToString()[0]} ");
            }
        }
        public static void InitChessPiece(ref ChessPiece piece, ChessPieceColor color, ChessPieceType type)
        {
            piece = new ChessPiece();
            piece.color = color;
            piece.type = type;
            piece.firstTurn = true;
        }
        public static void InitChessPieces(ref ChessPiece[,] chessBoard)
        {
            for (int x = 0; x < chessBoard.GetLength(0); x++)
            {
                if (x == 0 || x == 7)
                    for (int y = 0; y < chessBoard.GetLength(1); y++)
                        InitChessPiece(ref chessBoard[x, y], (x < 4) ? ChessPieceColor.White : ChessPieceColor.Black, ChessPieceHelper.order[y]);

                if (x == 1 || x == 6)
                    for (int y = 0; y < chessBoard.GetLength(1); y++)
                        InitChessPiece(ref chessBoard[x, y], (x < 4) ? ChessPieceColor.White : ChessPieceColor.Black, ChessPieceType.pawn);
            }
        }
    }
   public class ChessPiece
    {
        public ChessPieceColor color;
        public ChessPieceType type;
        public bool firstTurn;
    }
}
