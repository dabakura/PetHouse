using PetHouse.DAL;
using PetHouse.BLL.Models;
namespace PetHouse.BLL.Mappers
{
    public class DomicilioMapper
    {
        public static Domicilio Map(DomicilioEntity domicilio)
        {
            return new Domicilio
            {
                Id = domicilio.Id,
                Direccion = domicilio.Direccion,
                Canton = CantonMapper.Map(domicilio.Canton),
                Distrito = DistritoMapper.Map(domicilio.Distrito),
                Provincia = ProvinciaMapper.Map(domicilio.Provincia)
            };
        }

        public static DomicilioEntity Map(Domicilio domicilio)
        {
            return new DomicilioEntity
            {
                Id = domicilio.Id,
                Direccion = domicilio.Direccion,
                Canton = CantonMapper.Map(domicilio.Canton),
                Distrito = DistritoMapper.Map(domicilio.Distrito),
                Provincia = ProvinciaMapper.Map(domicilio.Provincia),
                ProvinciaId = domicilio.Provincia.Id,
                CantonId = domicilio.Canton.Id,
                DistritoId = domicilio.Distrito.Id
            };
        }
    }
}