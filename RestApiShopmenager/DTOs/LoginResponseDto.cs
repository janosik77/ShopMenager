namespace RestApiShopmenager.DTOs
{
    public class LoginResponseDto
    {
        public required string AccessToken { get; set; }
        public required DateTime ExpiresAt { get; set; }
        public required UserDto User { get; set; }
    }
}
