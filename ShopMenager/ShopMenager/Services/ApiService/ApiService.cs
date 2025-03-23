using Newtonsoft.Json;
using ShopMenager.Models;
using ShopMenager.Views;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ShopMenager.Services.ApiService
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5005/api/")
            };
        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            var response = await _httpClient.GetAsync("Customer");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var customers = JsonConvert.DeserializeObject<List<Customer>>(json);
            return customers;
        }

        public async Task<Customer> CreateCustomerAsync(Customer newCustomer)
        {
            var json = JsonConvert.SerializeObject(newCustomer);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("Customer", content);
            response.EnsureSuccessStatusCode();

            var responseJson = await response.Content.ReadAsStringAsync();
            var createdCustomer = JsonConvert.DeserializeObject<Customer>(responseJson);
            return createdCustomer;
        }
    }
}
