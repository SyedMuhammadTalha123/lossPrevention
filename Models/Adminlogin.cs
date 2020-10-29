using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Loss_Prevention.Models
{
    public class Adminlogin
    {
        public int ID { get; set; }

        public string Adminemail { get; set; }
       
        public string Adminpassword { get; set; }

    }
}
