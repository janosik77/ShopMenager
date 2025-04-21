using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RestApiShopmenager.BuissnesLogic.Auth;
using RestApiShopmenager.Models;
using RestApiShopmenager.Models.Contexts;

public class AuthService : IAuthService
{
    private readonly CompanyContext _db;
    private readonly IConfiguration _cfg;

    public AuthService(CompanyContext db, IConfiguration cfg)
    {
        _db = db;
        _cfg = cfg;
    }

    // … ValidateUserAsync …

    public TokenResult GenerateJwtToken(Employees user)
    {
        // 1. Pobierz ustawienia JWT z appsettings.json
        var issuer = _cfg["Jwt:Issuer"];
        var audience = _cfg["Jwt:Audience"];
        var secret = _cfg["Jwt:Secret"];        // Twój klucz symetryczny
        var expiresIn = int.Parse(_cfg["Jwt:ExpiresInMinutes"]); // np. "60"

        // 2. Przygotuj klucz i creds
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        // 3. Zbierz claims (dodaj tu co potrzebujesz, np. role)
        var claims = new[]
        {
            new System.Security.Claims.Claim(JwtRegisteredClaimNames.Sub, user.EmployeeId.ToString()),
            new Claim(JwtRegisteredClaimNames.UniqueName, user.Email),
            new Claim("displayName", $"{user.FirstName} {user.LastName}"),
            // new Claim(ClaimTypes.Role, "User") // jeśli masz role
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        // 4. Wygeneruj datę wygaśnięcia
        var expiresAt = DateTime.UtcNow.AddMinutes(expiresIn);

        // 5. Stwórz token
        var tokenDescriptor = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: expiresAt,
            signingCredentials: creds
        );

        var tokenHandler = new JwtSecurityTokenHandler();
        string tokenString = tokenHandler.WriteToken(tokenDescriptor);

        return new TokenResult
        {
            TokenString = tokenString,
            ExpiresAt = expiresAt
        };
    }

    public async Task<(bool IsSuccess, Employees User)> ValidateUserAsync(string username, string password)
    {
        // 1) Pobierz usera po nazwie
        var user = await _db.Employees
                            .SingleOrDefaultAsync(u => u.Email == username);

        // 2) Sprawdź, czy istnieje i czy hasło się zgadza
        if (user == null ||
            !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
        {
            return (false, null);
        }

        // 3) Everything OK
        return (true, user);
    }
}
