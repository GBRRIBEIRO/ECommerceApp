

using E_Commerce.DataAcess.Repository;
using E_Commerce.DataAcess.Repository.IRepository;
using E_Commerce.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Policy = "IsManager")] //Makes the controller only usable by who have this Policy as True
    public class CategoryController : ControllerBase
    {
        public IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [AllowAnonymous] //Exeption, open to all users.
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Category> _categories = _unitOfWork.Categories.GetAll().ToList();
            if (!_categories.Any()) return BadRequest();
            return Ok(_categories);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Category categoryInput)
        {
            try
            {
                _unitOfWork.Categories.Post(categoryInput);
                _unitOfWork.Save();
            }
            catch (Exception)
            {

                return BadRequest();
            }
            return Ok(categoryInput);


        }


        [HttpPatch]
        public IActionResult Patch([FromBody] Category categoryInput)
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
