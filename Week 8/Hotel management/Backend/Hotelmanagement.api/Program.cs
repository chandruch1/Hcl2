using Scalar.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Hotelmanagement.api.Data;
using Hotelmanagement.api.Seeders;
using Microsoft.AspNetCore.Components.RenderTree;
using Hotelmanagement.api.Services.Interfaces;
using Hotelmanagement.api.Services.Services;
using Hotelmanagement.api.Repositories.Interfaces;


var builder = WebApplication.CreateBuilder(args);

//DataBase connection
builder.Services.AddDbContext<AppDbContext>(option =>
    option.UseSqlServer(
            builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

//* Dependenct Injection
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IAuthRepo, AuthRepo>();
builder.Services.AddScoped<IJwtService, JwtServices>();

//* Register controllers
builder.Services.AddControllers();

// ! JWT key must be kept secret
// ! Never commit production secrets to GitHub

var jwtKey = builder.Configuration["Jwt:Key"]
    ?? throw new InvalidOperationException("JWT Key is missing");

var jwtIssuer = builder.Configuration["Jwt:Issuer"];
var jwtAudience = builder.Configuration["Jwt:Audience"];

// Register Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme =
        JwtBearerDefaults.AuthenticationScheme;

    options.DefaultChallengeScheme =
        JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = jwtIssuer,
        ValidAudience = jwtAudience,

        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(jwtKey)
        )
    };
});
builder.Services.AddAuthorization();


builder.Services.AddOpenApi();

var app = builder.Build();

//* Seeder logic
await AdminSeeder.SeedAsync(app.Services);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}
// Https Middleware
app.UseHttpsRedirection();


//* Jwt Adding
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();


