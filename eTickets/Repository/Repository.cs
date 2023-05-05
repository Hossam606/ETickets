using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using eTickets.Interfaces;
using eTickets.Data;

namespace eTickets.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbEticketsContext _context;
        public Repository(DbEticketsContext context)
        {
            _context = context;
        }
        public async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            
        }

        public async Task Delete(int id)
        {
             
            var result = await _context.Set<T>().FindAsync(id);
            //EntityEntry entityEntry = _context.Entry<T>(result);
            //entityEntry.State = EntityState.Deleted;
            _context.Set<T>().Remove(result);
            await _context.SaveChangesAsync();
        }
         
        public IEnumerable<T> GetAll(string[] includes=null)
        {
            IQueryable<T> query = _context.Set<T>();
            if (includes != null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }
            var result = query.ToList();
            return result;
        }
         

        public  async Task<T> GetById(int id)
        {
            var result = await _context.Set<T>().FindAsync(id);
            return result;
        }

        public async Task UpdateAsync(int id, T entity)
        {
            //EntityEntry entityEntry = _context.Entry<T>(entity);
            //entityEntry.State = EntityState.Modified;
            //var x= entity;
            _context.Update(entity);
            await _context.SaveChangesAsync();
            //return entity;
        }
    }
}
