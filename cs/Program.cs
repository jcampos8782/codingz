using System;
using System.Collections.Generic;
using hello_dotnet_core.DataStructures;

namespace hello_dotnet_core
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Break();
            PalindromeChecks();
            Break();
            CheckUniqueCharacters();
            Break();
            CheckPermutations();
            Break();
            PermutationOfPalindromes();
            Break();
            CheckOneEditAway();
            Break();

            Trie t = new Trie();
            t.Insert("Hello");
            t.Insert("Heathen");
            t.Insert("Heaven");
            t.Insert("Apply");
            t.Insert("Apple");
            t.Insert("App");

            string[] searches = {
                "a",
                "ap",
                "apple",
                "he",
                "hea",
                "heav"
            };

            foreach(string s in searches)
            {
                foreach(string m in t.Search(s))
                    Console.WriteLine("Match: search={0} match={1}", s, m);
            }

            Break();
            var lruCache = new LruCache<string, int>(3);
            lruCache.Add("a", 1);
            lruCache.Add("b", 2);
            lruCache.Add("c", 3);

            Console.WriteLine("a={0} (expect 1)", lruCache.Get("a"));

            lruCache.Add("d", 4);
            Console.WriteLine("b={0} (expect null)", lruCache.Get("b"));
        }

        private static void Break()
        {
            Console.WriteLine();
            Console.WriteLine("================================");
            Console.WriteLine();
        }
    }
}
