using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChessMoves.ChessBoard;

namespace ChessMoves
{
    internal class ChessPiece
    {
        private string _name;

        private List<MoveTypes> _allowedMoveTypes;

        private int _initialCellRow;

        private int _initialCellColumn;

        private List<int> _allowedRows;

        private List<int> _allowedColumns;
        public string Name { get; set; }

        public List<MoveTypes> AllowedMoveTypes { get; set; }

        public int InitialCellRow { get; set; }

        public int InitialColumn { get; set; }

        public List<int> AllowedCellRows { get; set; }

        public List<int> AllowedColumns { get; set; }
    }
}
