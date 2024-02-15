using AutoMapper;
using Library.BLL.Interfaces;
using Library.BLL.Models;
using Library.DAL.Entities;
using Library.DAL.Interfaces;

namespace Library.BLL.Services
{
    public class BookService : GenericService<BookModel, BookEntity>, IBookService
    {
        protected new readonly IBookRepository _repository;
        public BookService(IBookRepository bookRepository, IMapper mapper) : base(bookRepository, mapper)
        {
            _repository = bookRepository;
        }
        public async Task<BookModel> GetByISBNAsync(long isbn, CancellationToken token)
        {
            var book = _mapper.Map<BookModel>(await _repository.GetByISBNAsync(isbn, token));

            return book;
        }
    }
}
