﻿using LinkedList.Logic;
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
            var output = _linkedListService.ReverseList(head);
            var actualOutput = _linkedListService.GetListValues(output);

            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void ReverseList_SingleElement_True()
        {
            var head = new ListNode(1);

            var expectedOutput = "1";
            var output = _linkedListService.ReverseList(head);
            var actualOutput = _linkedListService.GetListValues(output);

            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void ReverseList_NoElement_True()
        {
            var output = _linkedListService.ReverseList(null);
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
    }
}