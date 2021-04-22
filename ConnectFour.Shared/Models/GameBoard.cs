namespace ConnectFour.Shared.Models
{
    public class GameBoard
    {
        private char _currentPiece = '.';

        public char GetDisc(int column, int row)
        {
            return _currentPiece;
        }

        public void DropDiscDownColumn(char disc, int column)
        {
            _currentPiece = disc;
        }
    }
}
