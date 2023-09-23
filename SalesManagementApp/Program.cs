using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using SalesManagement.Data.Context;
using SalesManagementApp.Data;

//
using Syncfusion.Blazor;


var builder = WebApplication.CreateBuilder(args);

#region DATA BASE CONTEXT SALESMANAGEMENTDB

builder.Services.AddDbContext<SalesManagementDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("SalesManagementDbConnection")
        ?? throw new InvalidOperationException("Connection 'SalesManagementDbConnection' not found ")
        );
});

#endregion

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

// Syncfusion Blazor Package
builder.Services.AddSyncfusionBlazor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
