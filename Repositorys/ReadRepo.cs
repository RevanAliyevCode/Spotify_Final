﻿using Abstractions;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorys
{
    public class ReadRepo<T> : IReadRepo<T> where T : BaseModel
    {
        private List<T> _dbSet = [];

        public ReadRepo(DbContext context)
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

        public List<T> GetAll()
        {
            return _dbSet;
        }

        public T? GetById(int id)
        {
            T finded = _dbSet.FirstOrDefault(x => x.Id == id);

            return finded;
        }
    }
}
