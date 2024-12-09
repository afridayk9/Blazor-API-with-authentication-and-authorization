using BaseLibrary.DTOs;
using ClientLibrary.Services.Interfaces;
using System.Net.Http.Json;

public class UserDetailService : IUserDetailService
{
    private readonly HttpClient _httpClient;

    public UserDetailService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("SystemApiClient");
    }

    public async Task<List<UserDetail>> GetAllUsersWithRolesAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<UserDetail>>("api/user");
    }
}


