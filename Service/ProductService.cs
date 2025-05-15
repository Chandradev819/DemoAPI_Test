using DemoAPI.Model;

namespace DemoAPI.Service
{
    public class ProductService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://api.restful-api.dev/objects";

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Product>> GetProductsAsync(string filter = null, int page = 1, int pageSize = 10)
        {
            var response = await _httpClient.GetFromJsonAsync<List<Product>>(BaseUrl);
            if (response == null) return new List<Product>();

            var filtered = string.IsNullOrEmpty(filter) ? response :
                response.Where(p => p.Name.Contains(filter, StringComparison.OrdinalIgnoreCase)).ToList();

            return filtered.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }

        public async Task<bool> AddProductAsync(Product product)
        {
            var response = await _httpClient.PostAsJsonAsync(BaseUrl, product);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteProductAsync(string id)
        {
            var response = await _httpClient.DeleteAsync($"{BaseUrl}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
