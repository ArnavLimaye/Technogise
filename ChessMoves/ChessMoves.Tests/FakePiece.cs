using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMoves.Tests
{
    internal class FakePiece : Piece
    {
        internal override void SearchForAllPossibleMoves(ChessBoard chessboard)
        {
            throw new NotImplementedException();
        }
    }
}
