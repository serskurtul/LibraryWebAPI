using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryWebAPI.Data.Models
{
	public class Rating
	{
		[Key]
		public int Id { get; set; }
		public int BookId { get; set; }
		public decimal Score { get; set; }
	}
}

