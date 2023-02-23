using System;
using System.ComponentModel.DataAnnotations;

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

        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }
    }
}

