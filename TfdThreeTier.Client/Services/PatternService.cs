using System.Net.Http.Json;
using TfdThreeTier.BuisnessLogic.DTOs;
using TfdThreeTier.BuisnessLogic.Entities;
using TfdThreeTier.Client.Interfaces;

namespace TfdThreeTier.Client.Services;

public class PatternService(HttpClient httpClient) : IPatternService
{
    public async Task<ServiceResponse> CreateAsync(Pattern entity)
    {
        var data = await httpClient.PostAsJsonAsync("api/pattern", entity);
        var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
        return response;
    }

    public async Task<ServiceResponse> DeleteAsync(int id)
    {
        var data = await httpClient.DeleteAsync($"api/pattern/{id}");
        var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
        return response;
    }

    public async Task<List<Pattern>> GetAllAsync()
    => await httpClient.GetFromJsonAsync<List<Pattern>>("api/pattern");


    public async Task<Pattern> GetByIdAsync(int id)
    => await httpClient.GetFromJsonAsync<Pattern>($"api/pattern/{id}");

    public async Task<ServiceResponse> UpdateAsync(Pattern entity)
    {
        var data = await httpClient.PutAsJsonAsync("api/pattern", entity);
        var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
        return response!;
    }
}
