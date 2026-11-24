using Hotelmanagement.api.Model;
using Hotelmanagement.api.Data;
using Microsoft.EntityFrameworkCore;

namespace Hotelmanagement.api.Seeders;

public static class  AdminSeeder
{
    public static async Task SeedAsync(IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        IConfiguration configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();

        // * Read admin details from configuration 

        var username = configuration["AdminSeed:UserName"];
        var email = configuration["AdminSeed:Email"];
        var password = configuration["AdminSeed:Password"];

        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email) ||
        string.IsNullOrWhiteSpace(password))
        {
            throw new InvalidOperationException(
                "Admin seed configuration is missing.");
        }
        var adminExists  = await context.Users.AnyAsync(u=>u.Email==email);
        if  (adminExists )
        {
            return;
        }
        var hashPassword = BCrypt.Net.BCrypt.HashPassword(password);
        var admin = new User
        {
            UserName = username,
            PasswordHash = hashPassword,
            Role = Role.Admin,
            Email = email
        };
        await context.AddAsync(admin);
        await context.SaveChangesAsync();
    }
}
