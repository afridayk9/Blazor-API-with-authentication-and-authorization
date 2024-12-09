using BaseLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TfdThreeTier.DataAccess.Data;
using TfdThreeTier.DataAccess.Interfaces;

public class RoleRepository : IRoleRepository
{
    private readonly UserDbContext _context;

    public RoleRepository(UserDbContext context)
    {
        _context = context;
    }

    public async Task<List<SystemRoles>> GetAllAsync()
    {
        return await _context.SystemRoles.ToListAsync();
    }

    public async Task<SystemRoles> GetByIdAsync(int id)
    {
        return await _context.SystemRoles.FindAsync(id);
    }

    public async Task<SystemRoles> CreateAsync(SystemRoles role)
    {
        _context.SystemRoles.Add(role);
        await _context.SaveChangesAsync();
        return role;
    }

    public async Task<SystemRoles> UpdateAsync(SystemRoles role)
    {
        _context.SystemRoles.Update(role);
        await _context.SaveChangesAsync();
        return role;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var role = await _context.SystemRoles.FindAsync(id);
        if (role == null)
        {
            return false;
        }

        _context.SystemRoles.Remove(role);
        await _context.SaveChangesAsync();
        return true;
    }
}
