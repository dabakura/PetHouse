using PetHouse.BLL.Models;
using PetHouse.DAL;
namespace PetHouse.BLL.Mappers
{
    public class DistritoMapper
    {
        public static Distrito Map(DistritoEntity distrito)
        {
            return new Distrito
            {
                Id = distrito.Id,
                Nombre = distrito.Nombre
            };
        }

        public static DistritoEntity Map(Distrito distrito)
        {
            return new DistritoEntity
            {
                Id = distrito.Id,
                Nombre = distrito.Nombre
            };
        }
    }
}
