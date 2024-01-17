using BlazorShop.Api.Context;
using BlazorShop.Api.Repositories;
using BlazorShop.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

string ConnetionDbString = builder.Configuration.GetConnectionString("dev") ?? "server=localhost;user=dev;password=1234;database=AppDbContext";
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseMySql(ConnetionDbString, ServerVersion.AutoDetect(ConnetionDbString));
});

builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors(policy =>
{
    policy.
    WithOrigins("https://localhost:7289", "http://localhost:5141").
    AllowAnyMethod().
    AllowAnyHeader().
    WithHeaders(HeaderNames.ContentType);
});
app.Run();