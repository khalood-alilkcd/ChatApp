
using System.Linq.Expressions;
using ChatApp.Data;
using ChatApp.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Repository
{
    public class RepositoryManager<T> : IRepositoryManager<T> where T : class
    {
        private readonly AppDbContext _context;
        public RepositoryManager(AppDbContext context)
        {
            _context = context;

        }
        public async Task Create(T entity) => await _context.Set<T>().AddAsync(entity);


        public async Task<IEnumerable<T>> GetAll()
        => await _context.Set<T>().ToListAsync();

        public async Task<T> GetById(int id)
        => await _context.Set<T>().FindAsync(id);
        public async Task<T> GetByIdExpression(Expression<Func<T, bool>> expression, bool trackChanges)
            => !trackChanges ? await _context.Set<T>().Where(expression).AsNoTracking().SingleOrDefaultAsync()
             : await _context.Set<T>().Where(expression).SingleOrDefaultAsync();

        public void Delete(T entity) => _context.Set<T>().Remove(entity);
        public async Task Save() => await _context.SaveChangesAsync();
    }
}