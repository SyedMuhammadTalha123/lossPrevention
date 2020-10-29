using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loss_Prevention.Models
{
    public class SignUp
    {
        public int ID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string isAdmin { get; set; }
        public string Active { get; set; }
    }
}
