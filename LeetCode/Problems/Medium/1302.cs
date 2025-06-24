using LeetCode.Generators;
using LeetCode.Structures;

namespace LeetCode.Problems.Medium;

/// <summary>
///     1302. Deepest Leaves Sum
///     https://leetcode.com/problems/deepest-leaves-sum/
/// </summary>
public class _1302
{
    private static readonly TreeNode Input = new(
        1,
        new TreeNode(2, new TreeNode(4, new TreeNode(7)), new TreeNode(5)),
        new TreeNode(3, null!, new TreeNode(6, null!, new TreeNode(8))));

    [BenchmarkGen]
    public void DeepestLeavesSum() => DeepestLeavesSum(Input);

    private int DeepestLeavesSum(TreeNode? root)
    {
        var maxDepth = 0;
        var maxValue = new Dictionary<int, int>();
        Traverse(root, 0, ref maxDepth, maxValue);

        return maxValue[maxDepth];

        void Traverse(TreeNode? node, int depth, ref int maxD, Dictionary<int, int> maxV)
        {
            // check current node
            if (node is null)
            {
                return;
            }

            if (node.left is null && node.right is null)
            {
                if (depth >= maxD)
                {
                    maxD = depth;
                    if (maxV.ContainsKey(depth))
                    {
                        maxV[depth] += node.Val;
                    }
                    else
                    {
                        maxV.Add(depth, node.Val);
                    }
                }
            }

            // Traverse to the left and right nodes
            Traverse(node.left!, depth + 1, ref maxD, maxV);
            Traverse(node.right!, depth + 1, ref maxD, maxV);
        }
    }
}
