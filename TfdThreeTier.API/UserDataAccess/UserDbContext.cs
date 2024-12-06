using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace TfdThreeTier.API.UserDataAccess;

public class UserDbContext : IdentityDbContext
{
    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
    {
    }

}