using Abstractions;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorys
{
    public class WriteRepo<T> : IWriteRepo<T> where T : BaseModel
    {
        private List<T> _dbSet = [];

        public WriteRepo(DbContext context)
        {
            _dbSet = GetDbSet(context);
        }

        private static List<T> GetDbSet(DbContext context)
        {
            var property = context.GetType()
                                  .GetProperties()
                                  .FirstOrDefault(p => p.PropertyType == typeof(List<T>));

            if (property == null)
            {
                throw new InvalidOperationException($"No DbSet found for type {typeof(T).Name}");
            }

            var dbSet = property.GetValue(context) as List<T>;

            return dbSet ?? new List<T>();
        }

        public void Create(T model)
        {
            _dbSet.Add(model);
        }

        public void Delete(int id)
        {
            T? item = _dbSet.FirstOrDefault(x => x.Id == id);
            _dbSet.Remove(item);
        }

        public void Update(int id, T model)
        {
            T? item = _dbSet.FirstOrDefault(x => x.Id == id);

            item = model;
        }
    }
}
