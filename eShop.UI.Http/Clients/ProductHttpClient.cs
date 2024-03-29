﻿using System.Text;
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

    public async Task AddProductAsync(CarPostDTO product)
    {
        //add a product
        try
        {
            string relativePath = $"cars/";
            var productJson = new StringContent(JsonSerializer.Serialize(product), Encoding.UTF8, "application/json");
            using HttpResponseMessage response = await _httpClient.PostAsync(relativePath, productJson);
            response.EnsureSuccessStatusCode();
        }
        catch (Exception)
        {

        }
    }

    //Get all models from ModelGetDTO
    public async Task<List<ModelGetDTO>> GetModelsAsync()
    {
        try
        {
            // Use the relative path, not the base address here
            string relativePath = "models/";
            using HttpResponseMessage response = await _httpClient.GetAsync(relativePath);
            response.EnsureSuccessStatusCode();

            var resultStream = await response.Content.ReadAsStreamAsync();
            var result = await JsonSerializer.DeserializeAsync<List<ModelGetDTO>>(resultStream,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return result ?? new List<ModelGetDTO>();
        }
        catch (Exception ex)
        {
            return new List<ModelGetDTO>();
        }
    }
    
    //Get all brands from BrandGetDTO
    public async Task<List<BrandGetDTO>> GetBrandsAsync()
    {
        try
        {
            // Use the relative path, not the base address here
            string relativePath = "brands/";
            using HttpResponseMessage response = await _httpClient.GetAsync(relativePath);
            response.EnsureSuccessStatusCode();

            var resultStream = await response.Content.ReadAsStreamAsync();
            var result = await JsonSerializer.DeserializeAsync<List<BrandGetDTO>>(resultStream,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return result ?? new List<BrandGetDTO>();
        }
        catch (Exception ex)
        {
            return new List<BrandGetDTO>();
        }
    }

    public async Task<BrandGetDTO> GetBrandByIdAsync(int Id)
    {
        try
        {
            // Use the relative path, not the base address here
            string relativePath = $"brands/{Id}";
            using HttpResponseMessage response = await _httpClient.GetAsync(relativePath);
            response.EnsureSuccessStatusCode();

            var resultStream = await response.Content.ReadAsStreamAsync();
            var result = await JsonSerializer.DeserializeAsync<BrandGetDTO>(resultStream,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return result ?? new BrandGetDTO();
        }
        catch (Exception ex)
        {
            return new BrandGetDTO();
        }
    }

    public async Task<ModelGetDTO> GetModelByIdAsync(int Id)
    {
        try
        {
            // Use the relative path, not the base address here
            string relativePath = $"models/{Id}";
            using HttpResponseMessage response = await _httpClient.GetAsync(relativePath);
            response.EnsureSuccessStatusCode();

            var resultStream = await response.Content.ReadAsStreamAsync();
            var result = await JsonSerializer.DeserializeAsync<ModelGetDTO>(resultStream,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return result ?? new ModelGetDTO();
        }
        catch (Exception ex)
        {
            return new ModelGetDTO();
        }
    }

}
