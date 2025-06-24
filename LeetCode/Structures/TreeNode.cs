namespace LeetCode.Structures;

public class TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
{
    public readonly int Val = val;
    public TreeNode? left = left;
    public TreeNode? right = right;

    public void Display()
    {
        DisplayHelper(this, "", true);
    }

    private static void DisplayHelper(TreeNode? node, string indent, bool isLast)
    {
        if (node == null) return;

        Console.WriteLine(indent + (isLast ? "└── " : "├── ") + node.Val);

        var children = new[] { node.left, node.right }.Where(x => x != null).ToArray();

        for (int i = 0; i < children.Length; i++)
        {
            var last = i == children.Length - 1;
            var newIndent = indent + (isLast ? "    " : "│   ");
            DisplayHelper(children[i], newIndent, last);
        }
    }
}