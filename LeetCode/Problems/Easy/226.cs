using LeetCode.Generators;
using LeetCode.Structures;

namespace LeetCode.Problems.Easy;

/// <summary>
///     226. Invert Binary Tree
///     https://leetcode.com/problems/invert-binary-tree/
/// </summary>
public class _226
{
    private static readonly TreeNode Input = new(
        1,
        new TreeNode(2, new TreeNode(4, new TreeNode(7)), new TreeNode(5)),
        new TreeNode(3, null!, new TreeNode(6, null!, new TreeNode(8))));

    [BenchmarkGen]
    public void InvertTree() => InvertTree(Input);

    private TreeNode InvertTree(TreeNode? root)
    {
        if (root == null || (root.left == null && root.right == null))
        {
            return root!;
        }

        InvertNodes(root);
        return root;

        static void InvertNodes(TreeNode? node)
        {
            TreeNode? left = null!;
            TreeNode? right = null!;
            if (node!.left != null)
            {
                left = node.left;
                InvertNodes(left);
            }

            if (node.right != null)
            {
                right = node.right;
                InvertNodes(right);
            }

            node.left = right;
            node.right = left;
        }
    }
}
