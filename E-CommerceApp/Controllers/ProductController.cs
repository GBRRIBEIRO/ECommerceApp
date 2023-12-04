
using E_Commerce.DataAcess.Repository.IRepository;
using E_Commerce.Models.Models;
using E_Commerce.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

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

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] Guid id)
        {
            var product = _unitOfWork.Products.Get(p => p.Id == id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _unitOfWork.Products.GetAll();
            if (products == null || products.IsNullOrEmpty()) return NoContent();
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductViewModel productInput)
        {
            var newId = Guid.NewGuid();
            var newProduct = new Product();
            var categories = new List<Category>();
            try
            {
                //Get Product categories
                foreach (Guid catId in productInput.CategoriesId)
                {
                    var productCategories = _unitOfWork.Categories.Get(p => p.Id == catId);
                    if (productCategories != null)
                    {
                       categories.Add(productCategories);
                    }
                    else
                    {
                        throw new Exception("Category doesn't exist!");
                    }
                }
                newProduct = new Product(newId, productInput, categories);
                
                //Add in the Database
                _unitOfWork.Products.Post(newProduct);
                _unitOfWork.Save();
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }

            return Created($"Product/{newId}", newProduct);
        }


        [HttpPatch]
        public IActionResult Patch([FromBody] Product productInput)
        {
            var product = _unitOfWork.Products.Get(p => p.Id == productInput.Id);
            if (product == null) return NotFound();
            _unitOfWork.Products.Patch(productInput);
            _unitOfWork.Save();
            return Ok(productInput);
        }

        [HttpDelete]
        public IActionResult Delete([FromQuery] Guid id)
        {
            var product = _unitOfWork.Products.Get(p => p.Id == id);
            if (product == null) return NotFound();
            _unitOfWork.Products.Delete(product);
            _unitOfWork.Save();
            return Ok();
        }

        
    }
}
