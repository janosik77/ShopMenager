using System;
using System.Collections.Generic;
using System.Text;

namespace ShopMenager.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
    }
}
