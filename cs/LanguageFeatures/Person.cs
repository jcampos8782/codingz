using System;
namespace hello_dotnet_core.LanguageFeatures
{
    // Used for demonstrations of features in the Additions* classes.
    public class Person
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string MiddleName { get; }

        public Person(string firstName = null, string lastName = null, string middleName = null)
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
        }

        public void Deconstruct(out string firstName, out string lastName)
        {
            (firstName, lastName) = (FirstName, LastName);
        }
    }
}
