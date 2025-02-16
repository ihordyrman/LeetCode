using Runner.Easy;

namespace Runner;

public class Entry
{
    public static void Main()
    {
        var x = new _226();

        var root = new _226.TreeNode(
            4,
            new _226.TreeNode(2, new _226.TreeNode(1), new _226.TreeNode(3)),
            new _226.TreeNode(7, new _226.TreeNode(6), new _226.TreeNode(9)));

        x.InvertTree(root);
    }
}
