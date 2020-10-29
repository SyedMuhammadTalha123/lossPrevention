using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Loss_Prevention.Models
{
    public class Login
    {
        public int ID { get; set; }
     
        public string Email { get; set; }
        [StringLength(20)]
        public string Password { get; set; }
        
    }
}
