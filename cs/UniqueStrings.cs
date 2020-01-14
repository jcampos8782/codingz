using System;
using System.Collections.Generic;

namespace hello_dotnet_core
{
    partial class Program
    {
        // Checks some strings to determine whether all characters are unique.
        // Case sensitive!
        private static void CheckUniqueCharacters()
        {

            Console.WriteLine("Checking strings for unique characters...");
            List<String> strings = new List<String>
            {
                "The quick brown fox jumps over the lazy dog.",
                "abcdefghijklmnopqrstuvwxyz",
                "abcdefghijklmnopqrstuvwxyzz",
                "aabcdefghijklmnopqrstuvwxyz",
                "aabcdefghijklmnopqrstuvwxyzABCDEFG",
                "zyxwvutsrqponmlkjighfedcba",
                "definitely not unique",
                "Uniq chars"
            };

            strings.ForEach(s =>
            {
                HashSet<char> charset = new HashSet<char>();
                foreach (char c in s)
                {
                    if (charset.Contains(c))
                    {
                        Console.WriteLine($"\"{s}\" contains more than one '{c}'");
                        return;
                    }
                    charset.Add(c);
                }
                Console.WriteLine($"\"{s}\" contains only unique characters");
            });
        }
    }
}
