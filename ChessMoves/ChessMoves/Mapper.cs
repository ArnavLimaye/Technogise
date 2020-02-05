using ChessMoves.PieceClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("ChessMoves.Tests")]
namespace ChessMoves
{
    internal static class Mapper
    {
        internal static Piece GetRequiredChessPiece(string pieceName)
        {
            switch (pieceName.ToLower())
            {
                case "king":
                    return new King();
                case "queen":
                    return new Queen();
                case "bishop":
                    return new Bishop();
                case "rook":
                    return new Rook();
                case "horse":
                    return new Horse();
                default:                        //No other pieceName is possible than given 6 as we validate it before calling this function
                    return new Pawn();
            }
        }
    }
}
