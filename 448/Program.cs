using System.Collections.Generic;
using Xunit;

namespace _448
{
    /// <summary>
    /// 448. Find All Numbers Disappeared in an Array
    /// https://leetcode.com/problems/find-all-numbers-disappeared-in-an-array/
    /// </summary>
    internal static class Program
    {
        private static void Main()
        {
            Assert.Equal(
                new[] {5, 6},
                FindDisappearedNumbers(new[] {4, 3, 2, 7, 8, 2, 3, 1}));

            Assert.Equal(
                new[] {2},
                FindDisappearedNumbers(new[] {1, 1}));
        }

        private static IList<int> FindDisappearedNumbers(int[] nums)
        {
            bool[] values = new bool[nums.Length + 1];

            foreach (int t in nums)
            {
                values[t] = true;
            }

            List<int> result = new List<int>();

            for (int i = 1; i < values.Length; i++)
            {
                if (!values[i])
                {
                    result.Add(i);
                }
            }

            return result;
        }
    }
}