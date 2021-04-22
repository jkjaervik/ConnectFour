using System.Diagnostics;
using ConnectFour.Shared.Models;
using Xunit;

namespace ConnectFourTests
{
    public class ConnectFourTests
    {
        [Fact]
        public void TestEmptyTile()
        {
            var board = new GameBoard();

            // Bottom row has index 0
            var row = 0;

            // Left-most column has index 0
            var column = 0;

            // Period ('.') signifies an empty tile
            Debug.Assert(board.GetDisc(column, row) == '.');
        }
    }
}
