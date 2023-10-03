using AutoMapper;
using MyWebAPINet6.Data;
using MyWebAPINet6.Model;

namespace MyWebAPINet6.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper() 
        {
            CreateMap<Book, BookModel>().ReverseMap();
        }
    }
}
