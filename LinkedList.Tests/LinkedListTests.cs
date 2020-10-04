using LinkedList.Logic;
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
    }
}