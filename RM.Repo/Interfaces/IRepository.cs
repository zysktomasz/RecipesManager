using System;
using System.Collections.Generic;
using System.Text;

namespace RM.Repo.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
