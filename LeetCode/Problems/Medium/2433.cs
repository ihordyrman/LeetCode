using LeetCode.Extensions;

namespace LeetCode.Problems.Medium;

/// <summary>
///     2433: Find The Original Array of Prefix Xor
///     https://leetcode.com/problems/find-the-original-array-of-prefix-xor
/// </summary>
public class _2433
{
    private static readonly int[] Input = [5, 2, 0, 3, 1];

    // [5, 7, 2, 3, 2]
    public static void Execute() => FindArray(Input).Display();

    // Explanation: From the array [5,7,2,3,2] we have the following:
    // - pref[0] = 5.
    // - pref[1] = 5 ^ 7 = 2.
    // - pref[2] = 5 ^ 7 ^ 2 = 0.
    // - pref[3] = 5 ^ 7 ^ 2 ^ 3 = 3.
    // - pref[4] = 5 ^ 7 ^ 2 ^ 3 ^ 2 = 1.
    private static int[] FindArray(int[] pref)
    {
        int previous = pref[0];
        for (int i = 1; i < pref.Length; i++)
        {
            // if a ^ b = c then a ^ c = b
            // (5 ^ 7) ^ x = 0
            // (5 ^ 7) ^ 0 = x
            var temp = pref[i];
            pref[i] = previous ^ pref[i];
            previous = temp;
        }

        return pref;
    }
}