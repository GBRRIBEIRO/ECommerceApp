using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace E_Commerce.Models.ViewModels
{
    public class LoginResponse
    {
        public bool Success => Errors.Count == 0;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? AccessToken { get; private set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? RefreshToken { get; private set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? ExpirationDate { get; private set; }

        public List<string> Errors { get; private set; }

        //If just created without any arguments, errors initialized
        public LoginResponse() => Errors = new List<string>();

        //Constructor for the full object
        public LoginResponse(bool success, string accessToken, string refreshToken) : this()
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }

        public void AddErrors(IEnumerable<string> errors) => Errors.AddRange(errors);
        public void AddError(string error) => Errors.Add(error);


    }
}
