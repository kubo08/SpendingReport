using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repositories.Interfaces;
using SpendingReportEntity4;

namespace Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : EntityBase
    {
        private SpendingReportEntities _context;

        public RepositoryBase(SpendingReportEntities context)
        {
            _context = context;
        }

        public async void Add(T item)
        {
            _context.Set<T>().Add(item);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll()
        {
            var items = _context.Set<T>();
            return items.ToList();
        }

        public T Find(Guid key)
        {
            var item = _context.Set<T>().FirstOrDefault(a=>a.Id == key);
            return item;
        }

        public async Task<bool> Remove(T item)
        {
            return await Remove(item.Id);
        }

        public async Task<bool> Remove(Guid Id)
        {
            var dbItem = _context.Set<T>().FirstOrDefault(a => a.Id == Id);
            if (dbItem == null)
            {
                //throw new Exception("Entity not found");
                return false;
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        //public void Update(T item)
        //{
        //    _context.Set<T>().
        //}
    }
}