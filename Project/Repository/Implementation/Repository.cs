using Microsoft.EntityFrameworkCore;
using Project.Contexts;
using Project.Models;
using Project.Repository.Abstraction;
using System.Linq.Expressions;

namespace Project.Repository.Implementation
{
    public class Repository<T> : IRepository<T> where T : Base, new()
    {
        readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<ICollection<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = Table;

            if (includes.Length > 0)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return await query.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = Table;

            if (includes.Length > 0)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return await query.SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task CreateAsync(T entity)
        {
            await Table.AddAsync(entity);
        }

        public void Update(T entity)
        {
            Table.Update(entity);
        }

        public void Delete(T entity)
        {
            Table.Remove(entity);
        }
        public async Task<T?> GetByIdForDetailsAsync(int id, params Func<IQueryable<T>, IQueryable<T>>[] includes)
        {
            IQueryable<T> query = Table;

            if (includes.Length > 0)
            {
                foreach (var include in includes)
                {
                    query = include(query); 
                }
            }

            return await query.SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
