using Autofac;
using Autofac.Extensions.DependencyInjection;
using BOSSAProje.Contexts;
using BOSSAProje.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();

builder.Services.AddSession(); // SONRADAN EKLENDÝ

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(b => b.RegisterModule(new AutofacBusinessModule()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=LoginPage}/{id?}");


app.UseSession(); //SONRADAN EKLENDÝ
app.Run();








