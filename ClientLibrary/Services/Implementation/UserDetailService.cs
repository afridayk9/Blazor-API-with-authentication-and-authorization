using BaseLibrary.DTOs;
using ClientLibrary.Helpers;
using ClientLibrary.Services.Interfaces;
using System.Net.Http.Json;

public class UserDetailService : IUserDetailService
{
    private readonly HttpClient _httpClient;
    private readonly GetHttpClient _getPrivateHttpClient;

    public UserDetailService(IHttpClientFactory httpClientFactory, GetHttpClient getPrivateHttpClient)
    {
        _httpClient = httpClientFactory.CreateClient("SystemApiClient");
        _getPrivateHttpClient = getPrivateHttpClient;
    }

    public async Task<List<UserDetail>> GetAllUsersWithRolesAsync()
    {
        var httpClient = await _getPrivateHttpClient.GetPrivateHttpClient();
        var result = await httpClient.GetFromJsonAsync<List<UserDetail>>("api/user");
        return result ;
    }

    //public async Task<List<UserDetail>> GetAllUserWithRolesAsync()
    //{
    //    await _httpClient.GetFromJsonAsync<List<UserDetail>>("api/user");
    //}

    public async Task UpdateUserAsync(UserDetail user)
    {
        await _httpClient.PutAsJsonAsync($"api/user/{user.Id}", user);
    }

    public async Task DeleteUserAsync(int userId)
    {
        await _httpClient.DeleteAsync($"api/user/{userId}");
    }
}


