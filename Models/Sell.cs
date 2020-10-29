using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loss_Prevention.Models
{
    public class Sell
    {
        public int ID { get; set; }
        public int SID { get; set; }
        public String AvailableQuantity { get; set; }
        public String PurchasedCost { get; set; }
        public int QuantitySell { get; set; }  
        public int userID { get; set; }  
        public String SellingCost { get; set; }
       
    }
}
