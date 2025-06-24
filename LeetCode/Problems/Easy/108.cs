using LeetCode.Structures;

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

        var middle = nums.Length / 2;

        Span<int> numbers = nums.AsSpan();
        Span<int> leftSide = numbers[..middle];
        Span<int> rightSide = numbers[(middle + 1)..];
        return new TreeNode(nums[middle], InsertNodes(leftSide), InsertNodes(rightSide));

        static TreeNode? InsertNodes(Span<int> slice)
        {
            switch (slice)
            {
                case { Length: 0 }:
                    return null;
                case { Length: 1 }:
                    return new TreeNode(slice[0]);
            }

            var middle = slice.Length / 2;
            Span<int> leftSide = slice[..middle];
            Span<int> rightSide = slice[(middle + 1)..];
            return new TreeNode(slice[middle], InsertNodes(leftSide), InsertNodes(rightSide));
        }
    }
}