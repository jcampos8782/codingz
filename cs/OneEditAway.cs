using System;
using System.Collections.Generic;

namespace hello_dotnet_core
{
    partial class Program
    {
        static void CheckOneEditAway()
        {
            Console.WriteLine("Checking if strings are one edit away...");
            List<Tuple<string, string>> tuples = new List<Tuple<string, string>>
            {
                Tuple.Create<string, string>("bike", "Bike"), // t
                Tuple.Create<string, string>("bike", "pike"), // t
                Tuple.Create<string, string>("bike", "biker"),
                Tuple.Create<string, string>("bike", "ike"), // t
                Tuple.Create<string, string>("bike", "bike"), // t
                Tuple.Create<string, string>("a slightly longer string is one edit apart",
                    "A slightly longer string is one edit apart"), // t
                Tuple.Create<string, string>("a slightly longer string is more than one edit apart",
                    "A slightly longer string is two edits apart"), // f
                Tuple.Create<string, string>("bike", "brie"), // f
                Tuple.Create<string, string>("bike", "bikers") // f
            };

            foreach(Tuple<string,string> t in tuples)
            {
                string s1 = t.Item1;
                string s2 = t.Item2;

                // If lengths differ by more than one, more than one edit must have occurred
                if (Math.Abs(s1.Length - s2.Length) > 1)
                {
                    AreOneEditApart(s1, s2, false);
                    continue;
                }

                // Allow one difference.
                int differenceAllowance = 1;

                Stack<Char> s1Chars = new Stack<char>();
                Stack<Char> s2Chars = new Stack<char>();
                Array.ForEach(s1.ToCharArray(), c => s1Chars.Push(c));
                Array.ForEach(s2.ToCharArray(), c => s2Chars.Push(c));

                while (s1Chars.Count > 0 && s2Chars.Count > 0)
                {
                    char s1Char = s1Chars.Pop();
                    char s2Char = s2Chars.Pop();

                    if (s1Char.Equals(s2Char))
                    {
                        continue;
                    }

                    if (differenceAllowance > 0)
                    {
                        // Push the last character of the shorter back onto the stack and
                        // continue with the comparison.
                        if (s1Chars.Count > s2Chars.Count)
                            s1Chars.Push(s1Char);
                        else
                            s2Chars.Push(s2Char);
                    }
                    differenceAllowance--;
                }

                AreOneEditApart(s1, s2, differenceAllowance >= 0);
            }

            void AreOneEditApart(string s1, string s2, bool b)
            {
                Console.WriteLine("\"{0}\" and \"{1}\" {2} more than one edit apart", s1, s2, b ? "are NOT" : "ARE");
                Console.WriteLine("--------------");
            }
        }
    }
}
