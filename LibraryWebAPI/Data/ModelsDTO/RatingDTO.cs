using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryWebAPI.Data.ModelsDTO
{
    public class CreateRatingDTO
	{
        [Required]
        public int BookId { get; set; }
        [Required]
        [Range(1d,5d)]
        public decimal Score { get; set; }
    }
}

