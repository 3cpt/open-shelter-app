using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace OpenShelter.Services
{
    public interface IGenericRepository<T> where T : new()
    {
        int Add(T entity);
        T Get(Expression<Func<T, bool>> expression);
        List<T> GetAll(Expression<Func<T, bool>> expression);
    }
}