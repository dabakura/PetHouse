using PetHouse.BLL.Models;
using PetHouse.DAL;
namespace PetHouse.BLL.Mappers
{
    public class InstitucionMapper
    {
        public static Institucion Map(InstitucionEntity institucion)
        {
            return new Institucion
            {
                Id = institucion.Id,
                Ced_Juridica = institucion.Ced_Juridica,
                Nombre = institucion.Nombre,
                Telefono = institucion.Telefono,
                Fax = institucion.Fax,
                Pag_Web = institucion.Pag_Web,
                Correo = institucion.Correo,
                Domicilio = DomicilioMapper.Map(institucion.Domicilio)
            };
        }

        public static InstitucionEntity Map(Institucion institucion)
        {
            return new InstitucionEntity
            {
                Id = institucion.Id,
                Ced_Juridica = institucion.Ced_Juridica,
                Nombre = institucion.Nombre,
                Telefono = institucion.Telefono,
                Fax = institucion.Fax,
                Pag_Web = institucion.Pag_Web,
                Correo = institucion.Correo,
                Domicilio = DomicilioMapper.Map(institucion.Domicilio),
                DireccionId = institucion.Domicilio.Id
            };
        }
    }
}
