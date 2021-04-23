using System;
using System.Diagnostics;
using ConnectFour.Shared.Extensions;

namespace ConnectFour.Shared.Models
{
    public class GameBoard
    {
        private char[,] _grid = new char[NUMBER_OF_ROWS, NUMBER_OF_COLUMNS];
        private int _moveCounter;
        public const char EMPTY_SLOT = default;
        private const int NO_EMPTY_SLOT = -1;
        private const int NUMBER_OF_ROWS = 6;
        private const int NUMBER_OF_COLUMNS = 7;
        private const int NUMBER_OF_SLOTS = NUMBER_OF_COLUMNS* NUMBER_OF_ROWS;
        private char _winner;

        public GameBoard()
        {
            Debug.Assert(_grid[0,0] == EMPTY_SLOT);
        }

        public char GetDisc(int column, int row) 
        {
            return _grid[row, column];
        }

        public void DropDiscDownColumn(char disc, int column)
        {
            Debug.Assert(!GameIsOver());
            var row = FindNextFreeRow(column);
            _grid[row, column] = disc;
            if (LongestSequenceContainsPiece(column, row) >= 4)
                _winner = disc;
            _moveCounter++;
        }

        private int LongestSequenceContainsPiece(int column, int row)
        {
            var longestLength = 1;
            // Look for sequences av similar pieces in all directions
            foreach (var direction in Direction.Directions)
            {
                var numberOfPiecesInLine = 1 + NumberOfPiecesInDirection(column, row, direction)
                                             + NumberOfPiecesInDirection(column, row, direction.GetReverse());
                longestLength = Math.Max(longestLength, numberOfPiecesInLine);
            }

            return longestLength;
        }

        private int NumberOfPiecesInDirection(int column, int row, Direction direction)
        {
            char piece = GetDisc(column, row);
            int count = 0;
            while (true)
            {
                column += direction.ColumnStep;
                row += direction.RowStep;
                if (!PositionContainsPiece(column, row, piece))
                {
                    break;;
                }

                count++;
            }

            return count;
        }

        private bool PositionContainsPiece(int column, int row, char piece) => 
            IsValidColumnIndex(column)
            && IsValidRowIndex(row)
            && GetDisc(column,row) == piece;
        

        static bool IsValidColumnIndex(int column) => column is >= 0 and < NUMBER_OF_COLUMNS;
        static bool IsValidRowIndex(int row) => row is >= 0 and < NUMBER_OF_ROWS;

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

        bool HasWinner() => _winner != default;
        
        public bool GameIsOver() => _moveCounter >= 42 || HasWinner();

        public char GetNextPiece()
        {
            bool isEvenMove = _moveCounter % 2 == 0;
            return isEvenMove ? 'X' : 'O';
        }
    }
}
