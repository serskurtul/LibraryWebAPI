using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryWebAPI.Data.Models
{
	public class Book
	{
        [Key]
		public int Id { get; set; }
		public string Title { get; set; } = string.Empty;
        public string Cover { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        [ForeignKey(nameof(Rating))]
        public int RatingId { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public virtual Rating Rating { get; set; }
    }
}

