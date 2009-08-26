using NUnit.Framework;
using ContactsDomain.DomainObjects;

namespace TestUtils
{
    public static class Assertions
    {
        public static void AssertPeopleAreEqual(Person p1, Person p2)
        {
            Assert.AreEqual(p1.Id, p2.Id, "Id's don't match");
            Assert.AreEqual(p1.Forename, p2.Forename, "Forename's don't match");
            Assert.AreEqual(p1.Surname, p2.Surname, "Surname's don't match");
            Assert.AreEqual(p1.BirthdayDay, p2.BirthdayDay, "BirthdayDay's don't match");
            Assert.AreEqual(p1.BirthdayMonth, p2.BirthdayMonth, "BirthdayMonth's don't match");
        }
    }
}
