using System;
using System.Collections.Generic;
using System.Linq;

namespace LinkedList.Logic
{
    public class LinkedListService
    {
        private ListNode frontPointer;

        public Node AddTwoNumbers(Node num1, Node num2)
        {
            return SumNodes(num1, num2, 0);
        }

        private Node SumNodes(Node num1, Node num2, int carryOver)
        {
            var sum = num1.Value + num2.Value + carryOver;
            var remainder = sum % 10;
            var newCarryOver = sum / 10;
            var returnNode = new Node(remainder);

            if (num1.Next != null || num1.Next != null)
            {
                num1.Next ??= new Node(0);

                num2.Next ??= new Node(0);

                returnNode.Next = SumNodes(num1.Next, num2.Next, newCarryOver);
            }
            else if (remainder > 0)
            {
                returnNode.Next = new Node(remainder);
            }

            return returnNode;
        }

        //public Node ConvertIntToNode(int input)
        //{
        //    var intList = input.ToString().Select(digit => int.Parse(digit.ToString()));

        //    foreach (var digit in intList)
        //    {
        //        var node = new Node(digit);

        //    }
        //}

        //public Node GenerateNode()

        public string GetLinkedListString(Node node)
        {
            if (node.Next == null) return string.Empty;

            return node.Value.ToString() + GetLinkedListString(node.Next);
        }

        public int Solution(string S, int[] C)
        {
            var outputDict = new Dictionary<char, List<int>>();

            char previousChar = ' ';
            for (int i = 0; i < S.Length; i++)
            {
                if (S[i] != previousChar)
                {
                    if (outputDict.ContainsKey(S[i]))
                    {
                        outputDict[S[i]].Add(C[i]);
                    }
                    else
                    {
                        outputDict.Add(S[i], new List<int> { C[i] });
                    }

                    previousChar = S[i];
                }
            }

            var cost = 0;
            foreach (var item in outputDict)
            {
                var listOfCost = item.Value;
                if (listOfCost.Count > 1)
                {
                    listOfCost.Sort();
                    var removableItems = listOfCost.Take(listOfCost.Count - 1);
                    var sum = removableItems.Sum();
                    cost += sum;
                }
            }
            return cost;
        }

        public string Solution(string S, int K)
        {
            if (string.IsNullOrWhiteSpace(S))
            {
                return null;
            }

            if (K == 0)
            {
                return S;
            }

            if (K < 0)
                return null;

            var monday = new Weekday("Mon");
            var tue = new Weekday("Tue");
            var wed = new Weekday("Wed");
            var thur = new Weekday("Thur");
            var fri = new Weekday("Fri");
            var sat = new Weekday("Sat");
            var sun = new Weekday("Sun");

            sun.Next = monday;
            sat.Next = sun;
            fri.Next = sat;
            thur.Next = fri;
            wed.Next = thur;
            tue.Next = wed;
            monday.Next = tue;

            var head = monday;
            while (head.Day != S)
            {
                head = head.Next;
            }

            for (int count = 0; count < K; count++)
            {
                head = head.Next;
            }

            return head.Day;
        }

        public int Solution3453(string S)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            // approach: break the giant string to arrays of strings based on line break
            // extract the day time from the hour
            // call the helper method to calculate the cost

            var phoneLogs = S.Split(new[] { '\r', '\n' });

            var phoneLogDic = new Dictionary<string, TimeSpan>();

            foreach (var phoneLog in phoneLogs)
            {
                var phoneLogPieces = phoneLog.Split(',');
                var durationInString = phoneLogPieces[0];
                var phoneNumber = phoneLogPieces[1];

                var durationTimeSpan = TimeSpan.MinValue;
                if (!TimeSpan.TryParse(durationInString, out durationTimeSpan))
                    throw new Exception("Failed to parse call log");

                if (phoneLogDic.ContainsKey(phoneNumber))
                {
                    phoneLogDic[phoneNumber] += durationTimeSpan;
                }
                else
                {
                    phoneLogDic.Add(phoneNumber, durationTimeSpan);
                }
            }

            var phoneNumberWithMaxNumberOfCalls = phoneLogDic.Values.Max();

            var bill = 0;
            foreach (var phoneLogEntry in phoneLogDic)
            {
                if (phoneLogDic.Count > 1 && (phoneLogEntry.Value == phoneNumberWithMaxNumberOfCalls))
                {
                    continue;
                }

                bill += CalculateCost(phoneLogEntry.Value);
            }

            return bill;
        }

        private TimeSpan GroupPhoneNumbersDurations(string[] phoneLogs)
        {
            return TimeSpan.Zero;
        }

        private int CalculateCost(TimeSpan duration)
        {
            if (duration.TotalMinutes < 5)
            {
                return (int)duration.TotalSeconds * 3;
            }
            else if (duration.Minutes == 5 && duration.Seconds == 0 && duration.Milliseconds == 0)
            {
                return (int)duration.Minutes * 150;
            }
            else
            {
                return ((int)duration.TotalMinutes + 1) * 150;
            }
        }

        public int SolutionTree(int[] A)
        {
            var numberOfWaysToCut = 0;

            if (A.Length < 3)
            {
                return 0;
            }
            else if (A.Length == 3)
            {
                return numberOfWaysToCut + ((IsAestheticallyPleasant(A[0], A[1], A[2])) ? 0 : 1);
            }
            else
            {
                var newArray = A.Skip(1).ToArray();
                return numberOfWaysToCut + SolutionTree(newArray);
            }
        }

        private bool IsAestheticallyPleasant(int firstElement, int middleElement, int lastElement)
        {
            return (firstElement < middleElement && middleElement > lastElement) ||
                   (firstElement > middleElement && middleElement < lastElement);
        }

        public bool HasCycle(Node head)
        {
            var slowerNode = head;
            var fasterNode = head;

            var count = 0;
            while (slowerNode.Next != null)
            {
                if (count % 2 == 0)
                {
                    slowerNode = slowerNode.Next;
                }

                if (fasterNode.Next == null)
                {
                    return false;
                }

                fasterNode = fasterNode.Next;

                if (fasterNode.Next == slowerNode)
                {
                    return true;
                }
                count++;
            }

            return false;
        }

        public ListNode GetIntersect(ListNode head)
        {
            var slowerNode = head;
            var fasterNode = head;

            while (fasterNode != null && fasterNode.next != null)
            {
                slowerNode = slowerNode.next;
                fasterNode = fasterNode.next.next;

                if (fasterNode == slowerNode)
                {
                    return fasterNode;
                }
            }
            return null;
        }

        public ListNode DetectCycle(ListNode head)
        {
            if (head == null)
            {
                return null;
            }

            ListNode intersect = GetIntersect(head);
            if (intersect == null)
            {
                return null;
            }

            ListNode ptr1 = head;
            ListNode ptr2 = intersect;
            while (ptr1 != ptr2)
            {
                ptr1 = ptr1.next;
                ptr2 = ptr2.next;
            }

            return ptr1;
        }

        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            var visitedNodes = new List<ListNode>();
            var thisNode = headA;

            while (thisNode != null)
            {
                visitedNodes.Add(thisNode);
                thisNode = thisNode.next;
            }

            thisNode = headB;

            while (thisNode != null)
            {
                if (visitedNodes.Contains(thisNode))
                    return thisNode;

                thisNode = thisNode.next;
            }

            return null;
        }

        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode dummy = new ListNode(0);
            dummy.next = head;
            ListNode first = dummy;
            ListNode second = dummy;
            for (int i = 1; i <= n + 1; i++)
            {
                first = first.next;
            }
            // Move first to the end, maintaining the gap
            while (first != null)
            {
                first = first.next;
                second = second.next;
            }
            second.next = second.next.next;
            return dummy.next;
        }

        public string GetListValues(ListNode head)
        {
            var output = new List<int>();
            var currentNode = head;

            while (currentNode != null)
            {
                output.Add(currentNode.val);
                currentNode = currentNode.next;
            }
            return string.Join(",", output);
        }

        public ListNode ReverseListV1(ListNode head)
        {
            if (head == null)
                return null;

            if (head.next == null)
            {
                return head;
            }

            var currentNode = head;
            var temp = currentNode.next;

            while (temp != null)
            {
                currentNode.next = temp.next;

                temp.next = head;
                head = temp;
                temp = currentNode.next;
            }

            return head;
        }

        public ListNode RemoveElements(ListNode head, int val)
        {
            while (head?.val == val)
            {
                head = head.next;
            };

            if (head == null)
            {
                return null;
            }

            if (head.next == null)
            {
                return head;
            }

            var currNode = head.next;
            var prevNode = head;
            var newHead = head;

            while (currNode != null)
            {
                if (currNode.val == val)
                {
                    prevNode.next = currNode.next;
                }
                else
                {
                    prevNode = currNode;
                }
                currNode = currNode.next;
            }

            return head;
        }

        public ListNode OddEvenList(ListNode head)
        {
            if (head == null)
            {
                return null;
            }

            if (head.next == null)
            {
                return head;
            }

            var trailingOdd = head;
            var headEven = head.next;
            var trailingEven = head.next;

            var oddPtr = trailingEven.next;
            var evenPtr = oddPtr?.next;

            while (oddPtr != null)
            {
                trailingOdd.next = oddPtr;
                trailingEven.next = evenPtr;

                trailingOdd = oddPtr;
                trailingEven = evenPtr;
                trailingOdd.next = headEven;

                oddPtr = trailingEven?.next;
                evenPtr = oddPtr?.next;
            }

            return head;
        }

        public bool IsPalindrome(ListNode head)
        {
            if (head == null) return true;

            ListNode firstHalfEnd = EndOfFirstHalf(head);
            ListNode secondHalfStart = ReverseList(firstHalfEnd.next);

            ListNode p1 = head;
            ListNode p2 = secondHalfStart;
            bool result = true;
            while (result && p2 != null)
            {
                if (p1.val != p2.val) result = false;
                p1 = p1.next;
                p2 = p2.next;
            }

            // Restore the list and return the result.
            firstHalfEnd.next = ReverseList(secondHalfStart);
            return result;
        }

        private ListNode ReverseList(ListNode head)
        {
            ListNode prev = null;
            ListNode curr = head;
            while (curr != null)
            {
                ListNode nextTemp = curr.next;
                curr.next = prev;
                prev = curr;
                curr = nextTemp;
            }
            return prev;
        }

        private ListNode EndOfFirstHalf(ListNode head)
        {
            ListNode fast = head;
            ListNode slow = head;
            while (fast.next != null && fast.next.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
            }
            return slow;
        }

        public bool IsPalindromeRecursively(ListNode head)
        {
            frontPointer = head;
            return RecursivelyCheck(head);
        }

        private bool RecursivelyCheck(ListNode currentNode)
        {
            if (currentNode != null)
            {
                if (!RecursivelyCheck(currentNode.next)) return false;
                if (currentNode.val != frontPointer.val) return false;
                frontPointer = frontPointer.next;
            }
            return true;
        }

        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode prehead = new ListNode(-1);

            ListNode prev = prehead;
            while (l1 != null && l2 != null)
            {
                if (l1.val <= l2.val)
                {
                    prev.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    prev.next = l2;
                    l2 = l2.next;
                }
                prev = prev.next;
            }
            prev.next = l1 ?? l2;

            return prehead.next;

            /*
            if (l1 == null)
            {
                return l2;
            }

            if (l2 == null)
            {
                return l1;
            }

            var firstPointer = l1;
            var secondPointer = l2;
            if (l1.val > l2.val)
            {
                firstPointer = l2;
                secondPointer = l1;
            }

            var newHead = new ListNode(firstPointer.val);
            var currNode = newHead;
            firstPointer = firstPointer.next;

            while (firstPointer != null && secondPointer != null)
            {
                while (firstPointer?.val < secondPointer?.val)
                {
                    currNode.next = new ListNode(firstPointer.val);
                    firstPointer = firstPointer.next;
                    currNode = currNode.next;
                }
                //firstPointer = firstPointer?.next;

                while (secondPointer?.val < firstPointer?.val)
                {
                    currNode.next = new ListNode(secondPointer.val);
                    secondPointer = secondPointer.next;
                    currNode = currNode.next;
                }
                secondPointer = secondPointer?.next;
            }

            while (firstPointer != null)
            {
                currNode.next = new ListNode(firstPointer.val);
                currNode = currNode.next;
                firstPointer = firstPointer.next;
            }

            while (secondPointer != null)
            {
                currNode.next = new ListNode(secondPointer.val);
                currNode = currNode.next;
                secondPointer = secondPointer.next;
            }
            

            return newHead;*/
        }
    }
}