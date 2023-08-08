using E_Commerce.Models.Models.Enums;


namespace E_Commerce.Models.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Category> Categories { get; set; }
        public int DiscountInPercent { get; set; } = 0;
        public double Price { get; set; }
        public double FinalPrice => Price * (100 / DiscountInPercent);
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<Rating> Ratings { get; set; }
        public Double RatingsAverage => GetRatingsAverage();
        public List<string> ImagesLinks { get; set; }
        public ClothSizes Size { get; set; }
        public Gender ClothGender { get; set; } = 0;


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
    }
}
