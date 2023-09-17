using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace _46;

/// <summary>
///     46. Permutations
///     https://leetcode.com/problems/permutations/
/// </summary>
internal static class Program
{
    private static void Main()
        => Assert.Equal(
            new List<int[]>
            {
                new[] { 1, 2, 3 },
                new[] { 1, 3, 2 },
                new[] { 2, 1, 3 },
                new[] { 2, 3, 1 },
                new[] { 2, 3, 1 }
            },
            Permute(new[] { 1, 2, 3 }));

    private static IList<IList<int>> Permute(int[] nums)
    {
        IList<IList<int>> result = new List<IList<int>>();
        RecursivePermute(0, nums);
        return result;

        void RecursivePermute(int x, int[] arr)
        {
            if (x == arr.Length)
            {
                result.Add(arr.ToList());
                return;
            }

            for (int i = x; i < arr.Length; i++)
            {
                int temp = arr[x];
                arr[x] = arr[i];
                arr[i] = temp;

                RecursivePermute(x + 1, nums);

                temp = arr[x];
                arr[x] = arr[i];
                arr[i] = temp;
            }
        }
    }
}
