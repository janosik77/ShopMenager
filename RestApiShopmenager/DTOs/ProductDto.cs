namespace RestApiShopmenager.DTOs
{
    public class ProductDto
    {
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public required string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public required string Description { get; set; }
        public required string PhotoPath { get; set; }
    }
}
