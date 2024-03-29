﻿using Xunit;

namespace Runner.Medium;

/// <summary>
///     1828. Queries on Number of Points Inside a Circle
///     https://leetcode.com/problems/queries-on-number-of-points-inside-a-circle/
/// </summary>
public class _1828
{
    public _1828()
    {
        int[][] points =
        {
            new[] { 1, 3 },
            new[] { 3, 3 },
            new[] { 5, 3 },
            new[] { 2, 2 }
        };

        int[][] queries =
        {
            new[] { 2, 3, 1 },
            new[] { 4, 3, 1 },
            new[] { 1, 1, 2 }
        };

        int[][] points2 =
        {
            new[] { 1, 1 },
            new[] { 2, 2 },
            new[] { 3, 3 },
            new[] { 4, 4 },
            new[] { 5, 5 }
        };

        int[][] queries2 =
        {
            new[] { 1, 2, 2 },
            new[] { 2, 2, 2 },
            new[] { 4, 3, 2 },
            new[] { 4, 3, 3 }
        };

        Assert.Equal(CountPoints(points, queries), new[] { 3, 2, 2 });
        Assert.Equal(CountPoints(points2, queries2), new[] { 2, 3, 2, 4 });
    }

    private static int[] CountPoints(int[][] points, int[][] queries)
    {
        // https://www.expii.com/t/distance-formula-4560
        // (x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2) <= r * r

        var result = new int[queries.Length];

        for (var i = 0; i < queries.Length; i++)
        {
            int x = queries[i][0];
            int y = queries[i][1];
            int r = queries[i][2];

            foreach (int[] point in points)
            {
                if ((point[0] - x) * (point[0] - x) + (point[1] - y) * (point[1] - y) <= r * r)
                {
                    result[i]++;
                }
            }
        }

        return result;
    }
}
