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
        public Rating(Guid id, ECommUser user, RatingStar ratingStars, string? comment)
        {
            Id = id;
            User = user;
            RatingStars = ratingStars;
            Comment = comment;
        }

        public Guid Id { get; set; }
        public ECommUser User { get; set; }
        public RatingStar RatingStars { get; set; }
        public string? Comment { get; set; }

    }
}
