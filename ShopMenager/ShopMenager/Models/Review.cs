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

        public Employee Employee { get; set; }
        public Product Product { get; set; }
    }
}
