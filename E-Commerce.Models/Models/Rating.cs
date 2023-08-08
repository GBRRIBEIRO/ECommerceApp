using E_Commerce.Models.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Models.Models
{
    public class Rating
    {
        public Rating(Guid id, string userName, RatingStar ratingStars, string? comment)
        {
            Id = id;
            UserName = userName;
            RatingStars = ratingStars;
            Comment = comment;
        }

        public Guid Id { get; set; }
        public string UserName { get; set; }
        public RatingStar RatingStars { get; set; }
        public string? Comment { get; set; }

    }
}
