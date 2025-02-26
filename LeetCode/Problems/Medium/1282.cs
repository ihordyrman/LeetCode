using LeetCode.Generators;

namespace LeetCode.Problems.Medium;

/// <summary>
///     1282. Group the People Given the Group Size They Belong To
///     https://leetcode.com/problems/group-the-people-given-the-group-size-they-belong-to/
/// </summary>
public class _1282
{
    private static readonly int[] Input = [3, 3, 3, 3, 3, 1, 3];

    [BenchmarkGen]
    public void GroupThePeople() => GroupThePeople(Input);

    private static IList<IList<int>> GroupThePeople(int[] groupSizes)
    {
        var result = new List<IList<int>>();
        var sizes = new Dictionary<int, List<int>>();

        for (var i = 0; i < groupSizes.Length; i++)
        {
            if (groupSizes[i] == 1)
            {
                result.Add(new List<int> { i });
            }
            else if (sizes.ContainsKey(groupSizes[i]))
            {
                sizes[groupSizes[i]].Add(i);
                if (sizes[groupSizes[i]].Count == groupSizes[i])
                {
                    result.Add(sizes[groupSizes[i]]);
                    sizes.Remove(groupSizes[i]);
                }
            }
            else
            {
                sizes.Add(groupSizes[i], [i]);
            }
        }

        return result;
    }
}
