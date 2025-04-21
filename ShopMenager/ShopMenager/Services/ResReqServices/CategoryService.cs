using Newtonsoft.Json;
using ShopMenager.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ShopMenager.Services.ApiService
{
    public class CategoryService : IApiService<Category>
    {
        private readonly HttpClient _httpClient;
        private const string Endpoint = "Categories";

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync(Endpoint);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Category>>(json);
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"{Endpoint}/{id}");
            if (!response.IsSuccessStatusCode)
                return null;

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Category>(json);
        }

        public async Task<Category> CreateAsync(Category entity)
        {
            var payload = JsonConvert.SerializeObject(entity);
            var content = new StringContent(payload, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(Endpoint, content);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Category>(responseBody);
        }

        public async Task<bool> UpdateAsync(int id, Category entity)
        {
            var payload = JsonConvert.SerializeObject(entity);
            var content = new StringContent(payload, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"{Endpoint}/{id}", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{Endpoint}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
