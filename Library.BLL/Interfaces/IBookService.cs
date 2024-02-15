using Library.BLL.Models;

namespace Library.BLL.Interfaces
{
    public interface IBookService : IGenericService<BookModel>
    {
        Task<BookModel> GetByISBNAsync(long isbn, CancellationToken token);
    }
}
