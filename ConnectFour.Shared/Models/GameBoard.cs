namespace ConnectFour.Shared.Models
{
    public class GameBoard
    {
        private char _currentPiece = '.';
        private char[,] _grid = new char[6, 7];
        public const char EMPTY_SLOT = default;

        public char GetDisc(int column, int row)
        {
            //return _currentPiece;
            return _grid[row, column];
        }

        public void DropDiscDownColumn(char disc, int column)
        {
            _currentPiece = disc;
            var nextEmptySlot = 0;
            _grid[nextEmptySlot, column] = disc;
        }
    }
}
