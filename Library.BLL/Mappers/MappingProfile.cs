using AutoMapper;
using Library.BLL.Models;
using Library.DAL.Entities;

namespace Library.BLL.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookEntity, BookModel>();
            CreateMap<BookModel, BookEntity>();
        }
    }
}
