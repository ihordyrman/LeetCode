namespace LeetCode.Problems.Easy;

/// <summary>
///     1394. Find Lucky Integer in an Array
///     https://leetcode.com/problems/find-lucky-integer-in-an-array
/// </summary>
public class _1394
{
    private static readonly int[] Input = [2, 2, 3, 4];

    public static void Execute() => FindLucky(Input).Display();

    private static int FindLucky(int[] arr)
    {
        Dictionary<int, int> dic = [];

        foreach (int i in arr)
        {
            if (!dic.TryAdd(i, 1)) dic[i]++;
        }

        int maxLucky = -1;
        foreach (var (key, value) in dic)
        {
            if (key == value && value > maxLucky)
                maxLucky = value;
        }

        return maxLucky;
    }
}