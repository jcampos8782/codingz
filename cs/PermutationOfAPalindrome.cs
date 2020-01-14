using System;
using System.Collections.Generic;
using System.Text;

namespace hello_dotnet_core
{
    partial class Program
    {
        const int SHUFFLE_COUNT = 10;

        // Determines if a string is a permutation of a palindrome.
        // CASE INSENSITIVE
        static void PermutationOfPalindromes()
        {
            Console.WriteLine("Checking if strings are permutations of palindromes");

            // If the length of the string is even, all characters must appear
            // an even number of times. If the length of the string is odd,
            // exactly one character must have an odd count.

            List<String> strings = new List<String>
            {
                "siThe drowword is   eht",
                "This is not a palindrome",
                "Testing 1 1 1 222 222 1 1 1 gnitset",
                "#####",
                "#$#$#$_",
                "#$$$$#_",
                "#$#$#$_a"
            };

            strings.ForEach(s =>
                {
                    Console.WriteLine($"Checking \"{s}\"");

                    // Count cars for each key
                    Dictionary<Char, int> counts = new Dictionary<Char, int>();

                    // Make case insensitive
                    foreach (char c in s.ToLowerInvariant())
                    {
                        counts.TryGetValue(c, out int count);
                        counts[c] = count + 1;
                    }

                    // Odd length strings are allowed one odd count
                    int oddAllowance = (s.Length % 2 == 0) ? 0 : 1;

                    foreach(int count in counts.Values)
                    {
                        if (count % 2 != 0)
                        {
                            oddAllowance--;
                        }
                    }

                    // Allowance must be EXACTLY 0 in order to be a permutation of a palindrome
                    bool isPermutation = oddAllowance == 0;

                    Console.WriteLine("{0} a permutation of a palindrome.", isPermutation ? "IS" : "Is NOT");
                    Console.WriteLine("------------");
                });
        }
    }
}
