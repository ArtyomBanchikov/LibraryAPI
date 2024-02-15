using FluentValidation;
using Library.API.ViewModels;

namespace Library.API.Validators
{
    public class BookValidator: AbstractValidator<BookViewModel>
    {
        public BookValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.ISBN).NotEmpty();
            RuleFor(x => x.Genre).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Author).NotEmpty();
            RuleFor(x => x.ISBN.ToString().Length).Equal(13).WithMessage("ISBN code must be 13 digits long");
        }
    }
}
