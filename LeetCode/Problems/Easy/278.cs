﻿namespace LeetCode.Problems.Easy;

/// <summary>
///     278. First Bad Version
///     https://leetcode.com/problems/first-bad-version/
/// </summary>
public class _278
{
    private const int Version = 45;

    [BenchmarkGen]
    public void FirstBadVersion() => FirstBadVersion(Version);

    private static int FirstBadVersion(int n)
    {
        var left = 1;
        int right = n;
        while (left < right)
        {
            int middle = left + (right - left) / 2;
            if (IsBadVersion(middle))
            {
                right = middle;
            }
            else
            {
                left = middle + 1;
            }
        }

        return left;
    }

    private static bool IsBadVersion(int version) => false;
}
