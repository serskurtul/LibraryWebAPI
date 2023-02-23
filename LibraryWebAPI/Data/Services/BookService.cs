using System;
using System.Linq.Expressions;
using AutoMapper;
using LibraryWebAPI.Data.Models;
using LibraryWebAPI.Data.ModelsDTO;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebAPI.Data.Services
{
	public class BookService : IBookService
	{
        private readonly BookDbContext _context;
        private readonly IMapper _mapper;

        public BookService(BookDbContext context, IMapper mapper)
		{
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookDTO>> GetAsync(Expression<Func<Book, bool>> expression = null)
        {
            IQueryable<Book> query = _context.Books.Include(x=>x.Ratings).Include(x=>x.Reviews);
            if(expression != null)
            {
                query = query.Where(expression);
            }
            var booksDb = await query.ToListAsync();
            return _mapper.Map<IEnumerable<BookDTO>>(booksDb);
        }

        public async Task<IEnumerable<BookReviewDetailsDTO>> GetWithReviewsAsync(Expression<Func<Book, bool>> expression = null)
        {
            IQueryable<Book> query = _context.Books.Include(x=>x.Reviews).Include(x => x.Ratings);
            if (expression != null)
            {
                query = query.Where(expression);
            }
            var booksDb = await query.ToListAsync();
            return _mapper.Map<IEnumerable<BookReviewDetailsDTO>>(booksDb);
        }

        public async Task<BookReviewDetailsDTO?> GetByIdAsync(int id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
            if (book == null)
                return null;
            await _context.Entry<Book>(book).Collection(x => x.Reviews).LoadAsync();
            await _context.Entry<Book>(book).Collection(x => x.Ratings).LoadAsync();

            return _mapper.Map<BookReviewDetailsDTO>(book);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookDTO"></param>
        /// <returns>id (0 - if not added)</returns>
        public async Task<int> CreateAsync(CreateBookDTO bookDTO)
        {
            var bookDb = _mapper.Map<Book>(bookDTO);
            var result = (await _context.Books.AddAsync(bookDb)).Property<int>(x => x.Id).CurrentValue;
            if( await _context.SaveChangesAsync() >= 1)
                return result;
            
            return 0;
        }

        public async Task<bool> UpdateAsync(UpdateBookDTO bookDTO)
        {
            var bookDb = _mapper.Map<Book>(bookDTO);
            _context.Books.Update(bookDb);
            var result = await _context.SaveChangesAsync();
            return result >= 1;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var bookToDelete = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);

            if (bookToDelete == null)
                return false;

            _context.Books.Remove(bookToDelete);

            var result = await _context.SaveChangesAsync();
            return result >= 1;
        }

        public async Task<bool> RateBookAsync(CreateRatingDTO ratingDTO)
        {
            var ratingDb = _mapper.Map<Rating>(ratingDTO);

            await _context.Raitings.AddAsync(ratingDb);

            var result = await _context.SaveChangesAsync();
            return result >= 1;

        }

        public async Task<bool> ReviewBookAsync(CreateReviewDTO reviewDTO)
        {
            var reviewDb = _mapper.Map<Review>(reviewDTO);

            await _context.Reviews.AddAsync(reviewDb);

            var result = await _context.SaveChangesAsync();
            return result >= 1;
        }
    }
}

