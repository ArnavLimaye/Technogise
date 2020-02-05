using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("ChessPiece.Tests")]
namespace ChessMoves.PieceClasses
{
    internal class Bishop : Piece
    {
        internal override void SearchForAllPossibleMoves(ChessBoard chessboard)
        {
            SearchForAllPossibleDiagonalMoves(chessboard);
        }
    }
}
