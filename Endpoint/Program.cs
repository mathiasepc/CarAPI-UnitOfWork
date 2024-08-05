using Endpoint.Application.Mapping;
using Endpoint.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Queries.Core;
using Queries.Core.IRepositories;
using Queries.Persistence;
using Queries.Persistence.Repositories;

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
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("read:messages", policy => policy.Requirements.Add(new HasScopeRequirement("read:messages", domain)));
});
#endregion

#region Database
builder.Services.AddDbContext<PlutoContext>(options =>
{
    // Tilføj ConnectionString
    options.UseSqlServer(builder.Configuration.GetConnectionString("MathiasConnection")); 
    options.EnableSensitiveDataLogging();
});
#endregion

#region Controllers
// Tilføj Controller.
builder.Services.AddControllers();
builder.Services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();
builder.Services.AddScoped<IVehicleRepo, VehicleRepo>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
#endregion

#region Automapper
//Tilføjer AutoMapper.
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<MappingProfile>(); // Tilføjer din MappingProfile
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

//Tilføjer policy til app.
app.UseCors("policy");
app.UseAuthentication();
app.UseAuthorization(); 

app.MapControllers();

app.Run();
