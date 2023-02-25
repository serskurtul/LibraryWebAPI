using System;
using LibraryWebAPI.Data.ModelsDTO;
using LibraryWebAPI.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebAPI.Controllers
{
    [ApiController]
    [Route("/api/")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet("books")]
        public async Task<IActionResult> GetAll([FromQuery] string order)
        {
            try
            {
                var books = await _bookService.GetAsync();

                if (order.ToLower() == "author")
                    books = books.OrderBy(x => x.Author).ToList();
                else if (order.ToLower() == "title")
                    books = books.OrderBy(x => x.Title).ToList();
                else
                    return BadRequest();
                return Ok(books);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("recommended")]
        public async Task<IActionResult> GetRecommended([FromQuery] string? genre)
        {
            try
            {
                var allBooks = await _bookService.GetAsync(x => x.Reviews.Count > 10 && (genre == null || genre.ToLower() == x.Genre.ToLower()));

                var recommended = allBooks.OrderByDescending(x => x.Rating).Take(10);

                return Ok(recommended);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("books/{id:int}")]
        public async Task<IActionResult> GetByIdWithReviwes([FromRoute] int id)
        {
            try
            {
                var book = await _bookService.GetByIdAsync(id);
                if (book == null)
                    return NotFound($"Book with id = {id} not found");

                return Ok(book);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("books/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id, [FromQuery] string secretKey)
        {
            try
            {
                var configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build();
                if (secretKey != configuration.GetValue<string>("SecretKey"))
                    return StatusCode(403);

                var result = await _bookService.DeleteAsync(id);

                if (result)
                    return Ok("\"message\": \"success\"");
                else
                    return StatusCode(500);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("books/save")]
        public async Task<IActionResult> Post([FromBody] UpdateBookDTO bookDTO)
        {
            try
            {
                var id = bookDTO.Id;
                if (id == default(int))
                {
                    id = await _bookService.CreateAsync(bookDTO);
                    return StatusCode(201,$"\"id\": \"{id}\"");
                }
                else
                {
                    await _bookService.UpdateAsync(bookDTO);
                    return StatusCode(202, $"\"id\": \"{id}\"");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut("books/{id:int}/review")]
        public async Task<IActionResult> SaveReview([FromRoute] int id, [FromBody] CreateReviewDTO reviewDTO)
        {
            try
            {
                reviewDTO.BookId = id;
                var result = await _bookService.ReviewBookAsync(reviewDTO);
                if (result)
                    return StatusCode(202,"\"message\": \"success\"");
                else
                    return StatusCode(500);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut("books/{id:int}/rate")]
        public async Task<IActionResult> SaveRate([FromRoute] int id, [FromBody] CreateRatingDTO ratingDTO)
        {
            try
            {
                ratingDTO.BookId = id;

                var result = await _bookService.RateBookAsync(ratingDTO);
                if (result)
                    return StatusCode(202, "\"message\": \"success\"");
                else
                    return StatusCode(500);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

