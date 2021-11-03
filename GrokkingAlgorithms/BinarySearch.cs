using System;
using System.Collections.Generic;
using static System.Console;

namespace GrokkingAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("test square:" + GetBestSquare(1680001, 640000).ToString());
            var rnd1 = new Random();
/*
            int[] list1 = new int[100];
            for (int i = 0; i < list1.Length; i++)
            {
                list1[i] = rnd1.Next(int.MinValue, int.MaxValue);
                Console.WriteLine(list1[i]);

            }
            list1 = sortList(list1);
            Console.WriteLine("Sorted-eeee---");
            for (int i = 0; i < list1.Length; i++)
            {
                Console.WriteLine(list1[i]);

            }

            var rnd = new Random();
            int targetValue = rnd.Next(-1, 101);
            if (args?.Length > 0)
                int.TryParse(args[0], out targetValue);

            WriteLine($"Looking for value {targetValue}");

            var list = new List<int>();
            for (int i = 1; i < 100; i += 2)
                list.Add(i);

            (int index, int value) = BinarySearch(targetValue, list);

            WriteLine("==========================");
            if (index == -1)
                WriteLine($"Value {targetValue} not found");
            else
                WriteLine($"Found value {value} at index {index}");
                */
        }

        private static (int, int) BinarySearch(int targetValue, List<int> list)
        {
            int stepCount = 0;
            int low = 0;
            int high = list.Count - 1;

            while (low <= high)
            {
                stepCount++;
                int mid = (low + high) / 2;
                int guess = list[mid];

                WriteLine("--------------------------");
                WriteLine($"Step {stepCount}");
                WriteLine($"Trying location {mid}");
                WriteLine($"Value at location is {list[mid]}");

                if (guess == targetValue)
                    return (mid, list[mid]);
                if (guess > targetValue)
                    high = mid - 1;
                if (guess < targetValue)
                    low = mid + 1;
            }

            return (-1, -1);
        }
        public static int[] sortList(int[] list)
        {
            for (int i = 1; i < list.Length; i++)
            {
                if (list[i] > list[i - 1])
                {
                    //swap
                    int tempSwap = list[i - 1];
                    list[i - 1] = list[i];
                    list[i] = tempSwap;
                    list = sortList2(list, i - 1);
                }
            }
            return list;
        }
        public static int[] sortList2(int[] list, int index)
        {
            for (int i = index; i >= 1; i--)
            {
                if (list[i] > list[i - 1])
                {
                    //swap
                    int tempSwap = list[i - 1];
                    list[i - 1] = list[i];
                    list[i] = tempSwap;
                }
            }
            return list;
        }
        public static int GetBestSquare(int x, int y)
        {
        
            if (x > y)
            {
                if(y==0)return x;
             return   GetBestSquare(x-y*Math.Abs(x/y), y);
            }
            if (y > x)
            {
                if(x==0)return y;
             return   GetBestSquare(y-x*Math.Abs(y/x), x);
            }

            return x;
        }
    }
}
