namespace LeetCode.Problems.Medium;

/// <summary>
///     80. Remove Duplicates from Sorted Array II
///     https://leetcode.com/problems/remove-duplicates-from-sorted-array-ii
/// </summary>
public class _80
{
    private static readonly int[] Input1 = [1, 1, 1, 2, 2, 3];
    private static readonly int[] Input2 = [0, 0, 1, 1, 1, 1, 2, 3, 3];

    public static void Execute()
    {
        RemoveDuplicatesTryFaster(Input1).Display();
        RemoveDuplicatesTryFaster(Input2).Display();
    }

    // First working attempt
    private static int RemoveDuplicates(int[] nums)
    {
        int k = 1;
        for (int i = 1, c = 1; i < nums.Length; i++)
        {
            if (nums[i - 1] != nums[i])
            {
                nums[k] = nums[i];
                c = 1;
                k++;
            }
            else if (c >= 2)
            {
                nums[k] = nums[i];
                c++;
            }
            else
            {
                nums[k] = nums[i];
                k++;
                c++;
            }
        }

        return k;
    }


    // Second attempt: same logic, but slightly faster
    private static int RemoveDuplicatesTryFaster(int[] nums)
    {
        int k = 1;
        for (int i = 1, c = 1; i < nums.Length; i++)
        {
            if (nums[i - 1] != nums[i])
            {
                nums[k++] = nums[i];
                c = 1;
            }
            else
            {
                c++;
                if (c < 2) nums[k++] = nums[i];
            }
        }

        return k;
    }
}