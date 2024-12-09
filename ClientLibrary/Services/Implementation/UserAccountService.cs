using BaseLibrary.DTOs;
using BaseLibrary.Entities;
using BaseLibrary.Responses;
using ClientLibrary.Helpers;
using ClientLibrary.Services.Interfaces;
using System.Net.Http.Json;

namespace ClientLibrary.Services.Implementation;
public class UserAccountService(GetHttpClient getHttpClient) : IUserAccountService
{
    public const string AuthUrl = "/api/authentication"; 

   

    public async Task<GeneralResponse> CreateAsync(Register user)
    {
        var httpClient = getHttpClient.GetPublicHttpClient();
        var result = await httpClient.PostAsJsonAsync($"{AuthUrl}/register", user);
        if (!result.IsSuccessStatusCode) return new GeneralResponse(false, "Failed to create user in UserAccountService");

        return await result.Content.ReadFromJsonAsync<GeneralResponse>()!;
    }

    public async Task<LoginResponse> SignInAsync(Login user)
    {
        var httpClient = getHttpClient.GetPublicHttpClient();
        var result = await httpClient.PostAsJsonAsync($"{AuthUrl}/login", user);
        if (!result.IsSuccessStatusCode) return new LoginResponse(false, "Failed to sign in in UserAccountService");

        return await result.Content.ReadFromJsonAsync<LoginResponse>()!;
    }

    public async Task<LoginResponse> RefreshTokenAsync(RefreshToken token)
    {
        var httpCLient = getHttpClient.GetPublicHttpClient();
        var result = await httpCLient.PostAsJsonAsync($"{AuthUrl}/refresh-token", token);
        if (!result.IsSuccessStatusCode) return new LoginResponse(false, "Failed to refresh token in UserAccountService");

        return await result.Content.ReadFromJsonAsync<LoginResponse>()!;
    }
}





