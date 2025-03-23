using System;
using System.Collections.Generic;
using System.Text;

namespace ShopMenager.Models
{
    public class OrderDetail
    {
        public int OrderDetailsId { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
    }
}
