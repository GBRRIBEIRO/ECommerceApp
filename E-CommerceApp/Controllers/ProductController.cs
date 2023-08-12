

using E_Commerce.DataAcess.Repository;
using E_Commerce.DataAcess.Repository.IRepository;
using E_Commerce.Models.Models;
using E_Commerce.Models.Models.ViewModels;
using E_CommerceApp.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public IWebHostEnvironment _webHostEnvironment { get; }

        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _unitOfWork.Products.GetAll();
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductViewModel productInput)
        {
            
            var _newId = new Guid();
            var _product = new Product();

            _product.Id = _newId;
            _product.Name = productInput.Name;
            _product.Description = productInput.Description;
            _product.Categories = productInput.Categories;
            _product.Price = productInput.Price;
            _product.CostPrice = productInput.CostPrice;
            _product.CreatedAt = DateTime.Now;
            _product.UpdatedAt = DateTime.Now;
            _product.Ratings = new List<Rating>();
            _product.Size = productInput.Size;
            _product.BaseDiscount = productInput.DiscountInPercent;
            _product.ClothGender = productInput.ClothGender;
            _product.Images = new List<ImageStorage>();
            _product.ApplyCategoryDiscount();
            _product.GetTotal();

            _unitOfWork.Products.Post(_product);
            _unitOfWork.Save();
            return Ok();
            
        }


        [HttpPatch]
        public IActionResult Patch([FromBody] Product ProductInput)
        {
            //ToDO: Repository
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete([FromQuery] Guid id)
        {
            //ToDO: Repository
            return Ok();
        }

        
    }
}
