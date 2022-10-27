using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class SignupModel
    {
        [Required]
        public string name { get; set; }
        [Required]
           public string email { get; set; }
        public DateTime bdate { get; set; }
     [Compare("confermPassword")]
        public string passwotrd { get; set; }
     
        public string confermPassword { get; set;}
}
}
