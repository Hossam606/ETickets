using eTickets.Models;

namespace eTickets.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public IEnumerable<T> GetAll(string[] includes=null);
        public Task<T> GetById(int id);
        public Task Add(T entity);
        public Task UpdateAsync(int id,T entity);
        public Task Delete(int id);
    }
}
