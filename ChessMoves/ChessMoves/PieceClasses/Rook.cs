using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMoves.PieceClasses
{
    internal class Rook : Piece
    {
        internal override void SearchForAllPossibleMoves(ChessBoard chessBoard)
        {
            SearchForAllPossibleHorizontalMoves(chessBoard);
            SearchForAllPossibleVerticalMoves(chessBoard);
        }
    }
}
