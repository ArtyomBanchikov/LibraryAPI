using AutoMapper;
using Library.API.ViewModels;
using Library.BLL.Interfaces;
using Library.BLL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class BookController : GenericController<BookModel, BookViewModel>
    {
        protected new readonly IBookService _service;
        public BookController(IBookService bookService, IMapper mapper) : base(bookService, mapper)
        {
            _service = bookService;
        }

        [HttpGet("ISBN")]
        public async Task<BookViewModel> GetByIsbn([FromQuery(Name = "ISBN")] int isbn, CancellationToken cancellationToken)
        {
            var book = await _service.GetByISBNAsync(isbn, cancellationToken);

            return _mapper.Map<BookViewModel>(book);
        }
    }
}
