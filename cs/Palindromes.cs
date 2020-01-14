using System;
using System.Collections.Generic;

namespace hello_dotnet_core
{
    partial class Program
    {
        // A word is a palindrome iff reversing it results in the same word.
        private static void PalindromeChecks()
        {
            // Check some palindromes
            Console.WriteLine("Checking for Palindromes...");

            List<String> words = new List<String>
            {
                "Hello",
                "Helleh",
                "Heleh",
                "Helee"
            };

            words.ForEach(s =>
                {
                    Word w = new Word(s);
                    Console.WriteLine("\"{0}\" {1} a palindrome.", w, w.IsPalindrome ? "is" : "is NOT");
                });
        }

        // contrived private class just for s&gs
        private class Word
        {
            private readonly string word;

            internal Word(string word)
            {
                this.word = word?.ToLower() ?? "";
            }

            internal bool IsPalindrome
            {
                get
                {
                    for (int i = 0; i < word.Length / 2; i++)
                    {
                        if (!word[i].Equals(word[word.Length - 1 - i]))
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }

            override public string ToString() => this.word;
        }
    }
}