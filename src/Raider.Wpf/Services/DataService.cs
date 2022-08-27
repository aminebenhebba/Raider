using Raider.Wpf.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace Raider.Wpf.Services
{
    public class DataService<T> : IDataService<T> where T : class
    {
        private readonly RaiderDbContext _context;

        public DataService(RaiderDbContext context)
        {
            _context = context;
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public void Add(T item)
        {
            _context.Set<T>().Add(item);
        }

        public void Delete(T item)
        {
            _context.Set<T>().Remove(item);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}