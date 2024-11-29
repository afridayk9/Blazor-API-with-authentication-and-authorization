using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TfdThreeTier.BuisnessLogic.Entities;

namespace TfdThreeTier.DataAccess.Interfaces;
public interface IComponentRepo : IGenericRepo<Component>
{
    Task<List<Component>> GetComponentsByCharacterIdAsync(int characterId);

}
