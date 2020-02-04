using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ChessMoves.Tests
{
    public class CellTests
    {
        [Fact]
        public void RowsAndColumnsPropertiesShouldGetAndSetProperly()
        {
            //Arrange
            int expectedRow = 1;
            int expectedColumn = 2;

            //Act
            Cell cell = new Cell();
            cell.Row = 1;
            cell.Column = 2;

            //Assert
            Assert.Equal(expectedRow, cell.Row);
            Assert.Equal(expectedColumn, cell.Column);
        }
    }
}
