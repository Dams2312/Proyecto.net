using Api.Security;
using Application.Abstractions;
using Domain.Entities.Roles;
using Domain.Entities.Users;
using Domain.ValueObject.Role;
using Domain.ValueObject.Users;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Api.Infrastructure;

public static class DatabaseSeeder
{
    public static async Task SeedAuthAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        var passwordHashService = scope.ServiceProvider.GetRequiredService<IPasswordHashService>();

        await EnsureRoleAsync(context, RoleNames.Admin, "Acceso total al sistema.");
        await EnsureRoleAsync(context, RoleNames.Mecanico, "Gestion de ordenes y facturas.");
        await EnsureRoleAsync(context, RoleNames.Recepcionista, "Gestion de clientes, vehiculos y citas.");

        var roles = await context.Roles.ToListAsync();
        var adminRole = roles.First(x => x.Name.Value == RoleNames.Admin);
        const string adminEmail = "admin@autotaller.local";
        var users = await context.Users.ToListAsync();
        var adminExists = users.Any(x => x.Mail.Value == adminEmail);

        if (adminExists)
            return;

        var admin = new User(
            UsersCode.Create("ADMIN001"),
            UsersNames.Create("Administrador"),
            UsersSurnames.Create("Sistema"),
            UsersMail.Create(adminEmail),
            UsersPassword.Create(passwordHashService.HashPassword("Admin123*")),
            UsersActive.Create(true),
            UsersCreateDate.Create(DateTime.UtcNow),
            UsersFinishDate.Create(DateTime.UtcNow.AddYears(100)),
            UsersrolId.Create(adminRole.Id));

        context.Users.Add(admin);
        await context.SaveChangesAsync();
    }

    private static async Task EnsureRoleAsync(AppDbContext context, string name, string description)
    {
        var roles = await context.Roles.ToListAsync();
        var exists = roles.Any(x => x.Name.Value == name);
        if (exists)
            return;

        context.Roles.Add(new Role(RoleName.Create(name), RoleDescription.Create(description)));
        await context.SaveChangesAsync();
    }
}
