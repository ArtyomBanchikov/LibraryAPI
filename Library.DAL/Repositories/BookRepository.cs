using Library.DAL.EF;
using Library.DAL.Entities;
using Library.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.DAL.Repositories
{
    public class BookRepository : GenericRepository<BookEntity>, IBookRepository
    {
        public BookRepository(LibraryContext context) : base(context) { }
        public Task<BookEntity> GetByISBNAsync(long isbn, CancellationToken token)
        {
            return dbSet.FirstAsync(b => b.ISBN == isbn, token);
        }
    }
}
