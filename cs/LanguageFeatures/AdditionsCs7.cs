using System;
namespace hello_dotnet_core.LanguageFeatures
{
    // Out variables can be declared inline to save yourself a line of code.
    public class InlineOutVariables
    {
        public static void Example()
        {
            // Define the out variable inline
            Format("I AM YELLING", out string formatted);
            Console.WriteLine(formatted);
        }

        public static void Format(string input, out string output)
        {
            output = input?.ToLower().Replace("yelling", "whispering");
        }
    }

    // C# 7 makes it possible to create named tuples in order to eliiminate
    // boilerplate classes. Tuples are super lightweight and provide a clean
    // sytax for defining structured data. They also allow for deconstruction
    // of objects into individual fields. This means less code when converting
    // from one class to another as is frequently seen on data transfer objects (DTOs)
    public class ImprovedTuples
    {
        public static void Example()
        {
            // Unnamed tuples are accessible as Item1 and Item2 just as before
            var unnamed = ("item1", "item2");
            Console.WriteLine($"{unnamed.Item1}, {unnamed.Item2}");

            // Create named tuples using a json-like syntax
            var named = (first: "one", second: "two");
            Console.WriteLine($"{named.first}, {named.second}");

            Person p = new Person("Jason", "Campos", "David");

            // Alternatively, the names can be placed on the left hand
            // side of the assignment operation:
            (string First, string Last) name = (p.FirstName, p.LastName);
            Console.WriteLine($"Name: {name.Last}, {name.First}");

            // Or extract individual fields by assignment
            (string FirstName, string LastName) = p;
            Console.WriteLine($"Name: {FirstName}, {LastName}");
        }
    }

    // Discards are used to indicate to the compiler that you do not care about
    // certain out parameters, tuple fields, etc. 
    public class Discards
    {
        public static void DeconstructInitials(Person p, out char first, out char middle, out char last)
        {
            first = p.FirstName.ToCharArray()[0];
            middle = p.MiddleName.ToCharArray()[0];
            last = p.LastName.ToCharArray()[0];
        }

        public static void Example()
        {
            Person p = new Person("Jason", "David", "Campos");

            // Using _ ignores the middle name parameter
            DeconstructInitials(p, out char f, out var _, out char l);
            Console.WriteLine($"Initials: {f}.{l}.");
        }
    }
}
