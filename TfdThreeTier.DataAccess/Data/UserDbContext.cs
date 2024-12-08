using BaseLibrary.Entities;
using Microsoft.EntityFrameworkCore;

namespace TfdThreeTier.DataAccess.Data;
public class UserDbContext : DbContext
{
    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
    {
    }

    public DbSet<AppUser> AppUsers { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<SystemRoles> SystemRoles { get; set; }
    public DbSet<RefreshTokenInfo> RefreshTokenInfo { get; set; }
}
