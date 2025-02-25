using Xunit;

namespace LeetCode.Problems.Easy;

/// <summary>
///     1974. Minimum Time to Type Word Using Special Typewriter
///     https://leetcode.com/problems/minimum-time-to-type-word-using-special-typewriter/
/// </summary>
public class _1974
{
    public _1974()
    {
        Assert.Equal(5, MinTimeToType("abc"));
        Assert.Equal(7, MinTimeToType("bza"));
        Assert.Equal(34, MinTimeToType("zjpc"));
        Assert.Equal(31, MinTimeToType("pdy"));
    }

    private int MinTimeToType(string word)
    {
        var a = 'a';
        var pointer = 0;
        var moves = 0;

        foreach (char ch in word)
        {
            int wordPosition = ch - 'a';

            if (wordPosition == pointer)
            {
                // Write
                moves++;
                continue;
            }

            int right = (ch - a + 26) % 26;
            int left = (a - ch + 26) % 26;
            bool toTheLeft = left < right;

            while (pointer != wordPosition)
            {
                if (toTheLeft)
                {
                    if (pointer == 0)
                    {
                        pointer = 25;
                    }
                    else
                    {
                        pointer--;
                    }
                }
                else
                {
                    if (pointer == 25)
                    {
                        pointer = 0;
                    }
                    else
                    {
                        pointer++;
                    }
                }

                moves++;
            }

            moves++;
            a = ch;
        }

        return moves;
    }
}
