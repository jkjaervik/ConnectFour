using ConnectFour.Shared.Extensions;

namespace ConnectFour.Shared.Models
{
    public class GameBoard
    {
        private char[,] _grid = new char[6, 7];
        private int _moveCounter;
        public const char EMPTY_SLOT = default;
        private const int NO_EMPTY_SLOT = -1;

        public char GetDisc(int column, int row)
        {
            return _grid[row, column];
        }

        public void DropDiscDownColumn(char disc, int column)
        {
            _grid[FindNextFreeRow(column), column] = disc;
            _moveCounter++;
        }

        private int FindNextFreeRow(int column)
        {
            char[] columnContent = _grid.GetColumn(column);
            foreach (var (c, index) in columnContent.WithIndex())
                if (c == EMPTY_SLOT)
                    return index;
            return NO_EMPTY_SLOT;
        }

        public bool ColumnIsFull(int column)
        {
            char[] columnContent = _grid.GetColumn(column);
            int topRowIndex = columnContent.Length - 1;
            char topRowPiece = columnContent[topRowIndex];
            return topRowPiece != EMPTY_SLOT;
        }

        public bool IsValidColumn(int column)
        {
            if (column is < 0 or > 6)
                return false;
            return !ColumnIsFull(column);
        }

        public bool GameIsOver()
        {
            return _moveCounter >= 42;
        }

        public char GetNextPiece()
        {
            bool isEvenMove = _moveCounter % 2 == 0;
            return isEvenMove ? 'X' : 'O';
        }
    }
}
