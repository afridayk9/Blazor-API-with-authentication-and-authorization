using BaseLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TfdThreeTier.DataAccess.Interfaces;

public interface IUserRepository
{
    Task<List<AppUser>> GetAllAsync();
    Task<AppUser> GetByIdAsync(int id);
    Task<AppUser> CreateAsync(AppUser user);
    Task<AppUser> UpdateAsync(AppUser user);
    Task<bool> DeleteAsync(int id);
}
