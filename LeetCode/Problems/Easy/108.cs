using LeetCode.Structures;

namespace LeetCode.Problems.Easy;

/// <summary>
///     108. Convert Sorted Array to Binary Search Tree
///     https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree/
/// </summary>
public class _108
{
    private static readonly int[] Input = [-10, -3, 0, 5, 9];

    public static void Execute() => Console.WriteLine(SortedArrayToBst(Input));

    private static TreeNode SortedArrayToBst(int[] nums)
    {
        var middle = nums.Length / 2;
        var root = new TreeNode(nums[middle]);

        // todo: maybe try to use ranges instead of array, to reduce allocations
        Span<int> numbers = nums.AsSpan();
        Span<int> leftSide = numbers[..middle];
        Span<int> rightSide = numbers[(middle + 1)..];
        root.Left = InsertNodes(root, leftSide);
        root.Right = InsertNodes(root, rightSide);

        return root;

        static TreeNode InsertNodes(TreeNode node, Span<int> slice)
        {
            switch (slice.Length)
            {
                case 0:
                    return node;
                case 1:
                    node.Left = new TreeNode(slice[0]);
                    return node;
                case 2:
                    node.Left = new TreeNode(slice[0]);
                    node.Right = new TreeNode(slice[1]);
                    return node;
            }

            var middle = slice.Length / 2;

            // todo: same as above
            var root = new TreeNode(slice[middle]);
            Span<int> leftSide = slice[..middle];
            Span<int> rightSide = slice[middle..];

            root.Left = InsertNodes(root, leftSide); 
            root.Right = InsertNodes(root, rightSide);
            return root;
        }
    }
}