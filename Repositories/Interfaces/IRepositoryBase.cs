using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IRepositoryBase<T>
    {
        void Add(T item);

        IEnumerable<T> GetAll();

        T Find(Guid key);

        Task<bool> Remove(T key);

        Task<bool> Remove(Guid Id);

        //void Update(T item);
    }
}