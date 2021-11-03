using System;
using System.Collections.Generic;
using System.Text;

namespace quicksort
{
    public static class Exercises
    {
        // Exercise 4.1 Recursive sum
        public static int Sum(List<int> input)
        {
            if (input.Count == 1)
                return input[0];
            else
                return input[0] + Sum(input.GetRange(1, input.Count - 1));
        }

        // Exercise 4.2 Recursive count
        public static int Count<T>(List<T> input)
        {
            if (input.Count == 1)
                return 1;
            else
                return 1 + Count(input.GetRange(1, input.Count - 1));
        }

        // Exercise 4.3 Recursive maximum
        public static T Max<T>(List<T> input) where T : IComparable
        {
            if (input.Count == 1)
                return input[0];
            else if (input.Count == 2)
                return (input[0].CompareTo(input[1]) > 0) ? input[0] : input[1];
            else
            {
                T subMax = Max(input.GetRange(1, input.Count - 1));
                return (input[0].CompareTo(subMax) > 0) ? input[0] : subMax;
            }
        }

        
        static void Main(string[] args)
        {
            var list = new List<int> { 87, 92, 34, 1, 90, 25, 78 };
            Console.WriteLine(OutputList(list, "Initial List"));

            var sortedList = Quicksort(list);
            Console.WriteLine(OutputList(sortedList, "Sorted List"));

            Console.WriteLine($"Sum: {Exercises.Sum(list)}");
            Console.WriteLine($"Count: {Exercises.Count(list)}");
            Console.WriteLine($"Max: {Exercises.Max(list)}");

            Console.WriteLine("------------------------------");

            var names = new List<string>
            {
                "Kelly",
                "Jeremy",
                "Mandy",
                "Toby",
                "Lulu",
                "Penny",
                "Max"
            };
            Console.WriteLine(OutputList(names, "Initial Names"));

            var sortedNames = Quicksort(names);
            Console.WriteLine(OutputList(sortedNames, "Sorted Names"));

            Console.WriteLine($"Count: {Exercises.Count(names)}");
            Console.WriteLine($"Max: {Exercises.Max(names)}");
        }

        static List<T> Quicksort<T>(List<T> list) where T : IComparable
        {
            if (list.Count < 2)
                return list;
            else
            {
                var pivot = list[0];
                var less = new List<T>();
                var greater = new List<T>();
                foreach (T item in list)
                {
                    if (item.CompareTo(pivot) < 0)
                        less.Add(item);
                    if (item.CompareTo(pivot) > 0)
                        greater.Add(item);
                }

                var newList = new List<T>();
                newList.AddRange(Quicksort(less));
                newList.Add(pivot);
                newList.AddRange(Quicksort(greater));
                return newList;
            }
        }

        static string OutputList<T>(List<T> list, string header = "List Values")
        {
            var output = new StringBuilder();
            output.Append($"{header} {{ ");
            foreach (var item in list)
                output.Append($"{item}, ");
            output.Remove(output.Length - 2, 2);
            output.Append(" }");
            return output.ToString();
        }
    }

    }
