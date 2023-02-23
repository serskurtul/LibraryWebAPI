using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryWebAPI.Data.ModelsDTO
{
    public class CreateBookDTO
    {
        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 1)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(maximumLength: 180000)]
        public string Cover { get; set; } = string.Empty;

        [Required]
        [StringLength(maximumLength: 3000, MinimumLength = 5)]
        public string Content { get; set; } = string.Empty;

        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 5)]
        public string Author { get; set; } = string.Empty;

        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 5)]
        public string Genre { get; set; } = string.Empty;

    }

    public class UpdateBookDTO : CreateBookDTO
    {
        [Required]
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

