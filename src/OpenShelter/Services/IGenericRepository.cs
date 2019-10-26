using System;
using System.Collections.Generic;

namespace OpenShelter.Services
{
    public interface IGenericRepository<T> where T : new()
    {
        int Add(T entity);
        int Update(T entity);
        T Get(Func<T, bool> expression);
        List<T> GetAll(Func<T, bool> expression);
    }
}