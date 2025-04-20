using Microsoft.AspNetCore.Mvc;
using RestApiShopmenager.BuissnesLogic.Services;
using RestApiShopmenager.DTOs;

namespace RestApiShopmenager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomePageController : ControllerBase
    {
        private readonly IHomeService _homeService;

        public HomePageController(IHomeService homeService)
        {
            _homeService = homeService;
        }

        // GET: api/Dashboard
        [HttpGet]
        public async Task<ActionResult<HomePageDto>> Get()
        {
            var dto = await _homeService.GetDashboardAsync();
            return Ok(dto);
        }
    }
}
