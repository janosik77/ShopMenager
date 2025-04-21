using ShopMenager.DTOs;
using System.Threading.Tasks;

namespace ShopMenager.Services.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponseDto> LoginAsync(LoginRequestDto req);
    }
}
