using RestApiShopmenager.DTOs;

namespace RestApiShopmenager.BuissnesLogic.Services
{
    public interface IHomeService
    {
        Task<HomePageDto> GetDashboardAsync();
    }
}
