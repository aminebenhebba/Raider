using Raider.Domain.Entities;
using System.Collections.Generic;

namespace Raider.Wpf.Services
{
    public interface IClassDataService
    {
        List<Class> GetAll();
        void Add(Class newClass);
        void Delete(Class selectedClass);
        void SaveChanges();
    }
}