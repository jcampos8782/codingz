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
        }

        private static void Break()
        {
            Console.WriteLine();
            Console.WriteLine("================================");
            Console.WriteLine();
        }
    }
}
