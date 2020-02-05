using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMoves.PieceClasses
{
    internal class Horse : Piece
    {
        internal override void SearchForAllPossibleMoves(ChessBoard chessBoard)
        {
            SearchForAllPossibleSpecialMoves(chessBoard);
        }
    }
}
