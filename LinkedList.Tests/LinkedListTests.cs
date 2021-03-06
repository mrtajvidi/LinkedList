﻿//using System.Linq;
using LinkedList.Logic;
using System;
using System.Collections.Generic;
using Xunit;

namespace LinkedList.Tests
{
    public class LinkedListTests
    {
        private readonly LinkedListService _linkedListService;

        public LinkedListTests()
        {
            _linkedListService = new LinkedListService();
        }

        [Fact]
        public void HasCycle_True()
        {
            var head = new Node(6);
            var node5 = new Node(5);
            var node4 = new Node(4);
            var node3 = new Node(3);
            var node2 = new Node(2);
            head.Next = node5;
            node5.Next = node4;
            node4.Next = node3;
            node3.Next = node2;
            node2.Next = node4;

            var output = _linkedListService.HasCycle(head);
            Assert.True(output);
        }

        [Fact]
        public void HasCycle_False()
        {
            var head = new Node(6);
            var node5 = new Node(5);
            var node4 = new Node(4);
            var node3 = new Node(3);
            var node2 = new Node(2);
            head.Next = node5;
            node5.Next = node4;
            node4.Next = node3;
            node3.Next = node2;

            var output = _linkedListService.HasCycle(head);
            Assert.False(output);
        }

        [Fact]
        public void DetectCycle_False()
        {
            var head = new ListNode(3);
            var node2 = new ListNode(2);
            var node0 = new ListNode(0);
            var nodeN4 = new ListNode(-4);

            head.next = node2;
            node2.next = node0;
            node0.next = nodeN4;
            nodeN4.next = node2;

            var output = _linkedListService.GetIntersect(head);
            Assert.Equal(output.val, node2.val);
        }

        [Fact]
        public void GetIntersectionNode_True()
        {
            var headA = new ListNode(1);
            var node9 = new ListNode(9);
            var node1 = new ListNode(1);
            var node2 = new ListNode(2);
            var node4 = new ListNode(4);
            headA.next = node9;
            node9.next = node1;
            node1.next = node2;
            node2.next = node4;

            var headB = new ListNode(3) { next = node2 };

            var output = _linkedListService.GetIntersectionNode(headA, headB);
            Assert.Equal(output.val, node2.val);
        }

        [Fact]
        public void GetIntersectionNode_AnotherTrue()
        {
            var headA = new ListNode(4);
            var node1 = new ListNode(1);
            var node8 = new ListNode(8);
            var node4 = new ListNode(4);
            var node5 = new ListNode(5);

            headA.next = node1;
            node1.next = node8;
            node8.next = node4;
            node4.next = node5;

            var headB = new ListNode(5);
            var node6 = new ListNode(6);
            var node1B = new ListNode(1);
            headB.next = node6;
            node6.next = node1B;
            node1B.next = node8;

            var output = _linkedListService.GetIntersectionNode(headA, headB);
            Assert.Equal(output.val, node8.val);
        }

        [Fact]
        public void GetIntersectionNode_False()
        {
            var headA = new ListNode(2);
            var node6 = new ListNode(6);
            var node4 = new ListNode(4);
            headA.next = node6;
            node6.next = node4;

            var headB = new ListNode(1);
            var node5 = new ListNode(5);
            headB.next = node5;

            var output = _linkedListService.GetIntersectionNode(headA, headB);
            Assert.Null(output);
        }

        [Fact]
        public void RemoveNthFromEnd_False()
        {
            var head = new ListNode(1);
            var node2 = new ListNode(2);
            var node3 = new ListNode(3);
            var node4 = new ListNode(4);
            var node5 = new ListNode(5);
            head.next = node2;
            node2.next = node3;
            node3.next = node4;
            node4.next = node5;
            var expectedOutput = "1,2,3,5";

            var output = _linkedListService.RemoveNthFromEnd(head, 2);
            var actualOutput = _linkedListService.GetListValues(output);
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void ReverseList_True()
        {
            var head = new ListNode(1);
            var node2 = new ListNode(2);
            var node3 = new ListNode(3);
            var node4 = new ListNode(4);
            var node5 = new ListNode(5);
            head.next = node2;
            node2.next = node3;
            node3.next = node4;
            node4.next = node5;

            var expectedOutput = "5,4,3,2,1";
            var output = _linkedListService.ReverseListV1(head);
            var actualOutput = _linkedListService.GetListValues(output);

            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void ReverseList_SingleElement_True()
        {
            var head = new ListNode(1);

            var expectedOutput = "1";
            var output = _linkedListService.ReverseListV1(head);
            var actualOutput = _linkedListService.GetListValues(output);

            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void ReverseList_NoElement_True()
        {
            var output = _linkedListService.ReverseListV1(null);
            Assert.Null(output);
        }

        [Fact]
        public void RemoveElements_True()
        {
            var head = new ListNode(1);
            var node2 = new ListNode(2);
            var node6 = new ListNode(6);
            var node3 = new ListNode(3);
            var node4 = new ListNode(4);
            var node5 = new ListNode(5);
            var node66 = new ListNode(6);
            head.next = node2;
            node2.next = node6;
            node6.next = node3;
            node3.next = node4;
            node4.next = node5;
            node5.next = node66;

            var expectedOutput = "1,2,3,4,5";
            var output = _linkedListService.RemoveElements(head, 6);
            var actualOutput = _linkedListService.GetListValues(output);

            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void RemoveElements_AnotherSample_True()
        {
            var head = new ListNode(1);
            var node2 = new ListNode(2);
            head.next = node2;

            var expectedOutput = "2";
            var output = _linkedListService.RemoveElements(head, 1);
            var actualOutput = _linkedListService.GetListValues(output);

            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void RemoveElements_SingleElementNoMatch_True()
        {
            var head = new ListNode(1);
            var expectedOutput = "1";
            var output = _linkedListService.RemoveElements(head, 6);
            var actualOutput = _linkedListService.GetListValues(output);

            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void RemoveElements_TwoElementsMatch_True()
        {
            var head = new ListNode(1);
            var node1 = new ListNode(1);
            head.next = node1;

            var output = _linkedListService.RemoveElements(head, 1);

            Assert.Null(output);
        }

        [Fact]
        public void RemoveElements_SingleElementMatch_True()
        {
            var head = new ListNode(1);
            var output = _linkedListService.RemoveElements(head, 1);

            Assert.Null(output);
        }

        [Fact]
        public void OddEvenList_True()
        {
            var head = new ListNode(1);
            var node2 = new ListNode(2);
            var node3 = new ListNode(3);
            var node4 = new ListNode(4);
            var node5 = new ListNode(5);
            var node6 = new ListNode(6);
            var node7 = new ListNode(7);
            var node8 = new ListNode(8);
            head.next = node2;
            node2.next = node3;
            node3.next = node4;
            node4.next = node5;
            node5.next = node6;
            node6.next = node7;
            node7.next = node8;

            var expectedOutput = "1,3,5,7,2,4,6,8";
            var output = _linkedListService.OddEvenList(head);
            var actualOutput = _linkedListService.GetListValues(output);
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void OddEvenList_TwoElementList_True()
        {
            var head = new ListNode(1);
            var node2 = new ListNode(2);
            head.next = node2;

            var expectedOutput = "1,2";
            var output = _linkedListService.OddEvenList(head);
            var actualOutput = _linkedListService.GetListValues(output);
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void OddEvenList_SingleElementList_True()
        {
            var head = new ListNode(1);

            var expectedOutput = "1";
            var output = _linkedListService.OddEvenList(head);
            var actualOutput = _linkedListService.GetListValues(output);
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void OddEvenList_ThreeElementList_True()
        {
            var head = new ListNode(1);
            var node2 = new ListNode(2);
            var node3 = new ListNode(3);
            head.next = node2;
            node2.next = node3;

            var expectedOutput = "1,3,2";
            var output = _linkedListService.OddEvenList(head);
            var actualOutput = _linkedListService.GetListValues(output);
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void IsPalindrome_True()
        {
            var head = new ListNode(1);
            var node2 = new ListNode(2);
            var node3 = new ListNode(3);
            var node33 = new ListNode(3);
            var node22 = new ListNode(2);
            var node11 = new ListNode(1);

            head.next = node2;
            node2.next = node3;
            node3.next = node33;
            node33.next = node22;
            node22.next = node11;

            var output = _linkedListService.IsPalindromeRecursively(head);
            Assert.True(output);
        }

        [Fact]
        public void MergeTwoLists_FirstCase_True()
        {
            var list1 = new ListNode(3);
            var node3 = new ListNode(3);
            var node5 = new ListNode(5);
            list1.next = node3;
            node3.next = node5;

            var list2 = new ListNode(1);
            var node1 = new ListNode(1);
            var node2 = new ListNode(2);
            var node6 = new ListNode(6);
            list2.next = node1;
            node1.next = node2;
            node2.next = node6;

            var expectedOutput = "1,1,2,3,3,5,6";
            var output = _linkedListService.MergeTwoLists(list1, list2);
            var actualOutput = _linkedListService.GetListValues(output);
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void MergeTwoLists_SecondCase_True()
        {
            var list1 = new ListNode(1);
            var node2 = new ListNode(2);
            var node4 = new ListNode(4);
            list1.next = node2;
            node2.next = node4;

            var list2 = new ListNode(1);
            var node3 = new ListNode(3);
            var node44 = new ListNode(4);
            list2.next = node3;
            node3.next = node44;

            var expectedOutput = "1,1,2,3,4,4";
            var output = _linkedListService.MergeTwoLists(list1, list2);
            var actualOutput = _linkedListService.GetListValues(output);
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void AddTwoNumbers_FirstCase_True()
        {
            var list1 = new ListNode(7);
            var node8 = new ListNode(8);
            var node3 = new ListNode(3);
            list1.next = node8;
            node8.next = node3;

            var list2 = new ListNode(4);
            var node5 = new ListNode(5);
            var node6 = new ListNode(6);
            var node7 = new ListNode(7);
            list2.next = node5;
            node5.next = node6;
            node6.next = node7;

            var expectedOutput = "1,4,0,8";
            var output = _linkedListService.AddTwoNumbers(list1, list2);
            var actualOutput = _linkedListService.GetListValues(output);
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void AddTwoNumbers_SecondCase_True()
        {
            var list1 = new ListNode(9);
            var node90 = new ListNode(9);
            var node91 = new ListNode(9);
            var node92 = new ListNode(9);
            var node93 = new ListNode(9);
            var node94 = new ListNode(9);
            var node95 = new ListNode(9);
            list1.next = node90;
            node90.next = node91;
            node91.next = node92;
            node92.next = node93;
            node93.next = node94;
            node94.next = node95;

            var list2 = new ListNode(9);
            var node96 = new ListNode(9);
            var node97 = new ListNode(9);
            var node98 = new ListNode(9);
            list2.next = node96;
            node96.next = node97;
            node97.next = node98;

            var expectedOutput = "8,9,9,9,0,0,0,1";
            var output = _linkedListService.AddTwoNumbers(list1, list2);
            var actualOutput = _linkedListService.GetListValues(output);
            Assert.Equal(expectedOutput, actualOutput);
        }

        /*
        [Fact]
        public void Flatten_FirstCase_True()
        {
            var head = new MLNode { val = 1 };
            var node2 = new MLNode { val = 2 };
            var node3 = new MLNode { val = 3 };
            var node4 = new MLNode { val = 4 };
            var node5 = new MLNode { val = 5 };
            var node6 = new MLNode { val = 6 };
            var node6Next = new MLNode();
            var node6NextNext = new MLNode();

            var node7Prev = new MLNode();
            var node7 = new MLNode { val = 7 };
            var node8 = new MLNode { val = 8 };
            var node9 = new MLNode { val = 9 };
            var node10 = new MLNode { val = 10 };
            var node11 = new MLNode { val = 11 };
            var node12 = new MLNode { val = 12 };

            head.next = node2;

            node2.prev = head;
            node2.next = node3;

            node3.next = node4;
            node3.prev = node2;
            node3.child = node7;

            node4.next = node5;
            node4.prev = node3;

            node5.next = node6;
            node5.prev = node4;

            node6.next = node6Next;
            node6Next.next = node6NextNext;
            node6NextNext.next = node7Prev;

            node7.prev = node7Prev;
            node7.next = node8;

            node8.next = node9;
            node8.prev = node7;
            node8.child = node11;

            var expectedOutput = "8,9,9,9,0,0,0,1";
            var output = _linkedListService.AddTwoNumbers(list1, list2);
            var actualOutput = _linkedListService.GetListValues(output);
            Assert.Equal(expectedOutput, actualOutput);
        }
        */

        [Fact]
        public int test()
        {
            var A = new int[] { 4, 0 };

            Array.Sort(A);

            var first = 0;
            var last = A.Length - 1;

            while (first < last)
            {
                if (A[first] == -A[last])
                    return A[last];

                if (A[first] > -A[last])
                    last -= 1;
                else
                    first += 1;
            }

            return 0;
        }

        //[Fact]
        //public int Solution()
        //{
        //    // write your code in C# 6.0 with .NET 4.5 (Mono)

        //    // we iterate throug the array
        //    // store items in a dictionary with key = item and value = numebr of items
        //    // return the key with the biggest value  if key = value

        //    var dictOfItem = new Dictionary<int, int>();

        //    foreach (var item in A)
        //    {
        //        if (dictOfItem.ContainsKey(item))
        //        {
        //            dictOfItem[item] = dictOfItem[item] + 1;
        //        }
        //        else
        //        {
        //            dictOfItem[item] = 1;
        //        }
        //    }

        //    var maxValue = dictOfItem.Values.Max();
        //    var key = dictOfItem.FirstOrDefault(x => x.Value == maxValue).Key;

        //    if (key == maxValue)
        //    {
        //        return key;
        //    }

        //    return (key == maxValue) ? key : 0;

        //}

        [Fact]
        public int solution()
        {
            var x = new int[] { 1, 1, 1 };
            var y = new int[] { 2, 2, 2 };

            var dictItems = new Dictionary<int, double>();

            var numberOfPairsThatSumUpToOne = 0;
            for (int i = 0; i <= x.Length - 1; i++)
            {
                var mod = (double)x[i] / (double)y[i];

                var roundedMod = Math.Round(mod, 6);

                if (dictItems.ContainsValue(1.0 - roundedMod))
                {
                    numberOfPairsThatSumUpToOne++;
                }
                dictItems[i] = roundedMod;
            }

            return numberOfPairsThatSumUpToOne;
        }

        [Fact]
        public void ReverseOperations_True()
        {
            var head = new ListNode(1);
            var node2 = new ListNode(2);
            var node8 = new ListNode(8);
            var node9 = new ListNode(9);
            var node12 = new ListNode(12);
            var node16 = new ListNode(16);

            head.next = node2;
            node2.next = node8;
            node8.next = node9;
            node9.next = node12;
            node12.next = node16;


            var expectedOutput = "1,8,2,9,16,12";
            var output = _linkedListService.ReverseOperations(head);
            var actualOutput = _linkedListService.GetListValues(output);

            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}