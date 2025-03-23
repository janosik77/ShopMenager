using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopMenager.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }

    }
}
