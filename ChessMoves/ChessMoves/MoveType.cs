using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMoves
{
    //Purpose : This enum helps to improve modularity of the code as one will only have to change 
    //          Initializer.InitializePieceNameToPieceMoveDictioanry e.g. If one supposes to interchange behaviour of Bishop and Rook,
    //          one should only interchange names Bishop and Rook in Initializer.InitializePieceNameToPieceMoveDictioanry 
    
    //Special is for Knight's movement
    public enum MoveType { Horizontal = 1, Vertical, Diagonal, Special, SingleCell, MultiCell, OnlyForward }
}
