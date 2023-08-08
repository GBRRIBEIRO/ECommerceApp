using E_Commerce.Models.Models.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Models.Models.ViewModels
{
    public class ProductViewModel
    {
        public ProductViewModel(string name,
            string description,
            List<Category> categories,
            int discountInPercent,
            double price,
            double? costPrice,
            List<IFormFile> images,
            ClothSizes size,
            Gender clothGender)
        {
            Name = name;
            Description = description;
            Categories = categories;
            DiscountInPercent = discountInPercent;
            Price = price;
            CostPrice = costPrice;
            Images = images;
            Size = size;
            ClothGender = clothGender;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public List<Category> Categories { get; set; }
        public int DiscountInPercent { get; set; } = 0;
        public double Price { get; set; }
        public double? CostPrice { get; set; }
        public List<IFormFile> Images { get; set; }
        public ClothSizes Size { get; set; }
        public Gender ClothGender { get; set; } = 0;

    }
}
