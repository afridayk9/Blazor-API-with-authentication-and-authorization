using Blazored.LocalStorage;
using Blazored.Toast.Services;
using Blazored.Toast;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using TfdThreeTier.Client;
using TfdThreeTier.Client.Interfaces;
using TfdThreeTier.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using ClientLibrary.Helpers;
using ClientLibrary.Services.Interfaces;
using ClientLibrary.Services.Implementation;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication.Internal;
using System.Security.Claims;
using Microsoft.Extensions.Logging;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Logging configuration
builder.Logging.SetMinimumLevel(LogLevel.Debug);

// Connects the client to the API server
builder.Services.AddHttpClient("SystemApiClient", client =>
{
    client.BaseAddress = new Uri("https://localhost:7139/");
});

builder.Services.AddApiAuthorization();

builder.Services.AddAuthorizationCore();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<GetHttpClient>();
builder.Services.AddScoped<LocalStorageService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddScoped<IUserAccountService, UserAccountService>();

builder.Services.AddScoped<ICharacterService, CharacterService>();
builder.Services.AddScoped<IComponentService, ComponentService>();
builder.Services.AddScoped<IMaterialService, MaterialService>();
builder.Services.AddScoped<IPatternService, PatternService>();

builder.Services.AddScoped<BlazoredToast>();
builder.Services.AddScoped<IToastService, ToastService>();
builder.Services.AddRadzenComponents();

// Configure JWT authentication
builder.Services.AddOidcAuthentication(options =>
{
    builder.Configuration.Bind("JwtSection", options.ProviderOptions);
}).AddAccountClaimsPrincipalFactory<RemoteAuthenticationState, RemoteUserAccount, CustomAccountFactory>();

await builder.Build().RunAsync();

public class CustomAccountFactory : AccountClaimsPrincipalFactory<RemoteUserAccount>
{
    public CustomAccountFactory(IAccessTokenProviderAccessor accessor) : base(accessor)
    {
    }

    public override async ValueTask<ClaimsPrincipal> CreateUserAsync(RemoteUserAccount account, RemoteAuthenticationUserOptions options)
    {
        var user = await base.CreateUserAsync(account, options);
        if (user.Identity.IsAuthenticated)
        {
            var identity = (ClaimsIdentity)user.Identity;
            // Add custom claims here if needed
        }
        return user;
    }
}








