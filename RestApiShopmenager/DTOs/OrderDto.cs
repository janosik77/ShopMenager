namespace RestApiShopmenager.DTOs
{
    public class OrderDto
    {
        public required int OrderID { get; set; }
        public required int CustomerID { get; set; }
        public required int EmployeeID { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; } = null!;
        public string? CustomerName { get; set; }
        public string? EmployeeName { get; set; }

        public List<OrderDetailDto> OrderDetails { get; set; } = new();
    }
}
