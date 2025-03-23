using Newtonsoft.Json;

namespace RestApiShopmenager.DTOs
{
    public class CustomerDto
    {
        public int CustomerId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }      
        public required string Email { get; set; }        
        public required string Phone { get; set; }        
        public required string Address { get; set; }        
        public required string City { get; set; }        
        public required string PhotoPath { get; set; }
    }
}
