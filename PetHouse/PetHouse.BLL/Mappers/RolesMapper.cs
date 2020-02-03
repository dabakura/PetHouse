using PetHouse.BLL.Models;
using PetHouse.DAL;
namespace PetHouse.BLL.Mappers
{

    public class RolesMapper
    {
        public static Rol Map(AspNetRolesEntity rol)
        {
            return new Rol
            {
                Id = rol.Id,
                Name = rol.Name
            };
        }

        public static AspNetRolesEntity Map(Rol rol)
        {
            return new AspNetRolesEntity
            {
                Id = rol.Id,
                Name = rol.Name
            };
        }
    }
}
