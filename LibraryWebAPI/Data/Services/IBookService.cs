using System;
using System.Linq.Expressions;
using LibraryWebAPI.Data.Models;
using LibraryWebAPI.Data.ModelsDTO;

namespace LibraryWebAPI.Data.Services
{
	public interface IBookService
	{
		Task<IEnumerable<BookDTO>> GetAsync(Expression<Func<Book, bool>> expression = null);
		Task<IEnumerable<BookReviewDetailsDTO>> GetWithReviewsAsync(Expression<Func<Book, bool>> expression = null);
        Task<BookReviewDetailsDTO?> GetByIdAsync(int id);
		Task<int> CreateAsync(CreateBookDTO bookDTO);
		Task<bool> UpdateAsync(UpdateBookDTO bookDTO);
		Task<bool> DeleteAsync(int id);
		Task<bool> ReviewBookAsync(CreateReviewDTO reviewDTO);
		Task<bool> RateBookAsync(CreateRatingDTO ratingDTO);
	}
}

