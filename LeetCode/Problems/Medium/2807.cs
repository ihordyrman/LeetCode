using LeetCode.Structures;

namespace LeetCode.Problems.Medium;

public class _2807
{
    private static readonly ListNode Input = new(18, new ListNode(6, new ListNode(10, new ListNode(3))));

    public static void Execute() => InsertGreatestCommonDivisor(Input);

    private static ListNode InsertGreatestCommonDivisor(ListNode head)
    {
        if (head.Next == null) return head;

        return InsertNode(head);

        static ListNode InsertNode(ListNode node)
        {
            if (node.Next == null) return node;
            var next = node.Next;

            var min = Math.Min(node.Val, next.Val);
            var divisor = min;
            while (divisor > 1)
            {
                if (node.Val % divisor == 0 && next.Val % divisor == 0)
                {
                    break;
                }

                divisor--;
            }

            node.Next = new ListNode(divisor, next);
            InsertNode(node.Next.Next!);
            return node;
        }
    }
}