
using Microsoft.EntityFrameworkCore;
using RM.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RM.Repo.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;
        private DbSet<T> entities { get; set; }

        public Repository(DbContext context)
        {
            _context = context;
            entities = _context.Set<T>();
        }


        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public void Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity Null!");
            }

            entities.Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity Null!");
            }

            entities.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity Null!");
            }

            entities.Remove(entity);
            _context.SaveChanges();
        }

    }
}
