using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("ChessMoves.Tests")]
namespace ChessMoves
{
    internal class Cell
    {
        private int _row;
        private int _column;

        public int Row { get { return _row; } set { _row = value; } }

        public int Column { get { return _column; } set { _column = value; } }
    }
}
