using ConnectFour.Shared.Models;

namespace ConnectFour.Shared.Utils
{
    public class GameSimulator
    {
        public static GameBoard BuildBoard(string sequence)
        {
            var board = new GameBoard();
            for (var i = 0; i < sequence.Length; ++i)
            {
                var column = int.Parse(sequence.Substring(i, 1));
                board.DropDiscDownColumn(board.GetNextPiece(), column);
            }

            return board;
        }
    }
}
