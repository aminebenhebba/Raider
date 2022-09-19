using Microsoft.EntityFrameworkCore;
using Raider.Wpf.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Raider.Wpf.Services
{
    public class DataService<T> : IDataService<T> where T : class
    {
        protected readonly RaiderDbContext _context;

        public DataService(RaiderDbContext context)
        {
            _context = context;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().AsEnumerable();
        }

        public void Add(T item)
        {
            _context.Set<T>().Add(item);
        }

        public void Delete(T item)
        {
            _context.Set<T>().Remove(item);
        }

        public void Delete(Expression<Func<T, bool>> predicate)
        {
            var itemsToDelete = _context.Set<T>().Where(predicate).AsEnumerable();

            _context.Set<T>().RemoveRange(itemsToDelete);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}