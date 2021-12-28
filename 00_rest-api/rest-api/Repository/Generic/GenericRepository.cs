using Microsoft.EntityFrameworkCore;
using rest_api.Model.Base;
using rest_api.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace rest_api.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private MySQLContext _context;
        private DbSet<T> _dataset;

        public GenericRepository(MySQLContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }

        public T Create(T item)
        {
            try
            {
                _dataset.Add(item);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            return item;
        }

        public void Delete(long id)
        {
            try
            {
                var result = _dataset.SingleOrDefault(i => i.Id.Equals(id));

                if (result == null) throw new Exception("doesn't exists");

                _dataset.Remove(result);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<T> FindAll()
        {
            try
            {
                return _dataset.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public T FindById(long id)
        {
            try
            {
                return _dataset.SingleOrDefault(i => i.Id.Equals(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public T Update(T item)
        {
            try
            {
                var result = _dataset.SingleOrDefault(i => i.Id.Equals(item.Id));

                if (result == null) throw new Exception("doesn't exists");

                _context.Entry(result).CurrentValues.SetValues(item);
                _context.SaveChanges();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
