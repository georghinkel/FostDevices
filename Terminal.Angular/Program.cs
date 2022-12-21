using Microsoft.AspNetCore.Server.Kestrel.Core;
using Tecan.Sila2;
using Tecan.Sila2.Server;
using Terminal.Angular;
using Terminal.Angular.HubConfig;


var serverInfo = new ServerStartInformation(new ServerInformation("Terminal", "", "", "0.1"), 7029);
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Host.UseDryIoc(container =>
{
    container.LoadComponentsFromApplicationDirectory();
    container.AddSila2Defaults();
});

builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();
builder.Services.AddSila2(serverInfo);

builder.Services.AddCors(options =>
{
    options.AddPolicy("ProxyCorsPolicy", builder => builder
        .WithOrigins("https://localhost:44494")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());
});

builder.Services.AddTransient<IIntegrationComponent, HubSetup>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseCors("ProxyCorsPolicy");
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapSila2();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");
app.MapHub<TerminalHub>("/hub");

app.MapFallbackToFile("index.html");

foreach (var service in app.Services.GetServices<IIntegrationComponent>())
{
    service.Start();
}
app.Run();
