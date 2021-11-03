using System;
using System.Collections.Generic;

namespace GrokkingAlgorithms
{
    public class QSortClass
    {
        public static void QSortTestCaller()
        {
            List<int> tempList = new List<int> { 20,12,12,19,17,2,10, 5, 4,12, 1,12 };
            Console.WriteLine(string.Join(",", QSort(tempList).ToArray()));
        }
        public static List<int> QSort(List<int> list)
        {
            if (list.Count < 2)
                return list;
            List<int> smallerList = new List<int>();
            List<int> greaterList = new List<int>();
            List<int> newList = new List<int>();
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i] > list[0])
                    greaterList.Add(list[i]);
                else
                    smallerList.Add(list[i]);
            }
            newList.AddRange(QSort(smallerList));
            newList.Add(list[0]);
            newList.AddRange(QSort(greaterList));
            return newList;
        }
    }
}