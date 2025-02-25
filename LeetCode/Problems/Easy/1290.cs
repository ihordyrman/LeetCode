using System.Numerics;
using LeetCode.Generators;
using LeetCode.Structures;

namespace LeetCode.Problems.Easy;

/// <summary>
///     1290. Convert Binary Number in a Linked List to Integer
///     https://leetcode.com/problems/convert-binary-number-in-a-linked-list-to-integer/
/// </summary>
public class _1290
{
    private static readonly ListNode Node = new(1, new ListNode(0, new ListNode(0, new ListNode(1, new ListNode(0)))));

    private static int GetDecimalValue(ListNode head)
    {
        if (head.Next == null)
        {
            return head.Val;
        }

        BigInteger result = head.Val;
        while (head.Next != null)
        {
            head = head.Next;
            result *= 10;
            result += head.Val;
        }

        var base1 = 1;
        BigInteger resultValue = 0;
        while (result > 0)
        {
            BigInteger temp = result % 10;
            result /= 10;
            resultValue += temp * base1;
            base1 *= 2;
        }

        return (int)resultValue;
    }

    [Executable]
    public void ConvertBinaryNumber() => GetDecimalValue(Node);
}
