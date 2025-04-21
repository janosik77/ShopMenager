using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ShopMenager.DTOs;
using ShopMenager.Services.Interfaces;

namespace ShopMenager.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _http;
        public AuthService(HttpClient http) => _http = http;

        public async Task<LoginResponseDto> LoginAsync(LoginRequestDto request)
        {
            var resp = await _http.PostAsJsonAsync("auth/login", request);
            resp.EnsureSuccessStatusCode();
            return await resp.Content.ReadFromJsonAsync<LoginResponseDto>();
        }
    }
}
