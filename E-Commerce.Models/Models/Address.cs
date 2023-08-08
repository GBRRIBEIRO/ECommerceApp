using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Models.Models
{
    public class Address
    {
        public Guid Id { get; set; }
        //[Required]
        //public string Country { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        [MaxLength(9)]
        public string PostalCode { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string Number { get; set; }

    }
}
