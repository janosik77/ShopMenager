using Microsoft.Build.Evaluation;
using System.Reflection.Metadata.Ecma335;

namespace RestApiShopmenager.DTOs
{
    public class ReviewsDto
    {
        public int ReviewID { get; set; }
        public int Rating { get; set; }
        public string? Comments { get; set; }
        public DateTime ReviewDate { get; set; }

        public required string EmployeeName { get; set; }
        public required string ProductName { get; set; }
        public int EmployeeID { get; set; }
        public int ProductID { get; set; }
    }
}
