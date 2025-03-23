using System;
using System.Collections.Generic;
using System.Text;

namespace ShopMenager.Models
{
    public class Review
    {
        public int ReviewID { get; set; }
        public int Rating { get; set; }
        public string Comments { get; set; }
        public DateTime ReviewDate { get; set; }

        public string EmployeeName { get; set; }
        public int EmployeeID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
    }
}

