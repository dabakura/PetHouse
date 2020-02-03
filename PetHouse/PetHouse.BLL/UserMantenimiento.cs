using PetHouse.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PetHouse.BLL.Models;
using PetHouse.BLL.Mappers;

namespace PetHouse.BLL
{
    public class UserMantenimiento
    {
        public async Task<IEnumerable<Rol>> MethodAsync()
        {
            PetHouseModel DB = new PetHouseModel();
            var roles = await DB.AspNetRoles.ToListAsync();
            return from r in roles
                   select RolesMapper.Map(r);
           // return DB.AspNetRoles.Select(r => new RolesMapper(r));
        }
    }
}
