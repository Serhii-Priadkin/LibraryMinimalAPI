using AutoMapper;
using Library.Models;
using Library.Models.DTO;

namespace Library
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Book,BookCreateDTO>().ReverseMap();
            CreateMap<Review,ReviewCreateDTO>().ReverseMap();
            CreateMap<Rating,RatingCreateDTO>().ReverseMap();
        }
    }
}
