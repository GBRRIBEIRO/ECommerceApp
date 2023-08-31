using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Models.Constants
{
    public class ClaimsProvider
    {
        public List<Claim> ClaimList;
        public ClaimsProvider()
        {
            ClaimList = new List<Claim>();

            ClaimList.Add(new Claim(Claims.Product, "Read"));
            ClaimList.Add(new Claim(Claims.Product, "Create"));
            ClaimList.Add(new Claim(Claims.Product, "Delete"));
            ClaimList.Add(new Claim(Claims.Product, "Edit"));

            ClaimList.Add(new Claim(Claims.Category, "Read"));
            ClaimList.Add(new Claim(Claims.Category, "Create"));
            ClaimList.Add(new Claim(Claims.Category, "Delete"));
            ClaimList.Add(new Claim(Claims.Category, "Edit"));
           



        }
    }
}
