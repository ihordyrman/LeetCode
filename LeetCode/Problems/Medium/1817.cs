using LeetCode.Extensions;

namespace LeetCode.Problems.Medium;

/// <summary>
///     1817. Finding the Users Active Minutes
///     https://leetcode.com/problems/finding-the-users-active-minutes
/// </summary>
public class _1817
{
    private static readonly (int[][] logs, int k) Input1 = ([[0, 5], [1, 2], [0, 2], [0, 5], [1, 3]], 5);
    private static readonly (int[][] logs, int k) Input2 = ([[1, 1], [2, 2], [2, 3]], 4);

    public static void Execute() => FindingUsersActiveMinutes(Input2.logs, Input2.k).Display();

    private static int[] FindingUsersActiveMinutes(int[][] logs, int k)
    {
        var result = new int[k];
        Dictionary<int, HashSet<int>> dic = [];

        for (int i = 0; i < logs.Length; i++)
        {
            int id = logs[i][0];
            int minute = logs[i][1];

            dic.TryAdd(id, []);
            dic[id].Add(minute);
        }

        foreach (var (_, minute) in dic)
        {
            result[minute.Count - 1]++;
        }

        return result;
    }
}