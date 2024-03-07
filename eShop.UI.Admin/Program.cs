using eShop.UI.Admin;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using eShop.UI.Admin.Services;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<UIAdminService>();
builder.Services.AddHttpClient<CategoryHttpClient>();
builder.Services.AddHttpClient<ProductHttpClient>();

ConfigureAutoMapper();

await builder.Build().RunAsync();

void ConfigureAutoMapper()
{
	var config = new MapperConfiguration(cfg =>
	{
		cfg.CreateMap<CategoryGetDTO, LinkOption>().ReverseMap();
		cfg.CreateMap<CarGetDTO, CartItemDTO>().ReverseMap();
	});
	var mapper = config.CreateMapper();
	builder.Services.AddSingleton(mapper);
}