using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("ChessMoves.Tests")]
namespace ChessMoves
{
    public class Executor
    {
        public static void Main(string[] args)
        {
            string userInput;
            Initializer.Initialize();

            Console.WriteLine("Enter the input");
            userInput = Console.ReadLine();
            
            ChessBoard chessBoard = new ChessBoard();
            
            ChessPiece givenPiece = new ChessPiece();
            givenPiece.MapUserInputToChessPiece(userInput);

            givenPiece.GetAllPossibleMoves(chessBoard);

            string outputString = CreateDisplayStringFromCells(givenPiece.allowedCells);

            Console.WriteLine(outputString);
            Console.ReadKey();
        }

        private static string CreateDisplayStringFromCells(List<Cell> allowedCells)
        {
            if (allowedCells == null || allowedCells.Count == 0)
                return "There are no possible moves for the given piece from given cell";
            string output = "";
            for(int i=0;i<allowedCells.Count;i++)
            {
                output += Initializer.columnNumberToNameMap[allowedCells[i].column];
                output += Initializer.rowNumberToNameMap[allowedCells[i].row];
                if(i < allowedCells.Count - 1)
                    output += ",";
            }
            return output;
        }
    }
}
