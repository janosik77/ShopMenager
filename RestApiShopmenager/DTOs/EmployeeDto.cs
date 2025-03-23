namespace RestApiShopmenager.DTOs
{
    public class EmployeeDto
    {
        public int EmployeeID { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
        public required string PhotoPath { get; set; }
    }
}
