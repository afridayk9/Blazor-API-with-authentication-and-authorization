using System.Net.Http.Json;
using TfdThreeTier.BuisnessLogic.DTOs;
using TfdThreeTier.BuisnessLogic.Entities;
using TfdThreeTier.Client.Interfaces;

namespace TfdThreeTier.Client.Services;

public class MaterialService(HttpClient httpClient) : IMaterialService
{
    public async Task<ServiceResponse> CreateAsync(Material entity)
    {
        var data = await httpClient.PostAsJsonAsync("api/materials", entity);
        var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
        return response;
    }

    public async Task<ServiceResponse> DeleteAsync(int id)
    {
        var data = await httpClient.DeleteAsync($"api/materials/{id}");
        var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
        return response;
    }

    public async Task<List<Material>> GetAllAsync()
    => await httpClient.GetFromJsonAsync<List<Material>>("api/materials");


    public async Task<Material> GetByIdAsync(int id)
    => await httpClient.GetFromJsonAsync<Material>($"api/materials/{id}");

    public async Task<ServiceResponse> UpdateAsync(Material entity)
    {
        var data = await httpClient.PutAsJsonAsync("api/materials", entity);
        var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
        return response!;
    }
}
