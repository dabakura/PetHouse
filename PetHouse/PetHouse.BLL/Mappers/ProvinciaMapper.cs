using PetHouse.BLL.Models;
using PetHouse.DAL;
namespace PetHouse.BLL.Mappers
{
    public class ProvinciaMapper
    {
        public static Provincia Map(ProvinciaEntity provincia)
        {
            return new Provincia
            {
                Id = provincia.Id,
                Nombre = provincia.Nombre
            };
        }

        public static ProvinciaEntity Map(Provincia provincia)
        {
            return new ProvinciaEntity
            {
                Id = provincia.Id,
                Nombre = provincia.Nombre
            };
        }
    }
}
