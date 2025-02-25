using LeetCode.Structures;

namespace LeetCode.Problems.Easy;

/// <summary>
///     226. Invert Binary Tree
///     https://leetcode.com/problems/invert-binary-tree/
/// </summary>
public class _226
{
    public TreeNode InvertTree(TreeNode? root)
    {
        if (root == null || (root.Left == null && root.Right == null))
        {
            return root!;
        }

        InvertNodes(root);
        return root;

        static void InvertNodes(TreeNode? node)
        {
            TreeNode? left = null!;
            TreeNode? right = null!;
            if (node!.Left != null)
            {
                left = node.Left;
                InvertNodes(left);
            }

            if (node.Right != null)
            {
                right = node.Right;
                InvertNodes(right);
            }

            node.Left = right;
            node.Right = left;
        }
    }
}
