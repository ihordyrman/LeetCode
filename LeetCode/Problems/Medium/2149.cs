using LeetCode.Extensions;

namespace LeetCode.Problems.Medium;

/// <summary>
///     2149. Rearrange Array Elements by Sign
///     https://leetcode.com/problems/rearrange-array-elements-by-sign/
/// </summary>
public class _2149
{
    private static readonly int[] Input = [28, -41, 22, -8, -37, 46, 35, -9, 18, -6, 19, -26, -37, -10, -9, 15, 14, 31];

    // Expected: [28, -41, 22, -8, 46, -37, 35, -9, 18, -6, 19, -26, 15, -37, 14, -10, 31, -9]
    // Actual:   [28, -41, 22, -8, 46, -37, 35, -9, 18, -6, 19, -26, 15, -10, 14, -37, 31, -9]
    public static void Execute() => RearrangeArrayLazy(Input).Display();

    private static int[] RearrangeArray(int[] nums)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            if (i % 2 == 0 && nums[i] < 0)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    // instead of doing it I need to make shift left for a rest of array
                    if (nums[j] > 0)
                    {
                        int temp = nums[i];
                        nums[i] = nums[j];
                        nums[j] = temp;
                        break;
                    }
                }
            }

            if (i % 2 == 1 && nums[i] > 0)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[j] < 0)
                    {
                        int temp = nums[i];
                        nums[i] = nums[j];
                        nums[j] = temp;
                        break;
                    }
                }
            }
        }

        return nums;
    }

    private static int[] RearrangeArrayLazy(int[] nums)
    {
        int[] result = new int[nums.Length];
        int[] positive = new int[nums.Length / 2];
        int[] negative = new int[nums.Length / 2];

        for (int i = 0, n = 0, p = 0; i < nums.Length; i++)
        {
            if (nums[i] > 0) positive[p++] = nums[i];
            else negative[n++] = nums[i];
        }

        for (int i = 0, n = 0, p = 0; i < nums.Length; i += 2)
        {
            result[i] = positive[p++];
            result[i + 1] = negative[n++];
        }

        return result;
    }
}