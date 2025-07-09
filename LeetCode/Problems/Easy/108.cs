namespace LeetCode.Problems.Easy;

/// <summary>
///     108. Convert Sorted Array to Binary Search Tree
///     https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree/
/// </summary>
public class _108
{
    private static readonly int[] Input = [-10, -3, 0, 5, 9];

    public static void Execute() => SortedArrayToBst(Input).Display();

    private static TreeNode SortedArrayToBst(int[] nums)
    {
        switch (nums)
        {
            case { Length: 0 }:
                return null!;
            case { Length: 1 }:
                return new TreeNode(nums[0]);
        }

        var range = GetRange(0, nums.Length);
        return new TreeNode(
            nums[range.middle],
            InsertNodes(range.start_left, range.end_left),
            InsertNodes(range.start_right, range.end_right));

        TreeNode? InsertNodes(int start, int end)
        {
            switch (end - start)
            {
                case <= 0:
                    return null;
                case 1:
                    return new TreeNode(nums[start]);
            }

            var range = GetRange(start, end);
            return new TreeNode(
                nums[range.middle],
                InsertNodes(range.start_left, range.end_left),
                InsertNodes(range.start_right, range.end_right));
        }

        (int middle, int start_left, int end_left, int start_right, int end_right) GetRange(int start, int end)
        {
            int middle = start + (end - start) / 2;
            int leftSideStart = start;
            int leftSideEnd = middle;
            int rightSideStart = middle + 1;
            int rightSideEnd = end;
            return (middle, leftSideStart, leftSideEnd, rightSideStart, rightSideEnd);
        }
    }
}