using System;
using ConnectFour.Shared.Models;

namespace ConnectFour.Shared.UI
{
    public class GameTextInterface
    {
        private static string GameBoardRowToString(GameBoard board, int row)
        {
            const int NUMBER_OF_COLUMNS = 7;
            const int LAST_COLUMN = NUMBER_OF_COLUMNS - 1;
            var rowText = "|";
            for (var column = 0; column < LAST_COLUMN; column++)
                rowText += GameBoardSlotToText(board, column, row) + " ";
            return rowText + GameBoardSlotToText(board, LAST_COLUMN, row) + "|";
        }

        private static char GameBoardSlotToText(GameBoard board, int column, int row)
        {
            var disc = board.GetDisc(column, row);
            return disc == GameBoard.EMPTY_SLOT ? '.' : disc;
        }

        private static string GameBoardToString(GameBoard board)
        {
            var text = " 0 1 2 3 4 5 6\n";
            const int TOP_MOST_ROW = 5;
            for (var row = TOP_MOST_ROW; row >= 0; row--)
                text += GameBoardRowToString(board, row) + "\n";
            return text + "===============\n";
        }

        public void ShowGameBoard(GameBoard gameBoard) =>
            Console.Write(GameBoardToString(gameBoard));
    }
}
