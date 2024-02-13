using Library.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.DAL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext context;

        protected readonly DbSet<TEntity> dbSet;
        public GenericRepository(DbContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }
        public async Task<TEntity> CreateAsync(TEntity entity, CancellationToken token)
        {
            await dbSet.AddAsync(entity, token);

            await context.SaveChangesAsync(token);

            return entity;
        }

        public async Task DeleteAsync(TEntity entity, CancellationToken token)
        {
            dbSet.Remove(entity);

            await context.SaveChangesAsync(token);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken token)
        {
            return await dbSet.ToListAsync(token);
        }

        public async Task<TEntity?> GetByIdAsync(int id, CancellationToken token)
        {
            return await dbSet.FindAsync(new object[] { id }, token);
        }

        public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken token)
        {
            dbSet.Update(entity);

            await context.SaveChangesAsync(token);

            return entity;
        }
    }
}
