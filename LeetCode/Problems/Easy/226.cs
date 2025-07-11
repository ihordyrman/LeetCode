namespace LeetCode.Problems.Easy;

/// <summary>
///     226. Invert Binary Tree
///     https://leetcode.com/problems/invert-binary-tree/
/// </summary>
public class _226
{
    private static readonly TreeNode<int> Input = new(
        1,
        new TreeNode<int>(2, new TreeNode<int>(4, new TreeNode<int>(7)), new TreeNode<int>(5)),
        new TreeNode<int>(3, null!, new TreeNode<int>(6, null!, new TreeNode<int>(8))));

    [BenchmarkGen]
    public void InvertTree() => InvertTree(Input);

    private TreeNode<int> InvertTree(TreeNode<int>? root)
    {
        if (root == null || (root.left == null && root.right == null))
        {
            return root!;
        }

        InvertNodes(root);
        return root;

        static void InvertNodes(TreeNode<int>? node)
        {
            TreeNode<int>? left = null!;
            TreeNode<int>? right = null!;
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