namespace LeetCode.Problems.Medium;

/// <summary>
///     238. Product of Array Except Self
///     https://leetcode.com/problems/product-of-array-except-self
/// </summary>
public class _238
{
    private static readonly int[] Input1 = [1, 2, 3, 4];
    private static readonly int[] Input2 = [-1, 1, 0, -3, 3];
    private static readonly int[] Input3 = [0, 0];
    private static readonly int[] Input4 = [0, 4, 0];

    public static void Execute()
    {
        ProductExceptSelf(Input1).Display();
        ProductExceptSelf(Input2).Display();
        ProductExceptSelf(Input3).Display();
        ProductExceptSelf(Input4).Display();
    }

    // First attempt. A bit hacky, but beats 100%
    private static int[] ProductExceptSelf(int[] nums)
    {
        int total = 0;
        bool zero = false;
        bool multiple = false;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0)
            {
                if (zero) multiple = true;
                else zero = true;
                continue;
            }

            total = total == 0 ? 1 : total;
            total *= nums[i];
        }

        for (int i = 0; i < nums.Length; i++)
        {
            if (!zero && nums[i] == 0)
                continue;

            if (zero && nums[i] != 0)
            {
                nums[i] = 0;
                continue;
            }

            if (zero && nums[i] == 0)
            {
                nums[i] = multiple ? 0 : total;
                continue;
            }

            nums[i] = total / nums[i];
        }

        return nums;
    }
}