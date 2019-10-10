using AutoMapper;
using BookService.Lib.DTO;
using BookService.Lib.Models;
using System.Linq;

namespace BookService.WebAPI.Services
{

    public class AutoMapperProfileConfiguration: Profile
    {
        public AutoMapperProfileConfiguration():this("MyProfile")
        {

        }

        public AutoMapperProfileConfiguration(string profileName) : base(profileName)
        {
            CreateMap<PublisherBasic, Publisher>().ReverseMap();
            CreateMap<BookBasic, Book>().ReverseMap();
            CreateMap<Book, BookDetail>()
                .ForMember(
                    dest => dest.AuthorName,
                    opts => opts.MapFrom(
                        src => $"{src.Author.LastName} {src.Author.FirstName}"))
                .ReverseMap();
            CreateMap<Book, BookStatistic>()
                .ForMember(
                    dest => dest.ScoreAverage,
                    opts => opts.MapFrom(src => src.Ratings.Average(r => r.Score))
                    )
                .ReverseMap();
        }


    }
}
