using Endpoint.Application.Mapping;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Queries.Core;
using Queries.Persistence;

var builder = WebApplication.CreateBuilder(args);

#region Cors
// Tillader alle kald.
builder.Services.AddCors(options =>
{
    options.AddPolicy("policy",
        builder =>
        {
            builder
            .WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
        });
});
#endregion

#region Auth0
var domain = $"https://{builder.Configuration["Auth0:Domain"]}/";

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    options.Authority = domain;
    options.Audience = builder.Configuration["Auth0:Audience"];
    //options.TokenValidationParameters = new TokenValidationParameters
    //{
    //    NameClaimType = "name",
    //    RoleClaimType = "role",
    //};
});

#endregion

#region Database
builder.Services.AddDbContext<PlutoContext>(options =>
{
    // Tilf�j ConnectionString
    options.UseSqlServer(builder.Configuration.GetConnectionString("MathiasConnection")); 
    options.EnableSensitiveDataLogging();
});
#endregion

#region Controllers
// Tilf�j Controller.
builder.Services.AddControllers();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
#endregion

#region Automapper
//Tilf�jer AutoMapper.
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<MappingProfile>(); // Tilf�jer din MappingProfile
}, typeof(StartupBase));
#endregion

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

//Tilf�jer policy til app.
app.UseCors("policy");
app.UseAuthentication();
app.UseAuthorization(); 

app.MapControllers();

app.Run();
