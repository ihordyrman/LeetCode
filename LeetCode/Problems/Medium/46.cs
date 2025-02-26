using LeetCode.Generators;

namespace LeetCode.Problems.Medium;

/// <summary>
///     46. Permutations
///     https://leetcode.com/problems/permutations/
/// </summary>
public class _46
{
    private static readonly int[] Input = [1, 2, 3];

    [BenchmarkGen]
    public void Permute() => Permute(Input);

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
