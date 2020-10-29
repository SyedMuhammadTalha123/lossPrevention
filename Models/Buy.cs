using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loss_Prevention.Models
{
    public class Buy
    {
        public int ID { get; set; }
        public String Quantity { get; set; }
        public int Purchased { get; set; }
        public string Amount { get; set; }
        public DateTime Date { get; set; }
        public int userID { get; set; }
        public int rowID { get; set; }
    }
}
