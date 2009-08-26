using NUnit.Framework;
using ContactsDomain.RepositoryInterfaces;
using ContactsDomain.BusinessManagers;
using ContactsDomain.DomainObjects;
using System.Collections.Generic;
using System.Linq;
using TestUtils;
using ContactsDomain.Tests;

namespace ContactsDomain.Tests
{
    [TestFixture]
    public class PersonManager_Fixtures
    {
        [Test]
        public void PersonManager_GetAll_ReturnsListFromRepository()
        {
            // Arrange
            List<Person> personList = new List<Person>();

            personList.Add(new Person() { Id = 1, Forename = "Jimmy", Surname = "Choo", BirthdayDay = 1, BirthdayMonth = 1 });
            personList.Add(new Person() { Id = 2, Forename = "Sammy", Surname = "Davis", BirthdayDay = 31, BirthdayMonth = 12 });
            personList.Add(new Person() { Id = 3, Forename = "Patsy", Surname = "Kensit", BirthdayDay = 1, BirthdayMonth = 1 });

            FakePersonRepository mockRepository = new FakePersonRepository();
            mockRepository.PersonList = personList;

            PersonManager manager = new PersonManager(mockRepository);

            // Act
            ICollection<Person> managerPeople = manager.GetAllPeople();

            // Assert
            Assert.AreEqual(3, managerPeople.Count, "The wrong number of people were loaded");
            foreach (Person p in managerPeople)
            {
                Person testPerson = (from person in personList
                                    where person.Id == p.Id
                                    select person).Single();

                Assertions.AssertPeopleAreEqual(p, testPerson);
            }
        }

        [Test]
        public void PersonManager_AddPerson_AddsToRepository()
        {
            //Arrange
            FakePersonRepository mockRepository = new FakePersonRepository();
            PersonManager manager = new PersonManager(mockRepository);

            Person p = new Person() { Id = 1, Forename = "Ted", Surname = "Smith", BirthdayDay = 1, BirthdayMonth = 12 };

            //Act 
            manager.AddPerson(p);

            //Assert
            Assert.IsNotNull(mockRepository.AddedPerson, "Person not added to repository");
            Assertions.AssertPeopleAreEqual(p, mockRepository.AddedPerson);
        }

        [Test]
        public void PersonManager_UpdatePerson_UpdatesPersonInRepository()
        {
            //Arrange
            FakePersonRepository mockRepository = new FakePersonRepository();
            PersonManager manager = new PersonManager(mockRepository);

            Person p = PersonObjectMother.GetPerson(TestPeople.Bill);

            //Act 
            manager.UpdatePerson(p);

            //Assert
            Assert.IsNotNull(mockRepository.UpdatedPerson, "Person not updated in repository");
            Assertions.AssertPeopleAreEqual(p, mockRepository.UpdatedPerson);
        }

        [Test]
        public void PersonManager_DeletePerson_RemovesFromRepository()
        {
            //Arrange
            FakePersonRepository mockRepository = new FakePersonRepository();
            PersonManager manager = new PersonManager(mockRepository);

            Person p = new Person() { Id = 1, Forename = "Ted", Surname = "Smith", BirthdayDay = 1, BirthdayMonth = 12 };

            //Act 
            manager.DeletePerson(p);

            //Assert
            Assert.IsNotNull(mockRepository.DeletedPerson, "Person not removed from repository");
            Assertions.AssertPeopleAreEqual(p, mockRepository.DeletedPerson);
        }
    }

    internal class FakePersonRepository : IPersonRepository
    {
        internal List<Person> PersonList { get; set; }
        internal Person AddedPerson { get; set; }
        internal Person DeletedPerson { get; set; }
        internal Person UpdatedPerson { get; set; }

        #region IRepository<Person> Members

        public void Add(ContactsDomain.DomainObjects.Person Entity)
        {
            AddedPerson = Entity;
        }

        public void Update(ContactsDomain.DomainObjects.Person Entity)
        {
            UpdatedPerson = Entity;
        }

        public void Remove(ContactsDomain.DomainObjects.Person Entity)
        {
            DeletedPerson = Entity;
        }

        public ContactsDomain.DomainObjects.Person GetById(int Id)
        {
            throw new System.NotImplementedException();
        }

        public System.Collections.Generic.ICollection<ContactsDomain.DomainObjects.Person> GetAll()
        {
            return PersonList;
        }

        public void SaveList(System.Collections.Generic.ICollection<ContactsDomain.DomainObjects.Person> EntityList)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
