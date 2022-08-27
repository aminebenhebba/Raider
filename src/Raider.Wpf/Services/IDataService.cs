using System.Collections.Generic;

namespace Raider.Wpf.Services
{
    public interface IDataService<T> where T : class
    {
        List<T> GetAll();
        void Add(T item);
        void Delete(T item);
        void SaveChanges();
    }
}