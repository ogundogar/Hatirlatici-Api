using FluentValidation.AspNetCore;
using HatirlaticiAPI.Application;
using HatirlaticiAPI.Application.Validators.Users;
using HatirlaticiAPI.Infrastructure;
using HatirlaticiAPI.Infrastructure.Filters;
using HatirlaticiAPI.Infrastructure.Services.Storage.Local;
using HatirlaticiAPI.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers(options=>options.Filters.Add<ValidationFilter>())
    .AddFluentValidation(configurationExpression => configurationExpression.RegisterValidatorsFromAssemblyContaining<CreateUsersValidators>())
    .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);

builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));
//builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.WithOrigins("http://localhost:4200","https://localhost:4200").AllowAnyHeader().AllowAnyMethod()));

builder.Services.AddStorage<LocalStorage>();
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer("Admin",options =>
{
    options.TokenValidationParameters = new()
    {
        ValidateAudience= true,
        ValidateIssuer= true,
        ValidateLifetime= true,
        ValidateIssuerSigningKey= true,
        ValidAudience = builder.Configuration["Token:Audience"],
        ValidIssuer= builder.Configuration["Token:Issuer"],
        IssuerSigningKey =new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
        LifetimeValidator=(notBefore,  expires,  securityToken, validationParameters) =>expires!=null?expires>DateTime.UtcNow:false
    };
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();
app.UseCors();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
