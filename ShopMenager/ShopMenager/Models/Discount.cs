using System;
using System.Collections.Generic;
using System.Text;

namespace ShopMenager.Models
{
    public class Discount
    {
        public int DiscountID { get; set; }
        public string DiscountName { get; set; }
        public decimal DiscountRate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
