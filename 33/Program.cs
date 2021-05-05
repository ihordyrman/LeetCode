using System;
using Xunit;

namespace _33
{
    /// <summary>
    /// 33. Search in Rotated Sorted Array
    /// https://leetcode.com/problems/search-in-rotated-sorted-array/
    /// </summary>
    internal static class Program
    {
        private static void Main()
        {
            Assert.Equal(Search(new[] {4, 5, 6, 7, 0, 1, 2}, 0), 4);
            Assert.Equal(Search(new[] {4, 5, 6, 7, 0, 1, 2}, 3), -1);
            Assert.Equal(Search(new[] {1}, 0), -1);
        }

        private static int Search(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
            {
                return -1;
            }

            int left = 0;
            int right = nums.Length - 1;

            while (left < right)
            {
                int middle = left + (right - left) / 2;

                if (nums[middle] > nums[right])
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle;
                }
            }

            int start = left;
            left = 0;
            right = nums.Length - 1;

            if (target >= nums[start] && target <= nums[right])
            {
                left = start;
            }
            else
            {
                right = start;
            }

            while (left <= right)
            {
                int middle = left + (right - left) / 2;

                if (nums[middle] == target)
                {
                    return middle;
                }

                if (nums[middle] < target)
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle - 1;
                }
            }

            return -1;
        }
    }
}