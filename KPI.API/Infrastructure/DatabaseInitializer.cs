using KPI.Core.Entities;
using KPI.Core.Interfaces;
using KPI.Data;
using Microsoft.EntityFrameworkCore;

namespace KPI.API.Infrastructure;

public static class DatabaseInitializer
{
    public static async Task InitializeAsync(IServiceProvider services, IConfiguration configuration)
    {
        await using var scope = services.CreateAsyncScope();
        var context = scope.ServiceProvider.GetRequiredService<KpiDbContext>();
        var passwordHasher = scope.ServiceProvider.GetRequiredService<IPasswordHasher>();

        await context.Database.MigrateAsync();

        var adminEmail = configuration["AdminUser:Email"];
        var adminPassword = configuration["AdminUser:Password"];
        var adminFirstName = configuration["AdminUser:FirstName"] ?? "System";
        var adminLastName = configuration["AdminUser:LastName"] ?? "Administrator";

        if (string.IsNullOrWhiteSpace(adminEmail) || string.IsNullOrWhiteSpace(adminPassword))
        {
            return;
        }

        var existingAdmin = await context.Users.FirstOrDefaultAsync(user => user.Email == adminEmail);
        if (existingAdmin is not null)
        {
            return;
        }

        var adminUser = new User
        {
            FirstName = adminFirstName,
            LastName = adminLastName,
            Email = adminEmail,
            PasswordHash = passwordHasher.Hash(adminPassword),
            IsActive = true,
            UserRoles = new List<UserRole>
            {
                new() { RoleId = 1 }
            }
        };

        context.Users.Add(adminUser);
        await context.SaveChangesAsync();
    }
}
