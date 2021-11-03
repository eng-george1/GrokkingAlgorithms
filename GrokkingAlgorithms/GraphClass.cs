using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace GrokkingAlgorithms
{
    public class GraphClass
    {
        public static void GraphTestCaller()
        {
            Hashtable ht = new Hashtable();
            ht.Add("you", new string[] { "alice", "bob", "claire" });
            ht.Add("bob", new string[] { "anuj", "peggy" });
            ht.Add("alice", new string[] { "peggy" });
            ht.Add("claire", new string[] { "thom", "jonny" });
            ht.Add("anuj", new string[] { });
            ht.Add("peggy", new string[] { });
            ht.Add("thom", new string[] { });
            ht.Add("jonny", new string[] { });
            names.Add("you");
            Console.WriteLine(SearchInGraph(ht, "alice"));


            Hashtable ht1 = new Hashtable();
            ht1.Add("book", new Hashtable { { "LP", 5 }, { "Poster", 0 } ,{ "Poster", 0 }});
            ht1.Add("LP", new Hashtable { { "Guitar", 15 }, { "Drum", 20 } });
            ht1.Add("Poster", new Hashtable { { "Guitar", 30 }, { "Drum", 35 } });
            ht1.Add("Guitar", new Hashtable { { "Piano", 20 } });
            ht1.Add("Drum", new Hashtable { { "Piano", 10 }, });


            Console.WriteLine(SearchInGraph(ht1, "alice"));
            //  List<long> t=new List<long>();
            //miniMaxSum(new List<int>() { 256741038, 623958417, 467905213, 714532089, 938071625 });
            //miniMaxSum(new List<Int32>() { 256741038, 623958417, 467905213, 714532089 ,938071625});

        }
        public static void miniMaxSum(List<int> arr)
        {
            arr.Sort();
            Console.Write(arr.Take(arr.Count - 1).Sum(c => (long)c));
            Console.Write(" ");
            Console.Write(arr.Skip(1).Take(arr.Count).Sum(c => (long)c));
            // Console.Write(arr.Aggregate((currentSum, item)=> currentSum + item)-arr.Last());
            //Console.Write(" ");
            //Console.Write(arr.Aggregate((currentSum, item)=> currentSum + item)-arr.First());
            // Console.WriteLine(arr.Skip(1).Take(arr.Count).Sum());
            //2063136757 2744467344
        }
        public static string timeConversion(string s)
        {
            DateTime time1 = DateTime.Parse(s);
            return time1.ToString("HH:mm:ss");

        }
        static List<string> names = new List<string>();
        public static String SearchInGraph(Hashtable ht, string condition)
        {


            for (int i = 0; i < names.Count(); i++)
            {
                if (names[i] == condition)
                    return condition;
                AppendChild(ht, names[i]);
            }
            return "Not Exists";
        }

        public static void AppendChild(Hashtable ht, string root)
        {
            //search for chilleds
            String[] childs = (String[])ht[root];
            for (int i = 0; i < childs.Count(); i++)
            {
                if (!names.Exists(c => c == childs[i]))
                    names.Add(childs[i]);
            }
        }
        static List<KeyValuePair<string, int>> paths = new List<KeyValuePair<string, int>>();
        public static String Dijkstra(Hashtable ht, string condition)
        {
            paths.Add(new KeyValuePair<string, int>(condition, 0));
           // Hashtable tempdt = ht.Values.OfType<Hashtable>().Where(k => k == "Key");
           // foreach (DictionaryEntry item in ht)
           // {

            //}
            for (int i = 0; i < names.Count(); i++)
            {
                if (names[i] == condition)
                    return condition;
                Dijkstra2(ht, names[i]);
            }
            return "Not Exists";
        }

        public static void Dijkstra2(Hashtable ht, string root)
        {
            //search for chilleds
            String[] childs = (String[])ht[root];
            for (int i = 0; i < childs.Count(); i++)
            {
                if (!names.Exists(c => c == childs[i]))
                    names.Add(childs[i]);
            }
        }
    }

}