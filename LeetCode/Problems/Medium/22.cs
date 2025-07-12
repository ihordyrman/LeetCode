namespace LeetCode.Problems.Medium;

/// <summary>
///     22. Generate Parentheses
///     https://leetcode.com/problems/generate-parentheses/
/// </summary>
public class _22
{
    public static void Execute()
    {
        GenerateParenthesis(1).Display();
        GenerateParenthesis(2).Display();
        GenerateParenthesis(3).Display();
    }

    // First attempt
    private static IList<string> GenerateParenthesis(int n)
    {
        IList<string> result = [];
        GoDeep("(");

        return result;

        void GoDeep(string path, int level = 0)
        {
            if (level >= n * 2 - 1)
            {
                if (IsValidPath(path)) result.Add(path);
                return;
            }

            GoDeep(path + "(", level + 1);
            GoDeep(path + ")", level + 1);
        }

        bool IsValidPath(string path)
        {
            int open = 0;
            int close = 0;
            foreach (var ch in path)
            {
                if (ch == ')') close++;
                else open++;

                if (close > open) return false;
            }

            return open - close == 0;
        }
    }
}