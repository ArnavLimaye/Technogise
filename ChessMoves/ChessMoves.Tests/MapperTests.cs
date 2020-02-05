using ChessMoves.PieceClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ChessMoves.Tests.RedesignTests
{
    public class MapperTests
    {
        [Theory]
        [InlineData("Rook",typeof(Rook))]
        [InlineData("pawn", typeof(Pawn))]
        public void ObjectInstanceOfRightTypeShouldBeReturnedByMapper(string pieceName,Type expectedType)
        {
            //Arrange

            //Act
            var piece = Mapper.GetRequiredChessPiece(pieceName);

            //Assert
            Assert.IsType(expectedType, piece);
        }
    }
}
