using Microsoft.Extensions.Configuration;
using Test.Repositoris.Imprements;
using Test.Repositoris.Interfaces;
using Test.Services.Imprements;
using Test.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddScoped<IBaseRepository, BaseRepository>(c => new BaseRepository(builder.Configuration.GetConnectionString("MSSQL")));

builder.Services.AddScoped<IShopService, ShopService>();
builder.Services.AddScoped<IAccountService, AccountService>();

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

app.UseAuthorization();

app.UseEndpoints(endpoints => {
    endpoints.MapControllers();
});

app.Run();
