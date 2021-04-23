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
        public void TestIsValidComlumnChoice()
        {
            var board = GameSimulator.BuildBoard("111111");
            /*
            * 5 | . O . . . . . |
            * 4 | . X . . . . . |
            * 3 | . O . . . . . |
            * 2 | . X . . . . . |
            * 1 | . O . . . . . |
            * 0 | . X . . . . . |
            *   -----------------
            *  /  0 1 2 3 4 5 6  \ 
            */
            Assert.False(board.IsValidColumn(-1));
            Assert.True(board.IsValidColumn(0));
            Assert.False(board.IsValidColumn(1));
            Assert.True(board.IsValidColumn(6));
            Assert.False(board.IsValidColumn(7));
        }

        [Fact]
        public void TestSimpleGameStatus()
        {
            var board = new GameBoard();
            /*
           * 5 | . . . . . . . |
           * 4 | . . . . . . . |
           * 3 | . . . . . . . |
           * 2 | . . . . . . . |
           * 1 | . . . . . . . |
           * 0 | . . . . . . . |
           *   -----------------
           *  /  0 1 2 3 4 5 6  \ 
           */
            Assert.False(board.GameIsOver(), "start");
            board = GameSimulator.BuildBoard("340222244");
            /*
          * 5 | . . . . . . . |
          * 4 | . . . . . . . |
          * 3 | . . X . . . . |
          * 2 | . . O . X . . |
          * 1 | . . X . O . . |
          * 0 | X . O X O . . |
          *   -----------------
          *  /  0 1 2 3 4 5 6  \ 
          */
            Assert.False(board.GameIsOver(), "In session");
            /*
            * 5 | O O O X O O . |
            * 4 | X X X O X X X |
            * 3 | O O O X O O O |
            * 2 | X X X O X X X |
            * 1 | O O O X O O O |
            * 0 | X X X O X X X |
            *   -----------------
            *  /  0 1 2 3 4 5 6  \ 
            */
            board = GameSimulator.BuildBoard("00000011111122222243333334444455555566666");
            Assert.False(board.GameIsOver(), "Last move");
            board = GameSimulator.BuildBoard("000000111111222222433333344444555555666666");
            Assert.True(board.GameIsOver(), "Draw");
        }

        [Fact]
        public void TestWinStates()
        {
            var board = GameSimulator.BuildBoard("2324252");
            /*
             *  0 1 2 3 4 5 6
             * |. . . . . . .|
             * |. . . . . . .|
             * |. . X . . . .|
             * |. . X . . . .|
             * |. . X . . . .|
             * |. . X O O O .|
             * ===============
             * /0 1 2 3 4 5 6 \ 
             */
            Assert.True(board.GameIsOver(), "X vertical winner column 2");
            board = GameSimulator.BuildBoard("06142335");
            /*
             *  0 1 2 3 4 5 6
             * |. . . . . . .|
             * |. . . . . . .|
             * |. . . . . . .|
             * |. . . . . . .|
             * |. . . X . . .|
             * |X X X O O O O|
             * ===============
             * /0 1 2 3 4 5 6 \ 
             */
            Assert.True(board.GameIsOver(), "Y horizontal winner column 3-6");
            board = GameSimulator.BuildBoard("332401133414455556110666004050633");
            /*
             *  0 1 2 3 4 5 6
             * |O . . X . . .|
             * |O O . O X X X|
             * |O X . X X X O|
             * |X X . O O O X|
             * |X X . O O X O|
             * |X O X X O O O|
             * ===============
             * /0 1 2 3 4 5 6 \ 
             */
            Assert.True(board.GameIsOver(), "X vertical winner column 3-6");
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