using System.Collections.Generic;

namespace ContactsDomain.RepositoryInterfaces
{
    public interface IRepository<T>
    {
        void Add(T Entity);
        void Update(T Entity);
        void Remove(T Entity);
        T GetById(int Id);
        ICollection<T> GetAll();
        void SaveList(ICollection<T> EntityList);
    }
}
