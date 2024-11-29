using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using TfdThreeTier.BuisnessLogic.DTOs;
using TfdThreeTier.BuisnessLogic.Entities;
using TfdThreeTier.Client.Interfaces;

namespace TfdThreeTier.Client.Services;

public class CharacterService(HttpClient httpClient) : ICharacterService
{
    public async Task<ServiceResponse> CreateAsync(Character entity)
    {
        var data = await httpClient.PostAsJsonAsync("api/character", entity);
        var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
        return response;
    }

    public async Task<ServiceResponse> DeleteAsync(int id)
    {
        var data = await httpClient.DeleteAsync($"api/character/{id}");
        var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
        return response;
    }

    public async Task<List<Character>> GetAllAsync() 
    => await httpClient.GetFromJsonAsync<List<Character>>("api/character");
    

    public async Task<Character> GetByIdAsync(int id)
    => await httpClient.GetFromJsonAsync<Character>($"api/character/{id}");

    public async Task<ServiceResponse> UpdateAsync(Character entity)
    {
        var data = await httpClient.PutAsJsonAsync("api/character", entity);
        var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
        return response!;
    }
}
