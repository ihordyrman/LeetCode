using System;
using System.Collections.Generic;
using Xunit;

namespace _1403
{
    /// <summary>
    /// 1403. Minimum Subsequence in Non-Increasing Order
    /// https://leetcode.com/problems/minimum-subsequence-in-non-increasing-order/
    /// </summary>
    internal static class Program
    {
        private static void Main()
        {
            Assert.Equal(new[] {7, 7, 6}, MinSubsequence(new[] {4, 4, 7, 6, 7}));
            Assert.Equal(new[] {10, 9}, MinSubsequence(new[] {4, 3, 10, 9, 8}));
            Assert.Equal(new[] {10}, MinSubsequence(new[] {10, 2, 5}));
            Assert.Equal(new[] {9, 8, 7, 6}, MinSubsequence(new[] {4, 6, 4, 4, 8, 5, 1, 7, 9}));
        }

        private static IList<int> MinSubsequence(int[] nums)
        {
            Array.Sort(nums);
            int index = nums.Length - 1;
            int maxSum = nums[index];
            List<int> result = new List<int> {nums[index]};

            while (true)
            {
                int leftSum = 0;
                for (int i = 0; i < index; i++)
                {
                    leftSum += nums[i];
                }

                if (leftSum < maxSum)
                {
                    return result;
                }

                result.Add(nums[index - 1]);
                maxSum += nums[--index];
            }
        }
    }
}