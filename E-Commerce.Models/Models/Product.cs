using E_Commerce.Models.Enums;
using E_Commerce.Models.ViewModels;

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
        public int DiscountInPercent { get; set; } = 0;
        public Gender ClothGender { get; set; } = 0;
        public Double RatingsAverage { get; set; } = 0;
        public double FinalPrice { get; set; } = 0;
        public Product() 
        {
            UpdatedAt = DateTime.Now;
            CreatedAt = DateTime.Now;

        }

        public Product(Guid id, ProductViewModel model, IEnumerable<Category> categories) : base()
        {
            Id = id;
            Name = model.Name;
            Description = model.Description;
            CostPrice = model.CostPrice;
            Price = model.Price;
            ClothGender = model.ClothGender;
            Size = model.Size;
            AddCategories(categories);
            CalculateDiscountByCategories(categories);
            GetTotal();
        }

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
        
        public void AddCategory(Category cat)
        {
            Categories.Add(cat);
        }

        public void AddCategories(IEnumerable<Category> categories)
        {
            Categories.AddRange(categories);
        }

        public void CalculateDiscountByCategories(IEnumerable<Category> categories)
        {
            var highestDiscount = 0;
            foreach (Category category in categories)
            {
                if (category.DiscountInPercent > highestDiscount) highestDiscount = category.DiscountInPercent;
            }
            DiscountInPercent = highestDiscount;

        }

        public void GetTotal()
        {
            if(DiscountInPercent > 0) FinalPrice = Price * (100 / DiscountInPercent);
            else FinalPrice = Price;
        }


    }
}
