//using RestApiShopmenager.Models;

namespace RestApiShopmenager.DTOs
{
    public class CategoryDto
    {
        public int CategoryID { get; set; }
        public required string CategoryName { get; set; }
        public string? CategoryDescription { get; set; }
        //public List<Products> CategoryProducts { get; set; }

    }
}
