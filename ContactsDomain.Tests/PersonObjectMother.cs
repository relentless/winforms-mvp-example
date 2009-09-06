using ContactsDomain.DomainObjects;
using System.Collections.Generic;
using System.Diagnostics;

namespace ContactsDomain.Tests
{
    public enum TestPeople
    {
        Ted, Sue, Bill
    }

    /// <summary>
    /// Creates predefined Person objects for testing
    /// </summary>
    public static class PersonObjectMother
    {
        public static Person GetPerson(TestPeople name)
        {
            switch (name)
            {
                case TestPeople.Ted:
                    return new Person() { Forename = "Ted", Surname = "Jones", BirthdayDay = 1, BirthdayMonth = 1 };
                case TestPeople.Bill:
                    return new Person() { Forename = "Bill", Surname = "Bailey", BirthdayDay = 31, BirthdayMonth = 12 };
                case TestPeople.Sue:
                    return new Person() { Forename = "Sue", Surname = "Smedley", BirthdayDay = 15, BirthdayMonth = 6 };
                default:
                    Debug.Assert(false, "Invalid person selected");
                    return null;
                    break;
            }
        }

    }
}
