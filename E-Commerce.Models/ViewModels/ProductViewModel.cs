using E_Commerce.Models.Enums;
using E_Commerce.Models.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Models.ViewModels
{
    public class ProductViewModel
    {
        public ProductViewModel(string name,
            string description,
            List<Guid> categoriesId,
            int discountInPercent,
            double price,
            double? costPrice,
            ClothSizes size,
            Gender clothGender)
        {
            Name = name;
            Description = description;
            CategoriesId = categoriesId;
            DiscountInPercent = discountInPercent;
            Price = price;
            CostPrice = costPrice;
            Size = size;
            ClothGender = clothGender;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public List<Guid> CategoriesId { get; set; }
        public int DiscountInPercent { get; set; } = 0;
        public double Price { get; set; }
        public double? CostPrice { get; set; }
        public ClothSizes Size { get; set; }
        public Gender ClothGender { get; set; } = 0;

    }
}
