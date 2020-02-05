using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ChessMoves.Tests.RedesignTests
{
    public class ValidatorTests
    {
        [Fact]
        public void InvalidArgumentExceptionShouldBeThrownIfUserGivesInputWithoutSpace()
        {
            //Arrange

            //Act
            string userInput = "RookB6";

            //Assert
            var ex = Assert.Throws<ArgumentException>(() => Validator.ValidateInput(userInput));
            Assert.Equal(Validator.InvalidInputError, ex.Message);
        }

        [Fact]
        public void InvalidArgumentExceptionShouldBeThrownIfUserInputsInvalidName()
        {
            //Arrange

            //Act
            string userInputName = "Camel";

            //Assert
            var ex = Assert.Throws<ArgumentException>(() => Validator.ValidateInputName(userInputName));
            Assert.Equal(Validator.InvalidNameError, ex.Message);
        }

        [Theory]
        [InlineData("I6")]
        [InlineData("6B")]
        [InlineData("66")]
        public void InvalidArgumentExceptionShouldBeThrownIfUserInputsInvalidColumnName(string cell)
        {
            //Arrange

            //Act
            string userInputCell = cell;

            //Assert
            var ex = Assert.Throws<ArgumentException>(() => Validator.ValidateInputCell(userInputCell));
            Assert.Equal(Validator.InvalidColumnName, ex.Message);
        }

        [Theory]
        [InlineData("H9")]
        [InlineData("BB")]
        public void InvalidArgumentExceptionShouldBeThrownIfUserInputsInvalidRowNumber(string cell)
        {
            //Arrange

            //Act
            string userInputCell = cell;

            //Assert
            var ex = Assert.Throws<ArgumentException>(() => Validator.ValidateInputCell(userInputCell));
            Assert.Equal(Validator.InvalidRowNumber,ex.Message);
        }
    }
}
