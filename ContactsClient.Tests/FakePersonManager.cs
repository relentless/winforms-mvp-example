using ContactsDomain.DomainObjects;
using System.Collections.Generic;
using ContactsDomain.BusinessManagers;

namespace ContactsClient.Tests
{
    internal class FakePersonManager : IPersonManager
    {
        internal List<Person> PersonList { get; set; }
        internal Person AddedPerson { get; set; }
        internal Person DeletedPerson { get; set; }
        internal Person UpdatedPerson { get; set; }

        #region IPersonManager Members

        public ICollection<Person> GetAllPeople()
        {
            return PersonList;
        }

        public void AddPerson(Person person)
        {
            this.AddedPerson = person;
        }

        public void DeletePerson(Person person)
        {
            this.DeletedPerson = person;
        }

        public void UpdatePerson(Person person)
        {
            UpdatedPerson = person;
        }

        #endregion
    }
}
