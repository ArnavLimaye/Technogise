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
        internal static string InvalidInputError = "Invalid Input";
        internal static string InvalidNameError = "Incorrect Piece Name";
        internal static string InvalidColumnName = "Invalid Column Name";
        internal static string InvalidRowNumber = "Invalid Row Number";
        internal static string InvalidCell = "Invalid Cell";

        public static void ValidateInput(string userInput)
        {
            if (string.IsNullOrEmpty(userInput))
                throw new ArgumentException(InvalidInputError);
            
            string[] nameAndCell = userInput.Split(' ');
            if (nameAndCell.Length != 2)
                throw new ArgumentException(InvalidInputError);
            
            ValidateInputName(nameAndCell[0]);
            ValidateInputCell(nameAndCell[1]);
        }

        internal static void ValidateInputName(string userInputName)
        {
            if (string.IsNullOrEmpty(userInputName))
                throw new ArgumentException(InvalidNameError);
            if (!Initializer.pieceNames.Contains(userInputName.ToLower()))
                throw new ArgumentException(InvalidNameError);
        }

        internal static void ValidateInputCell(string userInputCell)
        {
            if (string.IsNullOrEmpty(userInputCell) || userInputCell.Length != 2)
                throw new ArgumentException(InvalidCell);
            
            char columnName = userInputCell[0];
            char rowName = userInputCell[1];
            if (!Initializer.columnNameToNumberMap.ContainsKey(columnName.ToString().ToUpper()))
                throw new ArgumentException(InvalidColumnName);
            if (!Initializer.rowNameToNumberMap.ContainsKey(rowName.ToString()))
                throw new ArgumentException(InvalidRowNumber);
        }
    }
}
