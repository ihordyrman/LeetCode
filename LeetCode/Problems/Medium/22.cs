namespace LeetCode.Problems.Medium;

public class _22
{
    public static void Execute()
    {
        // GenerateParenthesis(2).Display();
        GenerateParenthesis(1).Display();
        // GenerateParenthesis(3).Display();
    }

    private static IList<string> GenerateParenthesis(int n)
    {
        IList<string> result = [];
        int level = 0;
        GoDeep("(");

        return result;

        void GoDeep(string path)
        {
            if (level >= n)
            {
                if (ValidatePath(path))
                {
                    result.Add(path);
                }
                return;
            }

            level++;
            GoDeep(path + ")");
            GoDeep(path + "(");
        }

        bool ValidatePath(string path)
        {
            int diff = 0;
            foreach (var ch in path)
            {
                if (ch == ')') diff--;
                else diff++;
            }

            return diff == 0;
        }
    }
}