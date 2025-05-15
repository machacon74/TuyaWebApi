using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repository;
using Infrastructure.DB;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class, IEntity
    {
        protected readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetById(int id)
        {
            return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<T?> Add(T entity)
        {
            var entry = await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task<T?> Update(T entity)
        {
            var entry = _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task<bool> Exists(int? id)
        {
            return await _context.Set<T>().AsNoTracking().AnyAsync(x => x.Id == id);
        }
    }
}
