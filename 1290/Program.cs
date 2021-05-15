﻿using System.Numerics;
using Xunit;

namespace _1290
{
    /// <summary>
    /// 1290. Convert Binary Number in a Linked List to Integer
    /// https://leetcode.com/problems/convert-binary-number-in-a-linked-list-to-integer/
    /// </summary>
    internal static class Program
    {
        private static void Main()
        {
            Assert.Equal(GetDecimalValue(
                    new ListNode(1,
                        new ListNode(0,
                            new ListNode(1)
                        )
                    )
                ),
                5);

            Assert.Equal(GetDecimalValue(
                    new ListNode(1,
                        new ListNode(0,
                            new ListNode(0,
                                new ListNode(1,
                                    new ListNode(0,
                                        new ListNode(0,
                                            new ListNode(1,
                                                new ListNode(1,
                                                    new ListNode(1,
                                                        new ListNode(0,
                                                            new ListNode(0,
                                                                new ListNode(0,
                                                                    new ListNode(0,
                                                                        new ListNode(0,
                                                                            new ListNode(0)
                                                                        )
                                                                    )
                                                                )
                                                            )
                                                        )
                                                    )
                                                )
                                            )
                                        )
                                    )
                                )
                            )
                        )
                    )
                ),
                18880);
        }

        private static int GetDecimalValue(ListNode head)
        {
            if (head.next == null)
                return head.val;

            BigInteger result = head.val;
            while (head.next != null)
            {
                head = head.next;
                result *= 10;
                result += head.val;
            }

            int base1 = 1;
            BigInteger resultValue = 0;
            while (result > 0)
            {
                BigInteger temp = result % 10;
                result /= 10;
                resultValue += temp * base1;
                base1 *= 2;
            }

            return (int) resultValue;
        }
    }

    public class ListNode
    {
        public readonly int val;
        public readonly ListNode next;

        public ListNode(int val, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}