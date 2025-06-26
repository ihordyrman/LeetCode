using LeetCode.Extensions;

namespace LeetCode.Problems.Medium;

/// <summary>
///     2149. Rearrange Array Elements by Sign
///     https://leetcode.com/problems/rearrange-array-elements-by-sign/
/// </summary>
public class _2149
{
    private static readonly int[] Input = [3, 1, -2, -5, 2, -4];

    // [3,-2,1,-5,2,-4]
    public static void Execute() => RearrangeArray(Input).Display();

    private static int[] RearrangeArray(int[] nums)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            if (i % 2 == 0 && nums[i] < 0)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[j] > 0)
                    {
                        int buffer = nums[i];
                        nums[i] = nums[j];
                        nums[j] = buffer;
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
                        int buffer = nums[i];
                        nums[i] = nums[j];
                        nums[j] = buffer;
                        break;
                    }
                }
            }
        }

        return nums;
    }
}