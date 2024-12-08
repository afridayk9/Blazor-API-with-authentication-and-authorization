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

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Connects the client to the API server
builder.Services.AddHttpClient("TfdThreeTier.ServerAPI", client => client.BaseAddress = new Uri("https://localhost:7139/"))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("TfdThreeTier.API"));

builder.Services.AddApiAuthorization();

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<ICharacterService, CharacterService>();
builder.Services.AddScoped<IComponentService, ComponentService>();
builder.Services.AddScoped<IMaterialService, MaterialService>();
builder.Services.AddScoped<IPatternService, PatternService>();

builder.Services.AddScoped<BlazoredToast>();
builder.Services.AddScoped<IToastService, ToastService>();
builder.Services.AddRadzenComponents();



await builder.Build().RunAsync();




