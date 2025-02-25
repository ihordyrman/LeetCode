using LeetCode.Structures;
using Xunit;

namespace LeetCode.Problems.Medium;

/// <summary>
///     1302. Deepest Leaves Sum
///     https://leetcode.com/problems/deepest-leaves-sum/
/// </summary>
public class _1302
{
    public _1302()
    {
        var treeNode = new TreeNode(
            1,
            new TreeNode(2, new TreeNode(4, new TreeNode(7)), new TreeNode(5)),
            new TreeNode(3, null, new TreeNode(6, null, new TreeNode(8))));

        Assert.Equal(15, DeepestLeavesSum(treeNode));
    }

    private int DeepestLeavesSum(TreeNode root)
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

            if (node.Left is null && node.Right is null)
            {
                if (depth >= maxDepth)
                {
                    maxDepth = depth;
                    if (maxValue.ContainsKey(depth))
                    {
                        maxValue[depth] += node.Val;
                    }
                    else
                    {
                        maxValue.Add(depth, node.Val);
                    }
                }
            }

            // Traverse to the left and right nodes
            Traverse(node.Left!, depth + 1, ref maxDepth, maxValue);
            Traverse(node.Right!, depth + 1, ref maxDepth, maxValue);
        }
    }
}
