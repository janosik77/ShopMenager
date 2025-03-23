using System;
using System.Collections.Generic;
using System.Text;

namespace ShopMenager.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public string PhotoPath { get; set; }
    }
}
