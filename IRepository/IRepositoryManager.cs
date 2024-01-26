
using System.Linq.Expressions;

namespace ChatApp.IRepository
{
    public interface IRepositoryManager<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> GetByIdExpression(Expression<Func<T, bool>> expression, bool trackChanges);
        Task Create(T entity);
        void Delete(T entity);
        Task Save();
    }
}