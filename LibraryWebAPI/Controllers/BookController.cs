using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LibraryWebAPI.Data;
using LibraryWebAPI.Data.Models;
using LibraryWebAPI.Data.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryWebAPI.Controllers
{
    [ApiController]
    [Route("/api/")]
    public class BooksController : ControllerBase
    {
        private readonly BookDbContext _context;
        private readonly IMapper _mapper;

        public BooksController(BookDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet("books")]
        public async Task<IActionResult> GetAll([FromQuery] string order)
        {
            var books = await _context.Books.ToListAsync();
            var results = _mapper.Map<List<BookDTO>>(books);
            if (order.ToLower() == "author")
                results = results.OrderBy(x => x.Author).ToList();
            else if (order.ToLower() == "genre")
                results = results.OrderBy(x => x.Genre).ToList();
            else
                return BadRequest();
            return Ok(results);
        }
        [HttpGet("recommended")]
        public IActionResult GetRecomended([FromQuery] string? genre)
        {
            var books = _context.Books.Include(x => x.Rating).Include(x => x.Reviews).Where(x => x.Reviews.Count > 10 && (genre == null || genre.ToLower() == x.Genre.ToLower())).OrderByDescending(x => x.Rating.Score).Take(10);

            var results = _mapper.Map<List<BookDTO>>(books);
            
            return Ok(results);
        }

        [HttpGet("books/{id:int}")]
        public async Task<IActionResult> GetByIdWithReviwes([FromRoute] int id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
            if (book == null)
                return NotFound($"Book with id = {id} not found");

            _context.Entry<Book>(book).Collection(x => x.Reviews).Load();

            var result = _mapper.Map<BookReviewDetailsDTO>(book);

            return Ok(result);
        }
        [HttpDelete("books/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id, [FromQuery] string secretKey)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            if (secretKey != configuration.GetValue<string>("SecretKey"))
                return StatusCode(401);

            var bookToDelete = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);

            if (bookToDelete == null)
                return NotFound($"Book with id = {id} not found");

            _context.Books.Remove(bookToDelete);

            var result = await _context.SaveChangesAsync();
            if (result >= 1)
                return Ok("\"message\": \"success\"");
            else
                return StatusCode(500);
        }
    }
}

