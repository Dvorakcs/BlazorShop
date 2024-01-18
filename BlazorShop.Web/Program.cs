using BlazorShop.Web;
using BlazorShop.Web.Services;
using BlazorShop.Web.Services.Interfaces;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
var baseURL = "https://localhost:7181";
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseURL) });
builder.Services.AddScoped<IProdutosServices, ProdutosServices>();
builder.Services.AddScoped<ICatologoServices, CatologoServices>();
await builder.Build().RunAsync();
