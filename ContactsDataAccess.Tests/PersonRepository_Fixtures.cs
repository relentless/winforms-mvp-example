using NUnit.Framework;
using ContactsDataAccess.Repository;
using ContactsDomain.DomainObjects;
using ContactsDomain.RepositoryInterfaces;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NHibernate;
using Iesi.Collections.Generic;
using System.Collections.Generic;
using TestUtils;

namespace ContactsDataAccess.Tests
{
    [TestFixture]
    public class PersonRepository_Fixtures
    {
        private ISessionFactory _sessionFactory;
        private Configuration _config;

        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            _config = new Configuration();
            _config.Configure();
            _config.AddAssembly(typeof(Person).Assembly);
            _sessionFactory = _config.BuildSessionFactory();
        }

        [Test]
        public void can_add_new_person()
        {
            GenerateDatabaseSchema();
            
            Person p = new Person() { Id = 1, Forename = "Jimmy", Surname = "Choo", BirthdayDay = 1, BirthdayMonth = 1 };
            IPersonRepository repository = new PersonRepository();
            repository.Add(p);

            using (ISession session = _sessionFactory.OpenSession())
            {
                Person databasePerson;
                databasePerson = session.Get<Person>(p.Id);

                Assert.IsNotNull(databasePerson, "Person not loaded from Database");
                Assertions.AssertPeopleAreEqual(p, databasePerson);
            }
        }

        [Test]
        public void can_add_new_person_with_email()
        {
            GenerateDatabaseSchema();

            Person p = new Person() { Id = 1, Forename = "Jimmy", Surname = "Choo", BirthdayDay = 1, BirthdayMonth = 1 };
            p.AddEmail("test@test.com");
            
            IPersonRepository repository = new PersonRepository();
            repository.Add(p);

            using (ISession session = _sessionFactory.OpenSession())
            {
                Person databasePerson;
                databasePerson = session.Get<Person>(p.Id);

                Assert.IsNotNull(databasePerson, "Person not loaded from Database");
                Assertions.AssertPeopleAreEqual(p, databasePerson);

                Assert.IsTrue(databasePerson.EmailAddresses.Contains("test@test.com"), "Email address not found");
            }
        }

        [Test]
        public void can_add_new_person_with_phone_number()
        {
            GenerateDatabaseSchema();

            Person p = new Person() { Id = 1, Forename = "Jimmy", Surname = "Choo", BirthdayDay = 1, BirthdayMonth = 1 };
            PhoneNumber num = new PhoneNumber(1, "12345678");
            p.AddPhoneNumber(num);

            IPersonRepository repository = new PersonRepository();
            repository.Add(p);

            using (ISession session = _sessionFactory.OpenSession())
            {
                Person databasePerson;
                databasePerson = session.Get<Person>(p.Id);

                Assert.IsNotNull(databasePerson, "Person not loaded from Database");
                Assertions.AssertPeopleAreEqual(p, databasePerson);

                Assert.AreEqual(1, databasePerson.PhoneNumbers.Count, "List does not contain one phone number");
                foreach (PhoneNumber number in databasePerson.PhoneNumbers)
                {
                    Assert.AreEqual(num.Id, number.Id, "Id of phone number not equal");
                    Assert.AreEqual(num.Number, number.Number, "Id of phone number not equal");
                }
            }
        }

        [Test]
        public void can_update_person()
        {
            GenerateDatabaseSchema();

            Person p = new Person() { Id = 1, Forename = "Jimmy", Surname = "Choo", BirthdayDay = 1, BirthdayMonth = 1 };
            AddPersonToDatabase(p);

            p.Forename = "John";
            p.Surname = "Wayne";
            p.BirthdayMonth = 12;
            p.BirthdayDay = 31;

            IPersonRepository repository = new PersonRepository();
            repository.Update(p);

            using (ISession session = _sessionFactory.OpenSession())
            {
                Person databasePerson;
                databasePerson = session.Get<Person>(p.Id);

                Assert.IsNotNull(databasePerson, "Person not loaded from Database");
                Assertions.AssertPeopleAreEqual(p, databasePerson);
            }
        }

        [Test]
        public void can_remove_person()
        {
            GenerateDatabaseSchema();

            Person p = new Person() { Id = 1, Forename = "Jimmy", Surname = "Choo", BirthdayDay = 1, BirthdayMonth = 1 };
            AddPersonToDatabase(p);

            IPersonRepository repository = new PersonRepository();
            repository.Remove(p);

            using (ISession session = _sessionFactory.OpenSession())
            {
                Person databasePerson = session.Get<Person>(p.Id);

                Assert.IsNull(databasePerson, "Person found in Database when they shouldn't be");
            }
        }

        [Test]
        public void can_get_by_id()
        {
            GenerateDatabaseSchema();

            Person p = new Person() { Id = 1, Forename = "Jimmy", Surname = "Choo", BirthdayDay = 1, BirthdayMonth = 1 };
            AddPersonToDatabase(p);

            IPersonRepository repository = new PersonRepository();
            Person databasePerson = repository.GetById(p.Id);

            Assert.IsNotNull(databasePerson, "Person not loaded from Database");
            Assertions.AssertPeopleAreEqual(p, databasePerson);
        }

        [Test]
        public void can_get_all()
        {
            GenerateDatabaseSchema();

            Person[] people = new Person[3];
            
            people[0] = new Person() { Id = 1, Forename = "Jimmy", Surname = "Choo", BirthdayDay = 1, BirthdayMonth = 1 };
            people[1] = new Person() { Id = 2, Forename = "Sammy", Surname = "Davis", BirthdayDay = 31, BirthdayMonth = 12 };
            people[2] = new Person() { Id = 3, Forename = "Patsy", Surname = "Kensit", BirthdayDay = 1, BirthdayMonth = 1 };

            AddPersonToDatabase(people[0]);
            AddPersonToDatabase(people[1]);
            AddPersonToDatabase(people[2]);

            IPersonRepository repository = new PersonRepository();
            ICollection<Person> databasePeople = repository.GetAll();

            Assert.IsNotNull(databasePeople, "Person not loaded from Database");
            Assert.AreEqual(3, databasePeople.Count, "Wrong number of people loaded from database");

            int arrayPerson = 0;

            foreach (Person p in databasePeople)
            {
                Assertions.AssertPeopleAreEqual(people[arrayPerson++], p);
            }
        }

        [Test]
        public void can_save_person_list()
        {
            GenerateDatabaseSchema();

            ICollection<Person> personList = new List<Person>();

            personList.Add(new Person() { Id = 1, Forename = "Jimmy", Surname = "Choo", BirthdayDay = 1, BirthdayMonth = 1 });
            personList.Add(new Person() { Id = 2, Forename = "Sammy", Surname = "Davis", BirthdayDay = 31, BirthdayMonth = 12 });
            personList.Add(new Person() { Id = 3, Forename = "Patsy", Surname = "Kensit", BirthdayDay = 1, BirthdayMonth = 1 });

            IPersonRepository repository = new PersonRepository();
            repository.SaveList(personList);

            using (ISession session = _sessionFactory.OpenSession())
            {
                foreach (Person p in personList)
                {
                    Person databasePerson = session.Get<Person>(p.Id);
                    Assert.IsNotNull(databasePerson, "Person not loaded from database");
                    Assertions.AssertPeopleAreEqual(p, databasePerson);
                }
            }
        }

        private void GenerateDatabaseSchema()
        {
            Configuration config = new Configuration();
            config.Configure();
            config.AddAssembly(typeof(Person).Assembly);

            SchemaExport exporter = new SchemaExport(config);
            exporter.Execute(false, true, false);
        }

        private void AddPersonToDatabase(Person p)
        {
            using (ISession session = _sessionFactory.OpenSession())
            using( ITransaction transaction = session.BeginTransaction())
            {
                session.Save(p);
                transaction.Commit();
            }
        }
    }
}
