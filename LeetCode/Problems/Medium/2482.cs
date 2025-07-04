using LeetCode.Extensions;

namespace LeetCode.Problems.Medium;

/// <summary>
///     2482. Difference Between Ones and Zeros in Row and Column
///     https://leetcode.com/problems/difference-between-ones-and-zeros-in-row-and-column/
/// </summary>
public class _2482
{
    private static readonly int[][] Input = [[0, 1, 1], [1, 0, 1], [0, 0, 1]];
    private static readonly int[][] Input2 = [[1, 1, 1], [1, 1, 1]];

    public static void Execute() => OnesMinusZerosBetter(Input2).Display();

    // First attempt
    private static int[][] OnesMinusZeros(int[][] grid)
    {
        var onesCol = new int[grid[0].Length];
        var zeroesCol = new int[grid[0].Length];
        var onesRow = new int[grid.Length];
        var zeroesRow = new int[grid.Length];

        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] == 0)
                {
                    zeroesCol[j]++;
                    zeroesRow[i]++;
                }
                else
                {
                    onesCol[j]++;
                    onesRow[i]++;
                }
            }
        }

        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[i].Length; j++)
            {
                grid[i][j] = (onesRow[i] + onesCol[j]) - (zeroesRow[i] + zeroesCol[j]);
            }
        }

        return grid;
    }

    // Second attempt
    private static int[][] OnesMinusZerosBetter(int[][] grid)
    {
        int[] col = new int[grid[0].Length];
        int[] row = new int[grid.Length];

        for (int i = 0; i < grid.Length; i++)
        for (int j = 0; j < grid[i].Length; j++)
        {
            row[i] += grid[i][j] == 1 ? 1 : -1;
            col[j] += grid[i][j] == 1 ? 1 : -1;
        }

        for (int i = 0; i < grid.Length; i++)
        for (int j = 0; j < grid[i].Length; j++)
        {
            grid[i][j] = col[j] + row[i];
        }

        return grid;
    }
}