// 1974. Minimum Time to Type Word Using Special Typewriter
// https://leetcode.com/problems/minimum-time-to-type-word-using-special-typewriter/

using System;
using Xunit;

Assert.Equal(MinTimeToType("abc"), 5);
Assert.Equal(MinTimeToType("bza"), 7);
Assert.Equal(MinTimeToType("zjpc"), 34);
Assert.Equal(MinTimeToType("pdy"), 31); // TODO: Not finished yet

int MinTimeToType(string word)
{
    char last = 'a';
    int pointer = 0;
    int moves = 0;

    foreach (var ch in word)
    {
        int wordPosition = ch - last;

        if (wordPosition == pointer)
        {
            // Write
            moves++;
            continue;
        }

        int right = (ch - last + 26) % 26;
        int left = (last - ch + 26) % 26;
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
    }

    return moves;
}