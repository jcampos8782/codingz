using System;
using System.Collections.Generic;

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
        }

        private static void Break()
        {
            Console.WriteLine();
            Console.WriteLine("================================");
            Console.WriteLine();
        }
    }
}
