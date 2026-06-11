using Api.Dtos.Auth;
using Api.Dtos.Users;
using Api.Security;
using Application.Abstractions;
using Domain.ValueObject.Users;
using Infrastructure.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[AllowAnonymous]
public sealed class AuthController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IPasswordHashService _passwordHashService;
    private readonly JwtTokenService _jwtTokenService;

    public AuthController(
        AppDbContext context,
        IPasswordHashService passwordHashService,
        JwtTokenService jwtTokenService)
    {
        _context = context;
        _passwordHashService = passwordHashService;
        _jwtTokenService = jwtTokenService;
    }

    [HttpPost("login")]
    [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginRequest request, CancellationToken ct)
    {
        var email = UsersMail.Create(request.Email).Value;
        var users = await _context.Users.ToListAsync(ct);
        var user = users.FirstOrDefault(x => x.Mail.Value == email);

        if (user is null || !user.Active.Value)
            return Unauthorized(new { message = "Credenciales invalidas." });

        var passwordIsValid = _passwordHashService.VerifyPassword(user.Password.Value, request.Password);
        if (!passwordIsValid && user.Password.Value == request.Password)
        {
            user.UpdatePassword(UsersPassword.Create(_passwordHashService.HashPassword(request.Password)));
            await _context.SaveChangesAsync(ct);
            passwordIsValid = true;
        }

        if (!passwordIsValid)
            return Unauthorized(new { message = "Credenciales invalidas." });

        var roles = await _context.Roles.ToListAsync(ct);
        var role = roles.FirstOrDefault(x => x.Id == user.RoleId.Value);
        if (role is null)
            return Unauthorized(new { message = "El usuario no tiene un rol valido." });

        var (token, expiresAt) = _jwtTokenService.CreateToken(user, role.Name.Value);

        return Ok(new LoginResponse
        {
            Token = token,
            Expiration = expiresAt,
            User = new UserDto
            {
                Id = user.Id,
                RoleId = user.RoleId.Value,
                Email = user.Mail.Value,
                Names = user.Names.Value,
                LastNames = user.Surnames.Value,
                Active = user.Active.Value,
                CreatedAt = user.CreateDate.Value
            }
        });
    }
}
