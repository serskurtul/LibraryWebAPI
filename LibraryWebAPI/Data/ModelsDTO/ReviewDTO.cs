using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryWebAPI.Data.ModelsDTO
{
	public class CreateReviewDTO
	{
        [Required]
        public int BookId { get; set; }
        [Required]
        [StringLength(maximumLength: 200)]
        public string Message { get; set; } = string.Empty;
        [Required]
        [StringLength(maximumLength: 100)]
        public string Reviewer { get; set; } = string.Empty;

    }
    public class ReviewDTO : CreateReviewDTO
	{
        public int Id { get; set; }

    }
}

