using Endpoint.Mapping;
using Endpoint.Repository.Database;
using Endpoint.Repository.Repositories;
using Endpoint.Utilities.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IRepo, Repo>();
builder.Services.AddAutoMapper(typeof(StartupBase));

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<MappingProfile>(); // Tilføjer din MappingProfile
}, typeof(StartupBase));

// Add services to the container.


builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MathiasConnection"));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();
