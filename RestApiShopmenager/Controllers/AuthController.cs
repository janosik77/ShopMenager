using Microsoft.AspNetCore.Mvc;
using RestApiShopmenager.BuissnesLogic.Auth;
using RestApiShopmenager.DTOs;

namespace RestApiShopmenager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]    //public class AuthController : ControllerBase
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _auth;
    public AuthController(IAuthService auth) => _auth = auth;

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto req)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var (ok, user) = await _auth.ValidateUserAsync(req.Username, req.Password);
        if (!ok)
            return Unauthorized(new { message = "Nieprawidłowe dane logowania." });

        var tok = _auth.GenerateJwtToken(user);
        return Ok(new LoginResponseDto
        {
            AccessToken = tok.TokenString,
            ExpiresAt = tok.ExpiresAt,
            User = new UserDto 
            { 
                Id = user.EmployeeId, 
                DisplayName = $"{user.FirstName} {user.LastName}", 
                AvatarUrl = user.PhotoPath }
        });
    }
}

}
