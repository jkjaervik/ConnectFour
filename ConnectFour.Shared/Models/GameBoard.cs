using ConnectFour.Shared.Extensions;

namespace ConnectFour.Shared.Models
{
    public class GameBoard
    {
        private char _currentPiece = '.';
        private char[,] _grid = new char[6, 7];
        public const char EMPTY_SLOT = default;
        private const int NO_EMPTY_SLOT = -1;

        public char GetDisc(int column, int row)
        {
            //return _currentPiece;
            return _grid[row, column];
        }

        public void DropDiscDownColumn(char disc, int column)
        {
            _currentPiece = disc;
            var nextEmptySlot = 0;
            _grid[FindNextFreeRow(column), column] = disc;
        }

        private int FindNextFreeRow(int column)
        {
            char[] columnContent = _grid.GetColumn(column);
            foreach (var (c, index) in columnContent.WithIndex())
                if (c == EMPTY_SLOT)
                    return index;
            return NO_EMPTY_SLOT;
        }
    }
}
