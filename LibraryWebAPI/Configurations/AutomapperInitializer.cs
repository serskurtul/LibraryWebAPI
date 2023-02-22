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
				.ForMember(x=>x.ReviewsNumber, opt=>opt.MapFrom(x=>x.Reviews.Count()))
				.ForMember(x=>x.Rating, opt=>opt.MapFrom(x=>x.Rating.Score));
            CreateMap<Review, ReviewDTO>().ReverseMap();
			CreateMap<Book, BookReviewDetailsDTO>()
				.ForMember(x => x.Rating, opt => opt.MapFrom(x => x.Rating.Score));
			CreateMap<UpdateBookDTO, Book>();
			CreateMap<CreateReviewDTO, Review>();
			CreateMap<CreateRatingDTO, Rating>();
        }
    }
}

