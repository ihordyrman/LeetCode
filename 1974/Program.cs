﻿// 1974. Minimum Time to Type Word Using Special Typewriter
// https://leetcode.com/problems/minimum-time-to-type-word-using-special-typewriter/

using Xunit;

Assert.Equal(5, MinTimeToType("abc"));
Assert.Equal(7, MinTimeToType("bza"));
Assert.Equal(34, MinTimeToType("zjpc"));
Assert.Equal(31, MinTimeToType("pdy"));

int MinTimeToType(string word)
{
    char a = 'a';
    int pointer = 0;
    int moves = 0;

    foreach (var ch in word)
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