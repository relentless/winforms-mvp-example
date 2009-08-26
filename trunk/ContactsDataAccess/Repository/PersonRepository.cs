using ContactsDomain.RepositoryInterfaces;
using ContactsDomain.DomainObjects;
using NHibernate;
using System.Collections.Generic;
using System;

namespace ContactsDataAccess.Repository
{
    public sealed class PersonRepository:IPersonRepository
    {
        public void Add(Person person)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(person);
                transaction.Commit();
            }
        }

        public void Update(Person person)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Update(person);
                transaction.Commit();
            }
        }

        public void Remove(Person person)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Delete(person);
                transaction.Commit();
            }
        }

        public Person GetById(int Id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.Get<Person>(Id);
            }
        }

        public ICollection<Person> GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var result = session
                    .CreateCriteria(typeof(Person))
                    .List<Person>();

                return result;
            }
        }

        public void SaveList(ICollection<Person> PersonList)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                foreach (Person p in PersonList)
                {
                    session.Save(p);
                }

                transaction.Commit();
            }
        }
    }
}
