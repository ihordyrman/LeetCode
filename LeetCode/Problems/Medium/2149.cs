namespace LeetCode.Problems.Medium;

/// <summary>
///     2149. Rearrange Array Elements by Sign
///     https://leetcode.com/problems/rearrange-array-elements-by-sign/
/// </summary>
public class _2149
{
    private static readonly int[] Input = [28, -41, 22, -8, -37, 46, 35, -9, 18, -6, 19, -26, -37, -10, -9, 15, 14, 31];
    private static readonly int[] Input2 = [28, 41, 1, -5, -22, -8];

    // Expected: [28, -41, 22, -8, 46, -37, 35, -9, 18, -6, 19, -26, 15, -37, 14, -10, 31, -9]
    public static void Execute() => RearrangeArray(Input).Display();

    // Attempt #1
    private static int[] RearrangeArrayLazy(int[] nums)
    {
        int[] result = new int[nums.Length];
        int[] positive = new int[nums.Length / 2];
        int[] negative = new int[nums.Length / 2];

        for (int i = 0, n = 0, p = 0; i < nums.Length;)
        {
            if (nums[i] > 0) positive[p++] = nums[i++];
            else negative[n++] = nums[i++];
        }

        for (int i = 0, n = 0, p = 0; i < nums.Length;)
        {
            result[i++] = positive[p++];
            result[i++] = negative[n++];
        }

        return result;
    }

    // Attempt #2: No additional allocations, but time limit exceeded
    private static int[] RearrangeArraySlow(int[] nums)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            if (i % 2 == 0 && nums[i] < 0)
            {
                int swap = i;
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[j] <= 0) continue;
                    swap = j;
                    break;
                }

                int value = nums[i];
                nums[i] = nums[swap];
                ShiftRight(i + 1, value, swap);
            }

            if (i % 2 == 1 && nums[i] > 0)
            {
                int swap = i;
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[j] >= 0) continue;
                    swap = j;
                    break;
                }

                int value = nums[i];
                nums[i] = nums[swap];
                ShiftRight(i + 1, value, swap);
            }
        }

        return nums;

        void ShiftRight(int start, int value, int end)
        {
            int previous = value;
            for (int i = start; i <= end; i++)
            {
                if (i == start)
                {
                    previous = nums[i];
                    nums[i] = value;
                }
                else if (i == end)
                    nums[i] = previous;
                else
                    (nums[i], previous) = (previous, nums[i]);
            }
        }
    }

    // Attempt #3
    private static int[] RearrangeArray(int[] nums)
    {
        int[] result = new int[nums.Length];
        int positive = 0;
        int negative = 1;

        foreach (var num in nums)
        {
            if (num > 0)
            {
                result[positive] = num;
                positive += 2;
            }
            else
            {
                result[negative] = num;
                negative += 2;
            }
        }

        return result;
    }
}