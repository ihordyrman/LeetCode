namespace LeetCode.Structures;

public class TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
{
    public TreeNode? Left = left;
    public TreeNode? Right = right;
    public readonly int Val = val;
}
