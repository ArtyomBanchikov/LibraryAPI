using Library.BLL.Models;

namespace Library.BLL.Interfaces
{
    public interface IBookService : IGenericService<BookModel>
    {
        Task<BookModel> GetByISBNAsync(int isbn, CancellationToken token);
    }
}
