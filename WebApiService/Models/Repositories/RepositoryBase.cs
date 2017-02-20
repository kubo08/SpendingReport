using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiService.Models.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T>
    {
        //private SpendingReportEntities
        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T Find(Guid key)
        {
            throw new NotImplementedException();
        }

        public void Remove(T key)
        {
            throw new NotImplementedException();
        }

        public void Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}
