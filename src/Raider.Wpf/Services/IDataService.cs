using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Raider.Wpf.Services
{
    public interface IDataService<T> where T : class
    {
        IEnumerable<T> GetAll();
        void Add(T item);
        void Delete(T item);
        void Delete(Expression<Func<T, bool>> predicate);
        void SaveChanges();
    }
}