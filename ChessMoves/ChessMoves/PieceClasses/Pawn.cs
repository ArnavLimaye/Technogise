using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("ChessPiece.Tests")]
namespace ChessMoves.PieceClasses
{
    internal class Pawn : Piece
    {
        internal Pawn()
        {
            initialCell = new Cell();
            allPossibleMoves = new List<Cell>();
        }

        internal override void SearchForAllPossibleMoves(ChessBoard chessboard)
        {
            AddCell(initialCell.row + 1, initialCell.column, chessboard);
        }
    }
}
