using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Study_3092022.Models
{
    public class RoleModel
    {
        [Required]
        public string name { get; set; }
    }
}
