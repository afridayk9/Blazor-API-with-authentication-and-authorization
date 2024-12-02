using Blazored.Toast.Services;
using Blazored.Toast;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using TfdThreeTier.Client;
using TfdThreeTier.Client.Interfaces;
using TfdThreeTier.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//connects the client to the api server
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7139") });

builder.Services.AddScoped<ICharacterService, CharacterService>();
builder.Services.AddScoped<IComponentService, ComponentService>();
builder.Services.AddScoped<IMaterialService, MaterialService>();
builder.Services.AddScoped<IPatternService, PatternService>();

builder.Services.AddScoped<BlazoredToast>();
builder.Services.AddScoped<IToastService, ToastService>();
builder.Services.AddRadzenComponents();

await builder.Build().RunAsync();
