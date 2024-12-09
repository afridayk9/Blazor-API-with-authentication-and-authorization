using BaseLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TfdThreeTier.DataAccess.Data;
using TfdThreeTier.DataAccess.Interfaces;

public class UserRoleRepository : IUserRoleRepository
{
    private readonly UserDbContext _context;

    public UserRoleRepository(UserDbContext context)
    {
        _context = context;
    }

    public async Task<List<UserRole>> GetAllAsync()
    {
        return await _context.UserRoles.ToListAsync();
    }

    public async Task<UserRole> GetByIdAsync(int id)
    {
        return await _context.UserRoles.FindAsync(id);
    }

    public async Task<UserRole> CreateAsync(UserRole userRole)
    {
        _context.UserRoles.Add(userRole);
        await _context.SaveChangesAsync();
        return userRole;
    }

    public async Task<UserRole> UpdateAsync(UserRole userRole)
    {
        _context.UserRoles.Update(userRole);
        await _context.SaveChangesAsync();
        return userRole;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var userRole = await _context.UserRoles.FindAsync(id);
        if (userRole == null)
        {
            return false;
        }

        _context.UserRoles.Remove(userRole);
        await _context.SaveChangesAsync();
        return true;
    }
}

