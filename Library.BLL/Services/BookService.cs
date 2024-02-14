using AutoMapper;
using Library.BLL.Interfaces;
using Library.BLL.Models;
using Library.DAL.Entities;
using Library.DAL.Interfaces;

namespace Library.BLL.Services
{
    public class BookService : GenericService<BookModel, BookEntity>, IBookService
    {
        protected new readonly IBookRepository repository;
        public BookService(IBookRepository bookRepository, IMapper mapper) : base(bookRepository, mapper)
        {
            repository = bookRepository;
        }
        public async Task<BookModel> GetByISBNAsync(int isbn, CancellationToken token)
        {
            var book = mapper.Map<BookModel>(await repository.GetByISBNAsync(isbn, token));

            return book;
        }
    }
}
