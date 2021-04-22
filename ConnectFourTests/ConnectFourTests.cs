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

        [Fact]
        public void TestDropDisc()
        {
            var board = new GameBoard();
            board.DropDiscDownColumn('X', 0);
            board.DropDiscDownColumn('O', 2);
            /*
             * 1 | . . . . . . . |
             * 0 | X . O . . . . |
             *   -----------------
             *  /  0 1 2 3 4 5 6  \ 
             */
            Debug.Assert(board.GetDisc(0, 0) == 'X');
            Debug.Assert(board.GetDisc(1, 0) == GameBoard.EMPTY_SLOT);
            Debug.Assert(board.GetDisc(2, 0) == 'O');
            Debug.Assert(board.GetDisc(0, 1) == GameBoard.EMPTY_SLOT);
        }
    }
}
