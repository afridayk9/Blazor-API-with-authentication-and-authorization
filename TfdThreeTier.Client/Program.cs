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


builder.Services.AddTransient<CustomHttpHandler>();
// Connects the client to the API server
builder.Services.AddHttpClient("SystemApiClient", client =>
{
    client.BaseAddress = new Uri("https://localhost:7139/");
}).AddHttpMessageHandler<CustomHttpHandler>();

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
builder.Services.AddScoped<IUserDetailService, UserDetailService>();

builder.Services.AddScoped<BlazoredToast>();
builder.Services.AddScoped<IToastService, ToastService>();
builder.Services.AddRadzenComponents();



await builder.Build().RunAsync();









