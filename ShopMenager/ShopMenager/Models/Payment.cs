using System;
using System.Collections.Generic;
using System.Text;

namespace ShopMenager.Models
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public int OrderID { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public int PaymentMethod { get; set; }
        public int PaymentStatus { get; set; }
    }
}
