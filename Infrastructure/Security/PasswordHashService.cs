using Application.Abstractions;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Security;

public sealed class PasswordHashService : IPasswordHashService
{
    private readonly PasswordHasher<object> _passwordHasher = new();
    private static readonly object User = new();

    public string HashPassword(string password)
    {
        return _passwordHasher.HashPassword(User, password);
    }

    public bool VerifyPassword(string passwordHash, string password)
    {
        var result = _passwordHasher.VerifyHashedPassword(User, passwordHash, password);
        return result is PasswordVerificationResult.Success or PasswordVerificationResult.SuccessRehashNeeded;
    }
}
