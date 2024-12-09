using BaseLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TfdThreeTier.DataAccess.Data;
using TfdThreeTier.DataAccess.Interfaces;

namespace TfdThreeTier.DataAccess.Repositiories;
public class UserRepository : IUserRepository
{
    private readonly UserDbContext _context;

    public UserRepository(UserDbContext context)
    {
        _context = context;
    }

    public async Task<List<AppUser>> GetAllAsync()
    {
        return await _context.AppUsers.ToListAsync();
    }

    public async Task<AppUser> GetByIdAsync(int id)
    {
        return await _context.AppUsers.FindAsync(id);
    }

    public async Task<AppUser> CreateAsync(AppUser user)
    {
        _context.AppUsers.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<AppUser> UpdateAsync(AppUser user)
    {
        _context.AppUsers.Update(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var user = await _context.AppUsers.FindAsync(id);
        if (user == null)
        {
            return false;
        }

        _context.AppUsers.Remove(user);
        await _context.SaveChangesAsync();
        return true;
    }
}