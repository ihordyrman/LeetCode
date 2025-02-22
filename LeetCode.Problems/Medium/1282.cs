using Xunit;

namespace _1282;

/// <summary>
///     1282. Group the People Given the Group Size They Belong To
///     https://leetcode.com/problems/group-the-people-given-the-group-size-they-belong-to/
/// </summary>
public class _1282
{
    public _1282()
    {
        Assert.Equal(
            GroupThePeople([3, 3, 3, 3, 3, 1, 3]),
            new List<IList<int>>
            {
                new List<int> { 0, 1, 2 },
                new List<int> { 5 },
                new List<int> { 3, 4, 6 }
            });

        Assert.Equal(
            GroupThePeople([2, 1, 3, 3, 3, 2]),
            new List<IList<int>>
            {
                new List<int> { 1 },
                new List<int> { 2, 3, 4 },
                new List<int> { 0, 5 }
            });
    }

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
