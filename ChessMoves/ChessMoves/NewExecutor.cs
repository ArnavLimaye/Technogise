using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("ChessMoves.Tests")]
namespace ChessMoves
{
    internal class NewExecutor
    {
        public static void Main(string[] args)
        {
            string userInput;
            Initializer.Initialize();

            Console.WriteLine("Enter the input");
            userInput = Console.ReadLine();

            ChessBoard chessBoard = new ChessBoard();

            Validator.ValidateInput(userInput);

            string pieceName = userInput.Split()[0];
            string cellString = userInput.Split()[1];
            
            Piece piece = Mapper.GetRequiredChessPiece(pieceName);
            piece.MapUserInputCellToChessPieceInitialCell(cellString);

            piece.SearchForAllPossibleMoves(chessBoard);
            
            string outputString = CreateDisplayStringFromCells(piece.allPossibleMoves);

            Console.WriteLine(outputString);
            Console.ReadKey();
        }

        private static string CreateDisplayStringFromCells(List<Cell> allowedCells)
        {
            if (allowedCells == null || allowedCells.Count == 0)
                return "There are no possible moves for the given piece from given cell";
            string output = "";
            for (int i = 0; i < allowedCells.Count; i++)
            {
                output += Initializer.columnNumberToNameMap[allowedCells[i].column];
                output += Initializer.rowNumberToNameMap[allowedCells[i].row];
                if (i < allowedCells.Count - 1)
                    output += ",";
            }
            return output;
        }
    }
}
