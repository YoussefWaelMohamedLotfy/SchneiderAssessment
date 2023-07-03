using HR.Razor.Components;
using HR.SDK;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHRApiClients(o => o.BaseUrl = "https://localhost:7245/api");

await builder.Build().RunAsync();
