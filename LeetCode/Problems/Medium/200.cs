namespace LeetCode.Problems.Medium;

/// <summary>
///     200. Number of Islands
///     https://leetcode.com/problems/number-of-islands/
/// </summary>
public class _200
{
    private static readonly char[][] Input =
    [
        ['1', '1', '0', '0', '0'],
        ['1', '1', '0', '0', '0'],
        ['0', '0', '1', '0', '0'],
        ['0', '0', '0', '1', '1']
    ];

    [BenchmarkGen]
    public void NumIslands() => NumIslands(Input);

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
