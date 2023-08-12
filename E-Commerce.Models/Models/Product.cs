using E_Commerce.Models.Models.Enums;

namespace E_Commerce.Models.Models
{
    public class Product
    {
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
        public int DiscountInPercent { get; set; } = 0;
        public Gender ClothGender { get; set; } = 0;
        public Double RatingsAverage { get; set; } = 0;
        public double FinalPrice { get; set; } = 0;


        public void GetRatingsAverage()
        {
            var quantity = 0;
            var totalAverage = 0;
            foreach(Rating rating in Ratings)
            {
                quantity++;
                totalAverage += (int)rating.RatingStars;
            }
            RatingsAverage = totalAverage / quantity;
        }

        public void ApplyCategoryDiscount() 
        {

            var biggestDiscount = 0;
            biggestDiscount = BaseDiscount;
            foreach(var category in Categories)
            {
                if(category.DiscountInPercent > biggestDiscount) biggestDiscount = category.DiscountInPercent; 
            
            }
            DiscountInPercent = biggestDiscount;

        }

        public void GetTotal()
        {
            FinalPrice = Price * (100 / DiscountInPercent);
        }


    }
}
