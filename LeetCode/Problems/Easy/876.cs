using LeetCode.Generators;
using LeetCode.Structures;

namespace LeetCode.Problems.Easy;

/// <summary>
///     876. Middle of the Linked List
///     https://leetcode.com/problems/middle-of-the-linked-list/
/// </summary>
public class _876
{
    private static readonly ListNode Input = new(1, new ListNode(0, new ListNode(0, new ListNode(1, new ListNode(0)))));

    [BenchmarkGen]
    public void MiddleNode() => MiddleNode(Input);

    private ListNode? MiddleNode(ListNode head)
    {
        if (head == null)
        {
            return null;
        }

        ListNode tempNode = head;
        var count = 0;
        while (tempNode.Next != null)
        {
            count++;
            tempNode = tempNode.Next;
        }

        int middle = count / 2;

        if (count % 2 != 0)
        {
            middle++;
        }

        count = 0;
        while (count != middle)
        {
            count++;
            head = head.Next!;
        }

        return head;
    }
}
