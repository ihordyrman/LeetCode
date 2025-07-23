namespace LeetCode.Problems.Medium;

/// <summary>
///     45. Jump Game II
///     https://leetcode.com/problems/jump-game-ii
/// </summary>
public class _45
{
    private static readonly int[] Input1 = [2, 3, 1, 1, 4];
    private static readonly int[] Input2 = [2, 3, 0, 1, 4];
    private static readonly int[] Input3 = [1, 1, 1, 1];
    private static readonly int[] Input4 = [1];
    private static readonly int[] Input5 = [0];
    private static readonly int[] Input6 = [1, 2, 3];
    private static readonly int[] Input7 = [2, 1];
    private static readonly int[] Input8 = [1, 2, 0, 1];
    private static readonly int[] Input9 = [3, 2, 1];

    public static void Execute()
    {
        Jump(Input1).Display();
        Jump(Input2).Display();
        Jump(Input3).Display();
        Jump(Input4).Display();
        Jump(Input5).Display();
        Jump(Input6).Display();
        Jump(Input7).Display();
        Jump(Input8).Display();
        Jump(Input9).Display();
    }

    private static int Jump(int[] nums)
    {
        int jumps = 0;
        if (nums[0] == 0 || nums.Length == 1) return 0;

        for (int i = 0; i < nums.Length;)
        {
            int max = 0;
            int index = i;
            if (i + 1 == nums.Length)
            {
                break;
            }

            if (i + nums[i] >= nums.Length)
            {
                jumps++;
                break;
            }

            if (nums[i] == 1)
            {
                i++;
                jumps++;
                continue;
            }

            for (int j = i + 1, count = 0; j < nums.Length && count < nums[i]; j++, count++)
            {
                if (max <= nums[j])
                {
                    max = nums[j];
                    index = j;
                }

                max = Math.Max(max, nums[j]);
            }

            i = index;
            jumps++;
        }

        return jumps;
    }
}