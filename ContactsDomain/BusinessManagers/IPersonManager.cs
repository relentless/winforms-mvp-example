using System.Collections.Generic;
using ContactsDomain.DomainObjects;

namespace ContactsDomain.BusinessManagers
{
    public interface IPersonManager
    {
        ICollection<Person> GetAllPeople();

        void AddPerson(Person person);

        void DeletePerson(Person person);

        void UpdatePerson(Person person);
    }
}
