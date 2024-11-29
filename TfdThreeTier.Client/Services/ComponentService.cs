using System.Net.Http;
using System.Net.Http.Json;
using TfdThreeTier.BuisnessLogic.DTOs;
using TfdThreeTier.BuisnessLogic.Entities;
using TfdThreeTier.Client.Interfaces;

namespace TfdThreeTier.Client.Services;

public class ComponentService(HttpClient httpClient) : IComponentService
{
    public async Task<ServiceResponse> CreateAsync(Component entity)
    {
        var data = await httpClient.PostAsJsonAsync("api/components", entity);
        var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
        return response;
    }

    public async Task<ServiceResponse> DeleteAsync(int id)
    {
        var data = await httpClient.DeleteAsync($"api/components/{id}");
        var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
        return response;
    }

    public async Task<List<Component>> GetAllAsync()
    => await httpClient.GetFromJsonAsync<List<Component>>("api/components");


    public async Task<Component> GetByIdAsync(int id)
    => await httpClient.GetFromJsonAsync<Component>($"api/components/{id}");

    public async Task<ServiceResponse> UpdateAsync(Component entity)
    {
        var data = await httpClient.PutAsJsonAsync("api/components", entity);
        var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
        return response!;
    }
}
