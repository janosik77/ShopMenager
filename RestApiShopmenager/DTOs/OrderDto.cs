namespace RestApiShopmenager.DTOs
{
    public class OrderDto
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; } = null!;
        public required string CustomerName { get; set; }
        public required string EmployeeName { get; set; }

        public List<OrderDetailDto> OrderDetails { get; set; } = new();
    }
}
