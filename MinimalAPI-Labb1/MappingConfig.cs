using AutoMapper;
using MinimalAPI_Labb1.Models;
using MinimalAPI_Labb1.Models.DTOs;

namespace MinimalAPI_Labb1
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Books, BooksCreateDTO>().ReverseMap();
            CreateMap<Books, BooksDTO>().ReverseMap();
            CreateMap<Books, BooksUpdateDTO>().ReverseMap();
        }
    }
}
