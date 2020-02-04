using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("ChessMoves.Tests")]
namespace ChessMoves
{
    internal class ChessBoard
    {
        private int _rows = 8;  //Default

        private int _columns = 8;    //Default

        public int Rows { get { return _rows; } set { _rows = value; } }

        public int Columns { get { return _columns; } set { _columns = value; } }
    }
}
