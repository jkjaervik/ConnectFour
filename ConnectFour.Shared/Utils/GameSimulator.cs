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
                var isEvenMove = i % 2 == 0;
                var piece = isEvenMove ? 'X' : 'O';
                var number = sequence.Substring(i, 1);
                var column = int.Parse(number);
                board.DropDiscDownColumn(piece, column);
            }

            return board;
        }
    }
}
