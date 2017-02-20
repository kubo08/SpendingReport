using System;
using System.Collections;
using System.Collections.Generic;

namespace WebApiService.Models.Repositories
{
    public interface IRepositoryBase<T>
    {
        void Add(T item);

        IEnumerable<T> GetAll();

        T Find(Guid key);

        void Remove(T key);

        void Update(T item);
    }
}