using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMoves.PieceClasses
{
    internal class Queen : Piece
    {
        internal override void SearchForAllPossibleMoves(ChessBoard chessBoard)
        {
            SearchForAllPossibleDiagonalMoves(chessBoard);
            SearchForAllPossibleHorizontalMoves(chessBoard);
            SearchForAllPossibleVerticalMoves(chessBoard);
        }
    }
}
