using ContactsDomain.RepositoryInterfaces;
using ContactsDomain.DomainObjects;
using System.Collections.Generic;

namespace ContactsDomain.BusinessManagers
{
    public sealed class PersonManager : IPersonManager
    {
        private readonly IPersonRepository _personRepository;

        public PersonManager(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public ICollection<Person> GetAllPeople()
        {
            return _personRepository.GetAll();
        }

        public void AddPerson(Person person)
        {
            _personRepository.Add(person);
        }

        public void UpdatePerson(Person person)
        {
            _personRepository.Update(person);
        }

        public void DeletePerson(Person person)
        {
            _personRepository.Remove(person);
        }
    }
}
