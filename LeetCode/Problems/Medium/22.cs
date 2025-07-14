using System.Text;

namespace LeetCode.Problems.Medium;

/// <summary>
///     22. Generate Parentheses
///     https://leetcode.com/problems/generate-parentheses/
/// </summary>
public class _22
{
    public static void Execute()
    {
        GenerateParenthesisBetter(1).Display();
        GenerateParenthesisBetter(2).Display();
        GenerateParenthesisBetter(3).Display();
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


    // First approach + some optimizations
    private static IList<string> GenerateParenthesisBetter(int n)
    {
        IList<string> result = [];
        StringBuilder sb = new("(");
        GoDeep(sb, 0, 1, 0);

        return result;

        void GoDeep(StringBuilder path, int level = 0, int open = 0, int closed = 0)
        {
            if (closed > open)
            {
                path.Length--;
                return;
            }

            if (level >= n * 2 - 1)
            {
                if (open == closed)
                    result.Add(path.ToString());
                return;
            }

            if (open < n)
            {
                path.Append('(');
                GoDeep(path, level + 1, open + 1, closed);
                path.Length--;
            }

            if (closed < open)
            {
                path.Append(')');
                GoDeep(path, level + 1, open, closed + 1);
                path.Length--;
            }
        }
    }
}