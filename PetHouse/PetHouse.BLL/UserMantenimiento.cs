using PetHouse.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace PetHouse.BLL
{
    public class UserMantenimiento
    {
        public async Task<IEnumerable<RolesMapper>> MethodAsync()
        {
            PetHouseModel DB = new PetHouseModel();
            var roles = await DB.AspNetRoles.ToListAsync();
            return from r in roles
                   select new RolesMapper(r);
           // return DB.AspNetRoles.Select(r => new RolesMapper(r));
        }
    }
}
