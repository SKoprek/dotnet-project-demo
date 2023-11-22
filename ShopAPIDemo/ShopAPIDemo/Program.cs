using Microsoft.EntityFrameworkCore;
using ShopAPIDemo.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<WebAPIContext>(
    u => u.UseNpgsql(builder.Configuration.GetConnectionString("SampleDbConnection"))
    );



var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();
app.UseHttpsRedirection();
app.UseAuthentication();
app.MapGet("/", () => "Hello World!");
app.Run();
