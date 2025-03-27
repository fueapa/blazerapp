using MyBlazorApp.Models;
using System.Net.Http.Json;

namespace MyBlazorApp.Services
{
    public class ProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Product>>("api/products") ?? new List<Product>();
        }

        public async Task<Product> CreateAsync(Product product)
        {
            var response = await _httpClient.PostAsJsonAsync("api/products", product);
            return await response.Content.ReadFromJsonAsync<Product>() ?? new Product();
        }

        public async Task UpdateAsync(Product product)
        {
            await _httpClient.PutAsJsonAsync($"api/products/{product.Id}", product);
        }

        public async Task DeleteAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/products/{id}");
        }
    }
}
