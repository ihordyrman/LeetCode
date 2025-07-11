namespace LeetCode.Structures;

public class TreeNode<T>(T val = default, TreeNode<T>? left = null, TreeNode<T>? right = null)
{
    public readonly T Val = val;
    public TreeNode<T>? left = left;
    public TreeNode<T>? right = right;

    public void Display()
    {
        DisplayHelper(this, "", true);
    }

    private static void DisplayHelper(TreeNode<T>? node, string indent, bool isLast)
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