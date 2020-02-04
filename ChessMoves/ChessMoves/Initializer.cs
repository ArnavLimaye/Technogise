using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static ChessMoves.ChessPiece;

[assembly: InternalsVisibleTo("ChessMoves.Tests")]
namespace ChessMoves
{
    //To initialize the chessboard and chess pieces according to default rules
    internal static class Initializer
    {
        public static Dictionary<string,List<MoveTypes>> pieceMoveDictionary = new Dictionary<string, List<MoveTypes>>();

        public static Dictionary<string, int> columnNumberToNameDictionary = new Dictionary<string, int>();

        public static Dictionary<int, string> columnNameToNumberDictionary = new Dictionary<int, string>();

        public static void Initialize()
        {
            InitializePieceMoveDictioanry(pieceMoveDictionary);

            InitializeRowNumberNameDictionary(columnNumberToNameDictionary);

            InitializeRowNameNumberDictionary(columnNameToNumberDictionary);
        }

        private static void InitializeRowNameNumberDictionary(Dictionary<int, string> columnNameToNumberDictionary)
        {
            columnNameToNumberDictionary.Add(1, "A");
            columnNameToNumberDictionary.Add(2, "B");
            columnNameToNumberDictionary.Add(3, "C");
            columnNameToNumberDictionary.Add(4, "D");
            columnNameToNumberDictionary.Add(5, "E");
            columnNameToNumberDictionary.Add(6, "F");
            columnNameToNumberDictionary.Add(7, "G");
            columnNameToNumberDictionary.Add(8, "H");
        }                                   

        private static void InitializeRowNumberNameDictionary(Dictionary<string, int> columnNumberToNameDictionary)
        {
            columnNumberToNameDictionary.Add("A", 1);
            columnNumberToNameDictionary.Add("B", 2);
            columnNumberToNameDictionary.Add("C", 3);
            columnNumberToNameDictionary.Add("D", 4);
            columnNumberToNameDictionary.Add("E", 5);
            columnNumberToNameDictionary.Add("F", 6);
            columnNumberToNameDictionary.Add("G", 7);
            columnNumberToNameDictionary.Add("H", 8);
        }

        private static void InitializePieceMoveDictioanry(Dictionary<string, List<MoveTypes>> pieceMoveDictionary)
        {
            Initializer.pieceMoveDictionary.Add("King", new List<MoveTypes> { MoveTypes.Horizontal, MoveTypes.Vertical, MoveTypes.Diagonal, MoveTypes.SingleCell });
            Initializer.pieceMoveDictionary.Add("Queen", new List<MoveTypes> { MoveTypes.Horizontal, MoveTypes.Vertical, MoveTypes.Diagonal, MoveTypes.MultiCell });
            Initializer.pieceMoveDictionary.Add("Bishop", new List<MoveTypes> { MoveTypes.Diagonal, MoveTypes.MultiCell });
            Initializer.pieceMoveDictionary.Add("Knight", new List<MoveTypes> { MoveTypes.Special });
            Initializer.pieceMoveDictionary.Add("Rook", new List<MoveTypes> { MoveTypes.Horizontal, MoveTypes.Vertical, MoveTypes.MultiCell });
            Initializer.pieceMoveDictionary.Add("Pawn", new List<MoveTypes> { MoveTypes.Vertical, MoveTypes.SingleCell });
        }
    }
}
