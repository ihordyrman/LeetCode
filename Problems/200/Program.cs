using Xunit;

namespace _200;

/// <summary>
///     200. Number of Islands
///     https://leetcode.com/problems/number-of-islands/
/// </summary>
internal static class Program
{
    private static void Main()
    {
        char[][] grid =
        {
            new[] { '1', '1', '1', '1', '0' },
            new[] { '1', '1', '0', '1', '0' },
            new[] { '1', '1', '0', '0', '0' },
            new[] { '0', '0', '0', '0', '0' }
        };

        char[][] grid2 =
        {
            new[] { '1', '1', '0', '0', '0' },
            new[] { '1', '1', '0', '0', '0' },
            new[] { '0', '0', '1', '0', '0' },
            new[] { '0', '0', '0', '1', '1' }
        };

        Assert.Equal(NumIslands(grid), 1);
        Assert.Equal(NumIslands(grid2), 3);
    }

    private static int NumIslands(char[][] grid)
    {
        if (grid == null || grid.Length == 0)
        {
            return 0;
        }

        var islands = 0;

        for (var i = 0; i < grid.Length; i++)
        for (var j = 0; j < grid[i].Length; j++)
        {
            if (grid[i][j] == '1')
            {
                islands += FindIsland(grid, i, j);
            }
        }

        return islands;

        static int FindIsland(char[][] grid, int i, int j)
        {
            if (i < 0 || i >= grid.Length || j < 0 || j >= grid[i].Length || grid[i][j] == '0')
            {
                return 0;
            }

            grid[i][j] = '0';

            FindIsland(grid, i + 1, j);
            FindIsland(grid, i - 1, j);
            FindIsland(grid, i, j + 1);
            FindIsland(grid, i, j - 1);

            return 1;
        }
    }
}
