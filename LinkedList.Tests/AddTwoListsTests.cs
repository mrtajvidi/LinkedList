using System;
using LinkedList.Logic;
using Xunit;

namespace LinkedList.Tests
{
    public class AddTwoListsTests
    {
        private readonly LinkedListService _linkedListService;
        private readonly DocumentProcessor _documentProcessor;

        public AddTwoListsTests()
        {
            _linkedListService = new LinkedListService();
            _documentProcessor = new DocumentProcessor();
        }

        [Fact]
        public void Test1()
        {
            var num1 = new Node(6) { Next = new Node(3) { Next = new Node(5) { Next = new Node(1) } } };
            var num2 = new Node(5) { Next = new Node(6) };

            var sum = _linkedListService.AddTwoNumbers(num1, num2);
            var sumString = _linkedListService.GetLinkedListString(sum);

            Assert.True(sumString == "1061");
        }

        [Theory]
        [InlineData("abccbd", new int[] { 0, 1, 2, 3, 4, 5 })]
        //[InlineData("abccbd", new int[] { 0, 1, 2, 3, 4, 5 })]
        //[InlineData("ababa", new int[] { 10, 5, 10, 5, 10 })]
        public void Test2(string s, int[] c)
        {
            //var s = "abccbd";
            //var c = new int[] { 0, 1, 2, 3, 4, 5 };

            var sumString = _linkedListService.Solution(s, c);
        }

        [Theory]
        [InlineData("I am a very good programmer. Even though I am just 12 year old. ")]
        public void Test32(string s)
        {
            var sumString = _documentProcessor.Analyze(s);
        }

        [Theory]
        [InlineData("a b c xxx yyy zzz ")]
        public void Test33(string s)
        {
            var sumString = _documentProcessor.Analyze(s);
        }

        [Theory]
        [InlineData("1 2 2 55 66 68 787987 654654 ")]
        public void Test31(string s)
        {
            var sumString = _documentProcessor.Analyze(s);
        }

        [Theory]
        [InlineData("Wed", 2, "Fri")]
        [InlineData("Sat", 23, "Mon")]
        [InlineData("Sat", 0, "Sat")]
        [InlineData("Sat", -1, null)]
        public void Test35(string day, int numOfDays, string expected)
        {
            var result = _linkedListService.Solution(day, numOfDays);

            Assert.Equal(result, expected);
        }


        [Theory]
        [InlineData("00:01:07,400-234-090", 201)]
        [InlineData("00:05:00,400-234-090", 750)]
        [InlineData("00:05:01,400-234-090", 900)]
        [InlineData("00:01:07,400-234-090\n00:05:01,701-080-080\n00:05:00,400-234-090", 900)]
        public void Test36(string text, int expectedCost)
        {
            var result = _linkedListService.Solution3453(text);

            Assert.Equal(result, expectedCost);
        }


        //[Theory]
        [Fact]
        public void Test372()
        {
            var test = new int[] { 3, 4, 5, 3, 7 };

        var result = _linkedListService.SolutionTree(test);

            Assert.Equal(result, result);
        }
    }
}