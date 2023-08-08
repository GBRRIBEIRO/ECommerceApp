
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models.Models
{
    public class ECommUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime CreatedDate => DateTime.Now;
        public List<Address> Adresseses { get; set; } = new List<Address>();
    }
}
