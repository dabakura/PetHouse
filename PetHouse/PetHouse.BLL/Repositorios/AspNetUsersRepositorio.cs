using PetHouse.BLL.Services;
using PetHouse.BLL.Mappers;
using PetHouse.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHouse.BLL.Repositorios
{
    public class AspNetUsersRepositorio : DBContext, IAspNetUsersService
    {
        public IEnumerable<AspNetUsers> GetAll()
        {
            try
            {
                var UsersResult = DB.ConsultarUser().ToList();
                var Users = mapper.Map<IEnumerable<ConsultarUserResult>, IEnumerable<AspNetUsers>>(UsersResult);
                return Users;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
