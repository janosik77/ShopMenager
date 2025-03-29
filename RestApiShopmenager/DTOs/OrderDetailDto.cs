namespace RestApiShopmenager.DTOs
{
    public class OrderDetailDto
    {
        public int OrderDetailID { get; set; }
        public int ProductID { get; set; }
        public required string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int DiscountID { get; set; }
        public decimal DiscountPerc { get; set; }
        public decimal Total { get; set; }
    }
}
