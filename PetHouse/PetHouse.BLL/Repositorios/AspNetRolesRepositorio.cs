using PetHouse.BLL.Services;
using PetHouse.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHouse.BLL.Repositorios
{
    public class AspNetRolesRepositorio : DBContext, IRoleService
    {

        public AspNetRoles Get(string id)
        {
            try
            {
                var rolResult = DB.BuscarRol(id).SingleOrDefault();
                return mapper.Map<AspNetRoles>(rolResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<AspNetRoles> GetAll()
        {
            try
            {
                var RolesResult = DB.ConsultarRol().ToList();
                var Roles = mapper.Map<IEnumerable<ConsultarRolResult>, IEnumerable<AspNetRoles>>(RolesResult);
                return Roles;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(AspNetRoles entity)
        {
            try
            {
                DB.ActualizarRol(entity.Id, entity.Name);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
