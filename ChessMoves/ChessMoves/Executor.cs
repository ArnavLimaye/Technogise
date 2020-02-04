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
            
            ChessPiece givenPiece = new ChessPiece();
            givenPiece.MapUserInputToChessPiece(userInput);

            List<Cell> allPossibleMoves = givenPiece.GetAllPossibleMoves();
        }
    }
}
