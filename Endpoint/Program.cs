using Endpoint.Mapping;
using Endpoint.Repository.Database;
using Endpoint.Repository.Repositories;
using Endpoint.Utilities.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Tilf�j Controller.
builder.Services.AddControllers();
builder.Services.AddScoped<IRepo, Repo>();

//Tilf�jer AutoMapper.
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<MappingProfile>(); // Tilf�jer din MappingProfile
}, typeof(StartupBase));

// Tilf�jer databasen.
builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MathiasConnection")); // Tilf�j ConnectionString
});

// Tillader alle kald.
builder.Services.AddCors(options =>
{
    options.AddPolicy("policy",
        builder =>
        {
            builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        });
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

//Tilf�jer policy til app.
app.UseCors("policy");


app.MapControllers();

app.Run();
