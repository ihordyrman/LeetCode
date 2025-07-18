﻿namespace LeetCode.Problems.Easy;

/// <summary>
///     1046. Last Stone Weight
///     https://leetcode.com/problems/last-stone-weight/
/// </summary>
public class _1046
{
    private static readonly int[] Input = [2, 7, 4, 1, 8, 1];

    [BenchmarkGen]
    public void LastStoneWeight() => LastStoneWeight(Input);

    private static int LastStoneWeight(int[] stones)
    {
        switch (stones.Length)
        {
            case 0:
            case 1:
                return stones[0];
            case 2:
                return Math.Abs(stones[1] - stones[0]);
        }

        Array.Sort(stones);
        var list = new List<int>(stones);

        while (list.Count > 1)
        {
            int first = list.ElementAt(list.Count - 1);
            int second = list.ElementAt(list.Count - 2);
            int smash = first - second;

            list.RemoveAt(list.Count - 1);
            list.RemoveAt(list.Count - 1);

            if (smash != 0)
            {
                int index = list.BinarySearch(smash);
                if (index < 0)
                {
                    index = ~index;
                }

                list.Insert(index, smash);
            }
        }

        return list.FirstOrDefault();
    }
}
