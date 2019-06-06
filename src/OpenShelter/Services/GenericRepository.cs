using System;
using System.IO;
using SQLite;
using System.Linq.Expressions;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

namespace OpenShelter.Services
{
    public abstract class GenericRepository<T> where T : new()
    {
        protected GenericRepository()
        {
            try
            {
                using (var connection = new SQLiteConnection(this.DbPath))
                {
                    connection.CreateTable<T>();
                }
            }
            catch (SQLiteException ex)
            {
                // Log.Info("SQLiteEx", ex.Message);
            }
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
            try
            {
                using (var connection = new SQLiteConnection(this.DbPath))
                {
                    return connection.Table<T>().FirstOrDefault(expression);
                }
            }
            catch (SQLiteException ex)
            {
                // Log.Info("SQLiteEx", ex.Message);
                return default;
            }
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> expression)
        {
            try
            {
                using (var connection = new SQLiteConnection(this.DbPath))
                {
                    return connection.Table<T>().Where(expression);
                }
            }
            catch (SQLiteException ex)
            {
                // Log.Info("SQLiteEx", ex.Message);
                return null;
            }
        }

        public string DbPath { get { return Path.Combine(Environment.CurrentDirectory, "Db", "attendances.db"); } }
    }
}
