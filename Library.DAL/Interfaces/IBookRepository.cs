using Library.DAL.Entities;

namespace Library.DAL.Interfaces
{
    public interface IBookRepository : IGenericRepository<BookEntity>
    {
        Task<BookEntity> GetByISBNAsync(long isbn, CancellationToken token);
    }
}
