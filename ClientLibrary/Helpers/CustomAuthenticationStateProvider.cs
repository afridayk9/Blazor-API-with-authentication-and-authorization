using BaseLibrary.DTOs;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ClientLibrary.Helpers;
public class CustomAuthenticationStateProvider(LocalStorageService localStorageService) : AuthenticationStateProvider
{
    private readonly ClaimsPrincipal anonymous = new(new ClaimsIdentity());
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var stringToken = await localStorageService.GetToken();
        if (string.IsNullOrEmpty(stringToken)) return await Task.FromResult(new AuthenticationState(anonymous));

        var deserializationToken = Serializations.DeserializeJsonString<UserSession>(stringToken);
        if (deserializationToken is null) return await Task.FromResult(new AuthenticationState(anonymous));

        var getUserClaims = DecryptToken(deserializationToken.Token!);
        if (getUserClaims is null) return await Task.FromResult(new AuthenticationState(anonymous));    
    
        var claimsPrincipal = SetClaimPrincipal(getUserClaims);
        return await Task.FromResult(new AuthenticationState(claimsPrincipal));
    }

    private static CustomUserClaims DecryptToken(string jwtToken)
    {
        var handler = new JwtSecurityTokenHandler();
        var token = handler.ReadJwtToken(jwtToken);
        var userId = token.Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier);
        var userName = token.Claims.FirstOrDefault(u => u.Type == ClaimTypes.Name);
        var email = token.Claims.FirstOrDefault(u => u.Type == ClaimTypes.Email);
        var role = token.Claims.FirstOrDefault(u => u.Type == ClaimTypes.Role);
        return new CustomUserClaims(userId!.Value!, userName!.Value, email!.Value, role!.Value);
    }

    public static ClaimsPrincipal SetClaimPrincipal(CustomUserClaims claims)
    {
        if (claims.email is null) return new ClaimsPrincipal();
        return new ClaimsPrincipal(new ClaimsIdentity(
            new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, claims.id!),
                new(ClaimTypes.Name, claims.Name!),
                new(ClaimTypes.Email, claims.email!),
                new(ClaimTypes.Role, claims.role!)
            }, "JwtAuth"));   
    }
}
