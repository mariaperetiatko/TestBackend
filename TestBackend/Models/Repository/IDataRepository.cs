using System;
using System.Collections.Generic;

namespace TestBackend.Models.Repository
{
    public interface IDataRepository<T> : IDisposable
        where T : class
    {
        IEnumerable<T> GetEntitySet();
        T GetEntity(object key);
        void Create(T item);
        void Update(T item);
        void Delete(T item);
        void Save();
        IEnumerable<T> SearchByField(object field);
    }
}
