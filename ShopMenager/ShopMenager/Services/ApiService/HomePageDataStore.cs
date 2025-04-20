using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShopMenager.Services.ApiService
{
    public class HomePageDataStore : IDataStore<HomePageDto>
    {
        private readonly OrderService _svc;
        private HomePageDto _cache;

        public HomePageDataStore() =>
            _svc = DependencyService.Get<OrderService>();

        /* -------- ODCZYT -------- */
        public async Task<HomePageDto> GetItemAsync(int id = 0) =>
            await GetAsync(true);

        public async Task<IEnumerable<HomePageDto>> GetItemsAsync(bool forceRefresh = false)
            => new[] { await GetAsync(forceRefresh) };

        /* -------- ZAPIS (niedostępny) -------- */
        public Task<bool> AddItemAsync(HomePageDto item) => Task.FromException<bool>(
            new NotSupportedException("Dashboard is read‑only"));

        public Task<bool> UpdateItemAsync(HomePageDto item) => Task.FromException<bool>(
            new NotSupportedException("Dashboard is read‑only"));

        public Task<bool> DeleteItemAsync(int id) => Task.FromException<bool>(
            new NotSupportedException("Dashboard is read‑only"));

        /* -------- POMOCNICZE -------- */
        private async Task<HomePageDto> GetAsync(bool forceRefresh)
        {
            if (forceRefresh || _cache is null)
                _cache = await _svc.HomePageAsync().ConfigureAwait(false);

            return _cache;
        }
    }
}
