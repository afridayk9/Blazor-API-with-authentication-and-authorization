using BaseLibrary.DTOs;
using BaseLibrary.Entities;
using BaseLibrary.Responses;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using TfdThreeTier.DataAccess.Data;
using TfdThreeTier.DataAccess.Helper;
using TfdThreeTier.DataAccess.Interfaces;

namespace TfdThreeTier.DataAccess.Repositiories;
public class UserAccountRepo(IOptions<JwtSection> config, UserDbContext userDbContext) : IUserAccount
{
    public async Task<GeneralResponse> CreateAsync(Register user)
    {
        if (user is null) return new GeneralResponse(false, "User is null");

        var checkUser = await FindUserByEmail(user.Email!);
        if (checkUser != null) return new GeneralResponse(false, "User already exists");

        var appUser = await AddToDatabase(new AppUser()
        {
            Name = user.Name,
            Email = user.Email,
            Password = BCrypt.Net.BCrypt.HashPassword(user.Password)
        });

        var checkAdminRole = await userDbContext.SystemRoles.FirstOrDefaultAsync(r => r.RoleName!.Equals(Constants.Admin));
        if (checkAdminRole == null)
        {
            var createAdminRole = await AddToDatabase(new SystemRoles() { RoleName = Constants.Admin });
            await AddToDatabase(new UserRole() { RoleId = createAdminRole.Id, UserId = appUser.Id });
            return new GeneralResponse(true, "User created successfully");
        }

        var checkUserRole = await userDbContext.SystemRoles.FirstOrDefaultAsync(r => r.RoleName!.Equals(Constants.User));
        SystemRoles response = new();
        if (checkUserRole is null)
        {
            response = await AddToDatabase(new SystemRoles() { RoleName = Constants.User });
            await AddToDatabase(new UserRole() { RoleId = response.Id, UserId = appUser.Id });
        }
        else
        {
            await AddToDatabase(new UserRole() { RoleId = checkUserRole.Id, UserId = appUser.Id });
        }
        return new GeneralResponse(true, "User created successfully");
    }

    public async Task<LoginResponse> SignInAsync(Login user)
    {
        if (user is null) return new LoginResponse(false, "User is null");

        var appUser = await FindUserByEmail(user.Email!);
        if (appUser is null) return new LoginResponse(false, "User not found");

        if (!BCrypt.Net.BCrypt.Verify(user.Password, appUser.Password))
            return new LoginResponse(false, "Invalid Email/Password");

        var getUserRole = await FindUserRole(appUser.Id);
        if (getUserRole is null) return new LoginResponse(false, "User role not found");

        var getRoleName = await FindRoleName(getUserRole.RoleId);
        if (getRoleName is null) return new LoginResponse(false, "Role not found");

        string jwtToken = GenerateToken(appUser, getRoleName!.RoleName!);
        string refreshToken = GenerateRefreshToken();

        var findUser = await userDbContext.RefreshTokenInfo.FirstOrDefaultAsync(u => u.UserId == appUser.Id);
        if (findUser is not null)
        {
            findUser!.Token = refreshToken;
            await userDbContext.SaveChangesAsync();
        }
        else
        {
            await AddToDatabase(new RefreshTokenInfo() { Token = refreshToken, UserId = appUser.Id });
        }

        return new LoginResponse(true, "Login Success", jwtToken, refreshToken);
    }

    private async Task<AppUser> FindUserByEmail(string email) =>
        await userDbContext.AppUsers.FirstOrDefaultAsync(u => u.Email!.ToLower()!.Equals(email!.ToLower())); 
        
    

    private async Task<T> AddToDatabase<T>(T model)
    {
        var result = userDbContext.Add(model!);
        await userDbContext.SaveChangesAsync();
        return (T)result.Entity;
    }

    private string GenerateToken(AppUser user, string role)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.Value.Key!));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var userClaims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Name!),
            new Claim(ClaimTypes.Email, user.Email!),
            new Claim(ClaimTypes.Role, role!)
        };
        var token = new JwtSecurityToken(
            issuer: config.Value.Issuer,
            audience: config.Value.Audience,
            claims: userClaims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: credentials
        );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private static string GenerateRefreshToken() => Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));

    private async Task<UserRole> FindUserRole(int userId) =>
        await userDbContext.UserRoles.FirstOrDefaultAsync(u => u.UserId == userId);

    private async Task<SystemRoles> FindRoleName(int? roleId) =>
        await userDbContext.SystemRoles.FirstOrDefaultAsync(r => r.Id == roleId);

    public async Task<LoginResponse> RefreshTokenAsync(RefreshToken token)
    {
        if (token is null) return new LoginResponse(false, "Token is null in RefreshTokenAsync");

        var findToken = await userDbContext.RefreshTokenInfo.FirstOrDefaultAsync(t => t.Token!.Equals(token.Token));
        if (findToken is null) return new LoginResponse(false, "Refresh Token not found");

        var user = await userDbContext.AppUsers.FirstOrDefaultAsync(u => u.Id == findToken.UserId);
        if (user is null) return new LoginResponse(false, "User not found in refreshTokenAsync");

        var userRole = await FindUserRole(user.Id);
        var roleName = await FindRoleName(userRole.RoleId);
        string jwtToken = GenerateToken(user, roleName.RoleName!);
        string refreshToken = GenerateRefreshToken();

        var updateRefreshToken = await userDbContext.RefreshTokenInfo.FirstOrDefaultAsync(u => u.UserId == user.Id);
        if (updateRefreshToken is null) return new LoginResponse(false, "Refresh Token not found in refreshTokenAsync");

        updateRefreshToken.Token = refreshToken;
        await userDbContext.SaveChangesAsync();
        return new LoginResponse(true, "Token Refreshed", jwtToken, refreshToken);
    }
}


