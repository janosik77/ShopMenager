namespace RestApiShopmenager.DTOs
{
    public class ReviewsDto
    {
        public int ReviewId { get; set; }
        public int Rating { get; set; }
        public string? Comments { get; set; }
        public DateTime ReviewDate { get; set; }

        public required EmployeeDto Employee { get; set; }
        public required ProductDto Product { get; set; }
    }
}
