namespace LeetCode.Problems.Easy;

/// <summary>
///     1791. Find Center of Star Graph
///     https://leetcode.com/problems/find-center-of-star-graph
/// </summary>
public class _1791
{
    private static readonly int[][] Input = [[1, 2], [2, 3], [4, 2]];

    public static void Execute() => Console.WriteLine(FindCenter(Input));

    // (:
    private static int FindCenter(int[][] edges) =>
        edges[0][0] == edges[1][0] || edges[0][0] == edges[1][1] ? edges[0][0] : edges[0][1];
}