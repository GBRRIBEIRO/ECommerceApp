using E_Commerce.Models.Models.Enums;

namespace E_Commerce.Models.Models
{
    public class Product
    {
        public Product(
            Guid id,
            string name,
            string description,
            List<Category> categories,
            double price,
            double? costPrice,
            List<Rating>? ratings,
            List<ImageStorage>? images,
            ClothSizes size,
            DateTime updatedAt,
            DateTime createdAt,
            int baseDiscount,
            Gender clothGender)
        {
            Id = id;
            Name = name;
            Description = description;
            Categories = categories;
            Price = price;
            CostPrice = costPrice;
            Ratings = ratings;
            Images = images;
            Size = size;
            UpdatedAt = updatedAt;
            CreatedAt = createdAt;
            BaseDiscount = baseDiscount;
            ClothGender = clothGender;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Category> Categories { get; set; }
        public double Price { get; set; }
        public double? CostPrice { get; set; }
        public List<Rating>? Ratings { get; set; }
        public List<ImageStorage>? Images { get; set; }
        public ClothSizes Size { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public int BaseDiscount { get; set; } = 0;
        public int DiscountInPercent => ApplyCategoryDiscount(BaseDiscount);
        public Gender ClothGender { get; set; } = 0;
        public Double RatingsAverage => GetRatingsAverage();
        public double FinalPrice => Price * (100 / DiscountInPercent);


        public int GetRatingsAverage()
        {
            var quantity = 0;
            var totalAverage = 0;
            foreach(Rating rating in Ratings)
            {
                quantity++;
                totalAverage += (int)rating.RatingStars;
            }
            return totalAverage / quantity;
        }

        public int ApplyCategoryDiscount(int baseDiscount) 
        {
            var biggestDiscount = 0;
            foreach(var category in Categories)
            {
                if(category.DiscountInPercent > biggestDiscount) biggestDiscount = category.DiscountInPercent; 
            
            }
            if(biggestDiscount > baseDiscount) return biggestDiscount;
            else return baseDiscount;

        }


    }
}
