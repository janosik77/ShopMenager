using RestApiShopmenager.DTOs;
using RestApiShopmenager.Models;

namespace RestApiShopmenager.BuissnesLogic.Auth
{
    public interface IAuthService
    {
        Task<(bool IsSuccess, Employees User)> ValidateUserAsync(string username, string password);

        // Generuje tokeny JWT (access + opcjonalnie refresh)
        TokenResult GenerateJwtToken(Employees user);
    }
}
