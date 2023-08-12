using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace E_Commerce.Models.Models.ViewModels
{
    public class LoginResponse
    {
        public bool Success { get; private set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Token { get; private set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? ExpirationDate { get; private set; }

        public List<string> Errors { get; private set; }
        public LoginResponse() => Errors = new List<string>();
        public LoginResponse(bool success = true) : this() => Success = success;
        public LoginResponse(bool success, string token, DateTime expirationDate)
        {
            Success = success;
            Token = token;
            ExpirationDate = expirationDate;
        }
        public void AddErrors(IEnumerable<string> errors) => Errors.AddRange(errors);

    }
}
