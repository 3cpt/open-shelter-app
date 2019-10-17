using System;
using System.IO;
using SQLite;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace OpenShelter.Services
{
    public abstract class GenericRepository<T> where T : new()
    {
        private readonly SQLiteConnection connection;

        protected GenericRepository()
        {
            connection = new SQLiteConnection(this.DbPath);
            connection.CreateTable<T>();
        }

        public T Get(Expression<Func<T, bool>> expression)
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

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> expression)
        {
            try
            {
                return connection.Table<T>().Where(expression);
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

        public string DbPath { get { return Path.Combine(Environment.CurrentDirectory, "Db", "attendances.db"); } }
    }
}
