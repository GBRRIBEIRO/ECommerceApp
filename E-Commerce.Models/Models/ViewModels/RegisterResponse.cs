using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Models.Models.ViewModels
{
    public class RegisterResponse
    {
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
        public RegisterResponse() => Errors = new List<string>();
        public RegisterResponse(bool success = true) : this() => Success = success;
        public void AddErrors(IEnumerable<string> errors) => Errors.AddRange(errors);
    }
}
