using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryWebAPI.Data.Models
{
	public class Review
	{
		[Key]
		public int Id { get; set; }
		[ForeignKey("Book")]
		public int BookId { get; set; }
		public string Message { get; set; } = string.Empty;
        public string Reviewer { get; set; } = string.Empty;
    }
}

