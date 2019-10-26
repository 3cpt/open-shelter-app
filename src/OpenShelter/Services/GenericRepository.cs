using System;
using System.IO;
using SQLite;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Linq;

namespace OpenShelter.Services
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : new()
    {
        private readonly SQLiteConnection connection;

        protected GenericRepository()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            path = Path.Combine(path, "attendances.db");

            connection = new SQLiteConnection(path);
            connection.CreateTable<T>();
        }

        public T Get(Func<T, bool> expression)
        {
            try
            {
                return connection.Table<T>().FirstOrDefault(expression);
            }
            catch
            {
                return default;
            }
        }

        public List<T> GetAll(Func<T, bool> expression)
        {
            try
            {
                return connection.Table<T>().Where(expression).ToList();
            }
            catch
            {
                return default;
            }
        }

        public int Add(T entity)
        {
            try
            {
                return connection.Insert(entity);
            }
            catch
            {
                return default;
            }
        }

        public int Update(T entity)
        {
            try
            {
                return connection.Update(entity);
            }
            catch
            {
                return default;
            }
        }
    }
}
