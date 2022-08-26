using Raider.Domain.Entities;
using Raider.Wpf.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace Raider.Wpf.Services
{
    public class ClassDataService : IClassDataService
    {
        private readonly RaiderDbContext _context;

        public ClassDataService(RaiderDbContext context)
        {
            _context = context;
        }

        public List<Class> GetAll()
        {
            var result = _context.Classes.ToList();
            return result;
        }

        public void Add(Class newClass)
        {
            _context.Classes.Add(newClass);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
