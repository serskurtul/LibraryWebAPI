using System;
using AutoMapper;
using LibraryWebAPI.Data.Models;
using LibraryWebAPI.Data.ModelsDTO;

namespace LibraryWebAPI.Configurations
{
    public class AutomapperInitilizer : Profile
    {
        public AutomapperInitilizer()
        {
            CreateMap<Book, BookDTO>()
                .ForMember(x => x.ReviewsNumber, opt => opt.MapFrom(x => x.Reviews != null ? x.Reviews.Count : 0))
                .ForMember(x => x.Rating, opt => opt.MapFrom(x => x.Ratings != null && x.Ratings.Count != 0 ? x.Ratings.Average(x => x.Score) : 0m));
            CreateMap<Review, ReviewDTO>().ReverseMap();
            CreateMap<Book, BookReviewDetailsDTO>()
                .ForMember(x => x.Rating, opt => opt.MapFrom(x => x.Ratings != null && x.Ratings.Count != 0 ? x.Ratings.Average(x => x.Score) : 0m));
            CreateMap<UpdateBookDTO, Book>();
            CreateMap<CreateReviewDTO, Review>();
            CreateMap<CreateRatingDTO, Rating>();
        }
    }
}

