using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryWebAPI.Data.ModelsDTO
{
    public class CreateRatingDTO
	{
        public int BookId { get; set; }
        [Range(1d,5d)]
        public decimal Score { get; set; }
    }
}

