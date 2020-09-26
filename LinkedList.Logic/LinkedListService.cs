﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace LinkedList.Logic
{
    public class LinkedListService
    {
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
    }
}