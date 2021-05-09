﻿using Xunit;

namespace _1304
{
    /// <summary>
    /// 1304. Find N Unique Integers Sum up to Zero
    /// https://leetcode.com/problems/find-n-unique-integers-sum-up-to-zero/
    /// </summary>
    internal static class Program
    {
        private static void Main()
        {
            Assert.Equal(AnotherSumZero(5), new[] {0, 2, -2, 1, -1});
            Assert.Equal(SumZero(3), new[] {-1, 0, 1});
            Assert.Equal(SumZero(1), new[] {0});
        }

        // 63.32%
        private static int[] SumZero(int n)
        {
            if (n == 0) return new[] {0};
            int[] result = new int[n];
            int value = 1;
            int length = n / 2;
            int point = n % 2 != 0 ? length + 1 : length;

            for (int i = 0; i < length; i++)
            {
                result[i] = -value;
                result[point + i] = value;
                value++;
            }

            return result;
        }

        // 84.15%
        private static int[] AnotherSumZero(int n)
        {
            int[] result = new int[n];
            int point = 0;

            if ((n & 1) == 1) result[point++] = 0;

            for (int i = n / 2; i > 0; i--)
            {
                result[point++] = i;
                result[point++] = -i;
            }

            return result;
        }
    }
}