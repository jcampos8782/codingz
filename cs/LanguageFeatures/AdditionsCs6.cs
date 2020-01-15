using System;
using System.Collections.Generic;

namespace hello_dotnet_core.FeaturesCs6
{
    public class ReadOnlyAutoProperties
    {
        public ReadOnlyAutoProperties(string firstName, string lastName)
        {
            // Read-only properties can only be set in the constructor.
            FirstName = firstName;
            LastName = lastName;
        }

        // Although these properties are public, there is no way to publicly
        // SET them. They are effectively read-only. 
        public string FirstName { get; }
        public string LastName{ get; }
    }

    // The nameOf operator provides a nice way to reference methods or properties
    // in code. 
    public class NameOfOperator
    {
        public NameOfOperator(string paramName)
        {
            if (paramName == null)
                throw new ArgumentException(message: "Cannot be null", nameof(paramName));
        }
    }

    public class AutoPropertyInitializers
    {
        // Initialize the property and provide the getter as one statement.
        public ICollection<string> Names { get; } = new List<string>();

        public AutoPropertyInitializers()
        {
            Names.Add("Jason Campos");
        }
    }

    // Expression bodied functions provide a clean syntax for functions or methods
    // which only include a return statement.
    public class ExpressionBodiedFunctionMembers
    {
        public ExpressionBodiedFunctionMembers(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        private string FirstName { get; }
        private string LastName { get; }

        // No handlebars... yay!
        public override string ToString() => $"{LastName}, {FirstName}";
    }

    // The ? operator and ?? operator make null checks more transparent and
    // provide a concise syntax for dealing with nulls and settings defaults.
    public class NullConditionalOperators
    {
        private string FirstName { get; }
        private string LastName { get; }
        private string MiddleName { get; }

        public NullConditionalOperators(Person p)
        {
            // Will be "John" if p or FirstName is null
            FirstName = p?.FirstName ?? "John";

            // Will be "Doe" if p or LastName is null
            LastName = p?.LastName ?? "Doe";

            // Will be null of p is null
            MiddleName = p?.MiddleName; 
        }

        // The null operators can also be used in expressions
        public override string ToString() => $"{LastName}, {FirstName} {MiddleName ?? ""}";
    }

    // Exception filters add a "when" keyword to provide a sort of switch statement
    // for exception handling
    public class ExceptionFilters
    {
        public ExceptionFilters(string msg)
        {
            try
            {
                throw new Exception(message: msg);
            }
            catch (Exception e) when (e.Message.Contains("foo"))
            {
                Console.WriteLine("I pity you.");
            }
            catch (Exception e) when (e.Message.Contains("secretm3ssage"))
            {
                Console.WriteLine("The secret is out!");
            }
        }
    }

    // Nothing here... just a class for the demo
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
    }
}
