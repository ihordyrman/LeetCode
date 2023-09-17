// See https://aka.ms/new-console-template for more information

using System.Collections.Generic;
using Xunit;

var treeNode = new TreeNode(
    1,
    new TreeNode(2, new TreeNode(4, new TreeNode(7)), new TreeNode(5)),
    new TreeNode(3, null, new TreeNode(6, null, new TreeNode(8))));

Assert.Equal(15, DeepestLeavesSum(treeNode));

int DeepestLeavesSum(TreeNode root)
{
    var maxDepth = 0;
    var maxValue = new Dictionary<int, int>();
    Traverse(root, 0, ref maxDepth, maxValue);

    return maxValue[maxDepth];

    void Traverse(TreeNode node, int depth, ref int maxDepth, Dictionary<int, int> maxValue)
    {
        // check current node
        if (node is null)
        {
            return;
        }

        if (node.left is null && node.right is null)
        {
            if (depth >= maxDepth)
            {
                maxDepth = depth;
                if (maxValue.ContainsKey(depth))
                {
                    maxValue[depth] += node.val;
                }
                else
                {
                    maxValue.Add(depth, node.val);
                }
            }
        }

        // Traverse to the left and right nodes
        Traverse(node.left, depth + 1, ref maxDepth, maxValue);
        Traverse(node.right, depth + 1, ref maxDepth, maxValue);
    }
}

public class TreeNode
{
    public TreeNode left;
    public TreeNode right;
    public int val;

    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}
