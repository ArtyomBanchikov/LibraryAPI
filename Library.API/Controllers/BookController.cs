using AutoMapper;
using FluentValidation;
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
        public BookController(IBookService bookService, IMapper mapper, IValidator<BookViewModel> validator) : base(bookService, mapper, validator)
        {
            _service = bookService;
        }

        [HttpGet("ISBN")]
        public async Task<BookViewModel> GetByIsbn([FromQuery(Name = "ISBN")] long isbn, CancellationToken cancellationToken)
        {
            var book = await _service.GetByISBNAsync(isbn, cancellationToken);

            return _mapper.Map<BookViewModel>(book);
        }
    }
}
