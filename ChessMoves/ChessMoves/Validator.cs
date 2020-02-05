using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("ChessMoves.Tests")]
namespace ChessMoves
{
    internal static class Validator
    {
        internal static string InvalidInputError = "Invalid Input : No Space Between Piece Name and Initial Cell";
        internal static string InvalidNameError = "Incorrect Piece Name";
        internal static string InvalidColumnName = "Invalid Column Name";
        internal static string InvalidRowNumber = "Invalid Row Number";

        public static void ValidateInput(string userInput)
        {
            throw new NotImplementedException();
        }

        internal static void ValidateInputName(string userInputName)
        {
            throw new NotImplementedException();
        }

        internal static void ValidateInputCell(string userInputCell)
        {
            throw new NotImplementedException();
        }
    }
}
