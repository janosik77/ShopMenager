using System;
using System.Collections.Generic;
using System.Text;

namespace ShopMenager.Models
{
    public class Employees
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
        public string PhotoPath { get; set; }
    }
}
