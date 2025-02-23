using Microsoft.EntityFrameworkCore;
using Project.Models;
using System.Linq.Expressions;

namespace Project.Repository.Abstraction
{
    public interface IRepository<T> where T : Base, new()
    {
        DbSet<T> Table { get; }
        Task<ICollection<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);
        Task<T?> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes);
        Task CreateAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<T?> GetByIdForDetailsAsync(int id, params Func<IQueryable<T>, IQueryable<T>>[] includes);
        Task<int> SaveChangesAsync();
    }
}
