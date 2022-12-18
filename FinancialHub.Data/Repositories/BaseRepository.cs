using FinancialHub.Data.Contexts;
using FinancialHub.Domain.Entities;
using FinancialHub.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialHub.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly FinancialHubContext _context;

        public BaseRepository(FinancialHubContext context)
        {
            _context = context;
        }

        public virtual async Task<T> CreateAsync(T obj)
        {
            obj.Id = null;
            obj.CreationTime = DateTimeOffset.Now;
            obj.UpdateTime = DateTimeOffset.Now;

            var res = await _context.Set<T>().AddAsync(obj);
            await _context.SaveChangesAsync();
            return res.Entity;
        }

        public virtual async Task<int> DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                return await _context.SaveChangesAsync();
            }
            else
                return 0;

        }

        public virtual async Task<ICollection<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<ICollection<T>> GetAsync(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate).ToList();
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public virtual async Task<T> UpdateAsync(T obj)
        {
            obj.UpdateTime = DateTimeOffset.Now;

            var res = _context.Set<T>().Update(obj);
            _context.Entry(res.Entity).Property(x => x.CreationTime).IsModified = false;

            await _context.SaveChangesAsync();

            return res.Entity;
        }
    }
}
