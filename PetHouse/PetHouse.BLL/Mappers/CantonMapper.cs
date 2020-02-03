using PetHouse.BLL.Models;
using PetHouse.DAL;
namespace PetHouse.BLL.Mappers
{
    public class CantonMapper
    {
        public static Canton Map(CantonEntity canton)
        {
            return new Canton
            {
                Id = canton.Id,
                Nombre = canton.Nombre
            };
        }

        public static CantonEntity Map(Canton canton)
        {
            return new CantonEntity
            {
                Id = canton.Id,
                Nombre = canton.Nombre
            };
        }
    }
}
