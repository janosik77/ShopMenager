namespace RestApiShopmenager.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public required string DisplayName { get; set; }
        public required string AvatarUrl { get; set; }
    }
}
