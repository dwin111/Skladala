using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Skladala.View;
using Skladala.View.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
 builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(@"https://localhost:7227") });

builder.Services.AddTransient<FoodProductServices>();
builder.Services.AddTransient<NonfoodProductServices>();
builder.Services.AddTransient<ProductServices>();


await builder.Build().RunAsync();
