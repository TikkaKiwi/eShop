using System.Text;
using eShop.API.DTO.DTOs;
using System.Text.Json;

namespace eShop.UI.Http.Clients;

public class ProductHttpClient
{
    private readonly HttpClient _httpClient;
    string _baseAddress = "https://localhost:5500/api/";

    public ProductHttpClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri($"{_baseAddress}products");
    }

    public async Task<List<CarGetDTO>> GetProductsAsync()
    {
        try
        {
            // Use the relative path, not the base address here
            string relativePath = "getallproducts";
            using HttpResponseMessage response = await _httpClient.GetAsync(relativePath);
            response.EnsureSuccessStatusCode();

            var resultStream = await response.Content.ReadAsStreamAsync();
            var result = await JsonSerializer.DeserializeAsync<List<CarGetDTO>>(resultStream,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return result ?? new List<CarGetDTO>();
        }
        catch (Exception ex)
        {
            return new List<CarGetDTO>();
        }
    }

    public async Task<List<CarGetDTO>> GetProductsAsync(int categoryId)
    {
        try
        {
            // Use the relative path, not the base address here
            string relativePath = $"productsbycategory/{categoryId}";
            using HttpResponseMessage response = await _httpClient.GetAsync(relativePath);
            response.EnsureSuccessStatusCode();

            var resultStream = await response.Content.ReadAsStreamAsync();
            var result = await JsonSerializer.DeserializeAsync<List<CarGetDTO>>(resultStream,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return result ?? new List<CarGetDTO>();
        }
        catch (Exception ex)
        {
            return new List<CarGetDTO>();
        }
    }

    public async Task DeleteProductAsync(int id)
    {
        try
        {
            // Use the relative path, not the base address here
            string relativePath = $"cars/{id}";
            using HttpResponseMessage response = await _httpClient.DeleteAsync(relativePath);
            response.EnsureSuccessStatusCode();
        }
        catch (Exception ex)
        {
            //return Results.NotFound();
        }
    }

    public async Task EditProductAsync(CarPutDTO product)
    {
        //edit a product
        try
        {
            // Use the relative path, not the base address here
            string relativePath = $"cars/{product.Id}";
            var productJson = new StringContent(JsonSerializer.Serialize(product), Encoding.UTF8, "application/json");
            using HttpResponseMessage response = await _httpClient.PutAsync(relativePath, productJson);
            response.EnsureSuccessStatusCode();
        }
        catch (Exception ex)
        {
            //return Results.NotFound();
        }
    }

}
