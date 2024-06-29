using System.Linq.Expressions;

namespace Hospital.Repositories.Interfaces
{
    public interface IGenericRepository1<T>
    {
        void Add(T entity);
        Task<T> AddAsync(T entity);
        Task Delete(T entity);
        Task DeleteAsync(T entity);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperty = "");
        T GetById(object id);
        Task<T> GetByIdAsync(object id);
        Task<T> Update(T entity);
        Task<T> UpdateAsync(T entity);
    }
}