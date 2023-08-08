

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
            
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductViewModel productInput)
        {
            
            var _newId = new Guid();
            var _product = new Product(
                id: _newId,
                name: productInput.Name,
                description: productInput.Description,
                categories: productInput.Categories,
                price: productInput.Price,
                costPrice: productInput.CostPrice,
                createdAt: DateTime.Now,
                updatedAt: DateTime.Now,
                ratings: new List<Rating>(),
                size: productInput.Size,
                baseDiscount: productInput.DiscountInPercent,
                clothGender: productInput.ClothGender,
                images: new List<ImageStorage>()
                );
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
