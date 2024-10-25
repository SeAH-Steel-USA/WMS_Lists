using Microsoft.EntityFrameworkCore;
using WMS_Lists.Client.Pages;
using WMS_Lists.Components;
using WMS_Lists.Data;
using WMS_Lists.Services;
using MudBlazor.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebApplication.CreateBuilder(args);

//builder.WebHost.UseUrls("http://0.0.0.0:5000");

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddScoped<DataService>();

builder.Services.AddMudServices();

var DefaultConnectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(DefaultConnectionString));

var SecondConnectionString = builder.Configuration.GetConnectionString("SecondConnection")
    ?? throw new InvalidOperationException("Connection string 'SecondConnection' not found.");
builder.Services.AddDbContext<MAIRDbContext>(options =>
    options.UseSqlServer(SecondConnectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(WMS_Lists.Client._Imports).Assembly);

app.Run();
