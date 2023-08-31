using E_Commerce.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Models.ViewModels
{
    public class RatingViewmodel
    {
        public string Comment { get; set; }
        public RatingStar Stars { get; set; }

    }
}
