﻿using System;
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
        public static Dictionary<string,List<MoveTypes>> pieceNameToPieceMoveMap = new Dictionary<string, List<MoveTypes>>();

        public static Dictionary<string, int> columnNameToNumberMap = new Dictionary<string, int>();

        public static Dictionary<int, string> columnNumberToNameMap = new Dictionary<int, string>();

        public static Dictionary<int, string> rowNumberToNameMap = new Dictionary<int, string>();

        public static Dictionary<string, int> rowNameToNumberMap = new Dictionary<string, int>();

        public static bool firstInstance = true;
        public static void Initialize()
        {
            if (firstInstance)
            {
                InitializePieceMoveDictioanry();

                InitializeColumnNumberToNameDictionary();

                InitializeColumnNameToNumberDictionary();

                InitializeRowNumberToNameDictionary();

                InitializeRowNameToNumberDictionary();

                firstInstance = false;
            }
        }

        private static void InitializeColumnNumberToNameDictionary()
        {
            columnNumberToNameMap.Add(1, "A");
            columnNumberToNameMap.Add(2, "B");
            columnNumberToNameMap.Add(3, "C");
            columnNumberToNameMap.Add(4, "D");
            columnNumberToNameMap.Add(5, "E");
            columnNumberToNameMap.Add(6, "F");
            columnNumberToNameMap.Add(7, "G");
            columnNumberToNameMap.Add(8, "H");
        }                                   

        private static void InitializeColumnNameToNumberDictionary()
        {
            columnNameToNumberMap.Add("A", 1);
            columnNameToNumberMap.Add("B", 2);
            columnNameToNumberMap.Add("C", 3);
            columnNameToNumberMap.Add("D", 4);
            columnNameToNumberMap.Add("E", 5);
            columnNameToNumberMap.Add("F", 6);
            columnNameToNumberMap.Add("G", 7);
            columnNameToNumberMap.Add("H", 8);
        }

        private static void InitializeRowNumberToNameDictionary()
        {
            rowNumberToNameMap.Add(1, "1");
            rowNumberToNameMap.Add(2, "2");
            rowNumberToNameMap.Add(3, "3");
            rowNumberToNameMap.Add(4, "4");
            rowNumberToNameMap.Add(5, "5");
            rowNumberToNameMap.Add(6, "6");
            rowNumberToNameMap.Add(7, "7");
            rowNumberToNameMap.Add(8, "8");
        }

        private static void InitializeRowNameToNumberDictionary()
        {
            rowNameToNumberMap.Add("1", 1);
            rowNameToNumberMap.Add("2", 2);
            rowNameToNumberMap.Add("3", 3);
            rowNameToNumberMap.Add("4", 4);
            rowNameToNumberMap.Add("5", 5);
            rowNameToNumberMap.Add("6", 6);
            rowNameToNumberMap.Add("7", 7);
            rowNameToNumberMap.Add("8", 8);
        }

        private static void InitializePieceMoveDictioanry()
        {
            pieceNameToPieceMoveMap.Add("King", new List<MoveTypes> { MoveTypes.Horizontal, MoveTypes.Vertical, MoveTypes.Diagonal, MoveTypes.SingleCell });
            pieceNameToPieceMoveMap.Add("Queen", new List<MoveTypes> { MoveTypes.Horizontal, MoveTypes.Vertical, MoveTypes.Diagonal, MoveTypes.MultiCell });
            pieceNameToPieceMoveMap.Add("Bishop", new List<MoveTypes> { MoveTypes.Diagonal, MoveTypes.MultiCell });
            pieceNameToPieceMoveMap.Add("Horse", new List<MoveTypes> { MoveTypes.Special });
            pieceNameToPieceMoveMap.Add("Rook", new List<MoveTypes> { MoveTypes.Horizontal, MoveTypes.Vertical, MoveTypes.MultiCell });
            pieceNameToPieceMoveMap.Add("Pawn", new List<MoveTypes> { MoveTypes.Vertical, MoveTypes.SingleCell,MoveTypes.OnlyForward });
        }
    }
}
