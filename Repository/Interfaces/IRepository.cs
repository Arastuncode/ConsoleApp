using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    public interface IRepository<T> where T: BaseEntity
    {
        public bool Create(T entity);
        public bool Update(T entity);
        public bool Delete(T entity);
        T Get(Predicate<T> filter);
        List<T> GetAll(Predicate<T> filter);
    }
}
