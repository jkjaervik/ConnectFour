using ConnectFour.Shared.Extensions;
using ConnectFour.Shared.Models;
using ConnectFour.Shared.Utils;
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
            const int ROW = 0;

            // Left-most column has index 0
            const int COLUMN = 0;

            // Period ('.') signifies an empty tile
            Assert.True(board.GetDisc(COLUMN, ROW) == GameBoard.EMPTY_SLOT, "Empty board");
        }

        [Fact]
        public void TestDropDisc()
        {
            var board = GameSimulator.BuildBoard("02");
            /*
             * 1 | . . . . . . . |
             * 0 | X . O . . . . |
             *   -----------------
             *  /  0 1 2 3 4 5 6  \ 
             */
            Assert.True(board.GetDisc(0, 0) == 'X', "Tile 0,0");
            Assert.True(board.GetDisc(1, 0) == GameBoard.EMPTY_SLOT, "Tile 1,0");
            Assert.True(board.GetDisc(2, 0) == 'O', "Tile 2,0");
            Assert.True(board.GetDisc(0, 1) == GameBoard.EMPTY_SLOT, "Tile 0,1");
        }

        [Fact]
        public void TestStacking()
        {
            var board = GameSimulator.BuildBoard("33");
            /*
             * 2 | . . . . . . . |
             * 1 | . . . O . . . |
             * 0 | . . . X . . . |
             *   -----------------
             *  /  0 1 2 3 4 5 6  \ 
             */
            Assert.True(board.GetDisc(3, 0) == 'X', "First dropped");
            Assert.True(board.GetDisc(3, 1) == 'O', "Second dropped");
            Assert.True(board.GetDisc(3, 2) == GameBoard.EMPTY_SLOT, "Two discs stacked");
        }

        [Fact]
        public void TestFullColumns()
        {
            var board = new GameBoard();
            const int COLUMN = 3;
            char[] pieces = {'X', 'O', 'X', 'O', 'X', 'O'};
            foreach (var piece in pieces)
            {
                Assert.False(board.ColumnIsFull(COLUMN));
                board.DropDiscDownColumn(piece, COLUMN);
            }
            Assert.True(board.ColumnIsFull(COLUMN));
        }

        [Fact]
        public void TestExtensionsMethod()
        {
         char[,] _grid = new char[6, 7];
         _grid[0, 0] = 'A';
         _grid[1, 0] = 'B';
         _grid[2, 0] = 'C';
         _grid.GetColumn(0);

        }
    }
}