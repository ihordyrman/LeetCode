using System.Numerics;
using Xunit;

namespace _1290;

/// <summary>
///     1290. Convert Binary Number in a Linked List to Integer
///     https://leetcode.com/problems/convert-binary-number-in-a-linked-list-to-integer/
/// </summary>
public class _1290
{
    public _1290()
    {
        Assert.Equal(GetDecimalValue(new ListNode(1, new ListNode(0, new ListNode(1)))), 5);

        Assert.Equal(GetDecimalValue(new ListNode(1, new ListNode(0, new ListNode(0, new ListNode(1, new ListNode(0)))))), 18);
    }

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
}

public class ListNode
{
    public readonly ListNode Next;
    public readonly int Val;

    public ListNode(int val, ListNode next = null)
    {
        Val = val;
        Next = next;
    }
}
