using Microsoft.AspNetCore.Server.Kestrel.Core;
using Tecan.Sila2;
using Tecan.Sila2.Server;
using Terminal.Angular;
using Terminal.Angular.HubConfig;


var serverInfo = ServerConfigReader.ReadServerStartInformation();
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Host.UseDryIoc(container =>
{
    container.LoadComponentsFromApplicationDirectory();
    container.AddSila2Defaults();
});

builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();
builder.Services.AddSila2();

builder.WebHost.ConfigureKestrelForSila2(serverInfo, options =>
{
    // you can also set this to Http1AndHttp2 but then Http2 only works with Https
    options.Protocols = HttpProtocols.Http1AndHttp2;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapSila2();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");
app.MapHub<TerminalHub>("/hub");

app.MapFallbackToFile("index.html"); ;

foreach (var service in app.Services.GetServices<IIntegrationComponent>())
{
    service.Start();
}
app.Run();
