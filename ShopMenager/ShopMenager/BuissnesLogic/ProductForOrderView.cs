using System;
using System.Collections.Generic;
using System.Text;

namespace ShopMenager.BuissnesLogic
{
    public class ProductForOrderView
    {
        public int ProductID { get; set; }
        public string  ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public string DiscountName { get; set; }
    }
}
