using System.Xml;

namespace ConnectFour.Shared.Models
{
    public class Direction
    {
        public int ColumnStep { get; }
        public int RowStep { get; }

        public static readonly Direction Up = new(0,1);
        public static readonly Direction Left = new(1,0);
        public static readonly Direction Diagonal1 = new(1,1);
        public static readonly Direction Diagonal2 = new(1,-1);
        public static readonly Direction[] Directions = { Up, Left, Diagonal1, Diagonal2 };

        public Direction(int dx, int dy)
        {
            ColumnStep = dx;
            RowStep = dy;
        }

        public Direction GetReverse()
        {
            return new(-ColumnStep, -RowStep);
        }
    }
}
