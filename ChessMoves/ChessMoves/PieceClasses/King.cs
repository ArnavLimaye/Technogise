using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMoves.PieceClasses
{
    internal class King : Piece
    {
        internal override void SearchForAllPossibleMoves(ChessBoard chessBoard)
        {
            SearchForAllPossibleAdjacentMoves(chessBoard);
        }
    }
}
