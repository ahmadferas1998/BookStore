using Microsoft.AspNetCore.Identity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class ApplicationUsser : IdentityUser
    {
        public string name { get; set; }
        public DateTime bdate { get; set; }
        public string phone { get; set; }
    }
}
