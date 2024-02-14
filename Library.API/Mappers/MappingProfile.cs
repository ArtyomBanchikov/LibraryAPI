using AutoMapper;
using Library.API.ViewModels;
using Library.BLL.Models;

namespace Library.API.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookViewModel, BookModel>();
            CreateMap<BookModel, BookViewModel>();
        }
    }
}
