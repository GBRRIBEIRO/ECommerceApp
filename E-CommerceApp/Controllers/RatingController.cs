using E_Commerce.DataAcess.Repository.IRepository;
using E_Commerce.Models.Models;
using E_Commerce.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    
    public class RatingController : ControllerBase
    {
        private readonly UserManager<ECommUser> _userManager;
        public IUnitOfWork _unitOfWork;

        public RatingController(UserManager<ECommUser> _userManager,IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetByProductId(Guid ProductId)
        {
            try
            {
                var _product = _unitOfWork.Products.Get(_P => _P.Id == ProductId);
                if (_product == null) throw new Exception("Not Found");

                var ratings = _product.Ratings;
                return Ok(ratings);
            }
            catch (Exception err)
            {
                if (err.Message == "Not Found") return NotFound();
                return BadRequest(err.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateRating([FromBody] RatingViewmodel rating) 
        {
            try
            {
                var currentUser = await _userManager.GetUserAsync(User);
                Rating _rating = new Rating(
                    id: new Guid(),
                    ratingStars: rating.Stars,
                    comment: rating.Comment,
                    userName: $"{currentUser.FirstName} {currentUser.LastName}"
                    ) ;
                _unitOfWork.Ratings.Post(_rating);
                return CreatedAtAction(nameof(Rating), rating);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
