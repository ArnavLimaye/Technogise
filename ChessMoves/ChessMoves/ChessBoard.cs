using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMoves
{
    internal class ChessBoard
    {
        private int _rows = 8;  //Default

        private int _columns = 8;    //Default

        private int[][] _cells;

        public enum MoveTypes{ Horizontal = 1, Vertical, Diagonal, Special, SingleCell, MultiCell }    //Special is for Knight's movement

        public enum RowName { A = 1, B, C, D, E, F, G, H };

        public int Rows { get { return _rows; } set { _rows = value; } }

        public int Columns { get { return _columns; } set { _columns = value; } }

        public ChessBoard()
        {
            _cells = new int[_rows][_columns];
        }
    }
}
