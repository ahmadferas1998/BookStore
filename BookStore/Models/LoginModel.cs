using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class LoginModel
    {
        [Required]
        public string name { get; set; }
        [Required]
        public string password  { get; set; }
        public bool rememberme { get; set; }
    }
}
