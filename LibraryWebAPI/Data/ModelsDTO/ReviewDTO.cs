using System;
namespace LibraryWebAPI.Data.ModelsDTO
{
	public class CreateReviewDTO
	{
        public int BookId { get; set; }
        public string Message { get; set; } = string.Empty;
        public string Reviewer { get; set; } = string.Empty;

    }
    public class ReviewDTO : CreateReviewDTO
	{
        public int Id { get; set; }

    }
}

