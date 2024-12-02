using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TfdThreeTier.BuisnessLogic.DTOs;
using TfdThreeTier.BuisnessLogic.Entities.JoinTables;

namespace TfdThreeTier.DataAccess.Interfaces;
public interface IComponentMaterialRepo
{
    Task<ComponentMaterial> CreateAsync(ComponentMaterial entity);
    Task<ComponentMaterial> GetByIdAsync(int id);
    Task<List<ComponentMaterial>> GetAllAsync();
    Task<ServiceResponse> DeleteAsync(int id);
    Task<ServiceResponse> UpdateAsync(ComponentMaterial entity);
    Task<List<ComponentMaterial>> GetComponentMaterialsByComponentIdAsync(int componentId);
}