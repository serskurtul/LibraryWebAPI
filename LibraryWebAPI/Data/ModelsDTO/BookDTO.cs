using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryWebAPI.Data.ModelsDTO
{
    public class CreateBookDTO
    {
        [StringLength(maximumLength: 100)]
        public string Title { get; set; } = string.Empty;
        [StringLength(maximumLength: 1200)]
        public string Cover { get; set; } = string.Empty;
        [StringLength(maximumLength: 3000)]
        public string Content { get; set; } = string.Empty;
        [StringLength(maximumLength: 100)]
        public string Author { get; set; } = string.Empty;
        [StringLength(maximumLength: 100)]
        public string Genre { get; set; } = string.Empty;

        public int RatingId { get; set; }

    }

    public class UpdateBookDTO : CreateBookDTO
    {
        public int Id { get; set; }
    }

    public class BookDTO : UpdateBookDTO
    {

        public int ReviewsNumber { get; set; }
        public decimal Rating { get; set; }
    }
    public class BookReviewDetailsDTO : CreateBookDTO
    {
        public int Id { get; set; }


        public decimal Rating { get; set; }

        public ICollection<ReviewDTO> Reviews { get; set; }
    }
}

