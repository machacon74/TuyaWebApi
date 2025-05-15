using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IRepository<T> where T : class, IEntity 
    {
        public Task<IEnumerable<T>> GetAll();
        public Task<T?> GetById(int Id);
        public Task<T?> Add(T entity);
        public Task<T?> Update(T entity);
        public Task<int> Delete(T entity);
        public Task<bool> Exists(int? Id);
    }
}
