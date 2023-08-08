using E_Commerce.DataAcess.Repository.IRepository;
using E_Commerce.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceApp.Controllers
{
    [Route("Product/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private IWebHostEnvironment _webHostEnvironment;
        public IUnitOfWork _unitOfWork;
        public ImageController(IWebHostEnvironment webHostEnvironment, IUnitOfWork unitOfWork)
        {
            _webHostEnvironment = webHostEnvironment;
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        public List<string> GetImageByProductId([FromQuery] Guid productId)
        {
            var images = new List<string>();
            string ImageUrl = _webHostEnvironment.WebRootPath + "\\Uploads\\Product\\" + productId.ToString();
            if (!System.IO.Directory.Exists(ImageUrl)) return new List<string>(); //Implement
            string[] imagePaths = System.IO.Directory.GetFiles(ImageUrl);
            return imagePaths.ToList();
        }

        [HttpPost]
        public async Task<IActionResult> PostImage([FromQuery] Guid productId, [FromForm(Name = "files")] List<IFormFile> images)
        {
            var product = _unitOfWork.Products.Get(_p => _p.Id == productId);
            if(product == null) return NotFound(); 

            var i = 0;
            foreach (var _file in images)
            {

                string fileName = _file.FileName;
                var type = Path.GetExtension(fileName);
                string[] validTypes = { ".jpg", ".png", ".jpeg" };
                foreach (var validType in validTypes)
                {
                    if (type != validType) break;
                }


                string filePath = _webHostEnvironment.WebRootPath + "\\Uploads\\Product\\" + productId.ToString();

                if (!System.IO.Directory.Exists(filePath))
                    {
                        System.IO.Directory.CreateDirectory(filePath);
                    }

                string imagePath = $"{filePath}\\image{i}{type}";

                if (System.IO.Directory.Exists(imagePath))
                    {
                        System.IO.Directory.Delete(imagePath);
                    }

                using (FileStream stream = System.IO.File.Create(imagePath))
                {
                    await _file.CopyToAsync(stream);

                }
                product.Images.Add(new ImageStorage(new Guid(),filePath));

                i++;
            }
            _unitOfWork.Save();
            return CreatedAtAction(nameof(GetImageByProductId), productId);
        }
    }
}
