using System.Collections.Generic;
using System.Linq;

namespace ConnectFour.Shared.Extensions
{
    public static class ArrayExtensions
    {
        public static char[] GetColumn(this char[,] grid, int column)
        {
            return Enumerable.Range(0, grid.GetLength(0))
                             .Select(x => grid[x, column])
                             .ToArray();
        }

        public static char[] GetRow(this char[,] grid, int row)
        {
            return Enumerable.Range(0, grid.GetLength(0))
                             .Select(x => grid[row, x])
                             .ToArray();
        }

        public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> source)
        {
            return source.Select((item, index) => (item, index));
        }
    }
}
