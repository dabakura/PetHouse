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
    public class InstitucionRepositorio : DBContext, IIntitucionService
    {
        public IEnumerable<Institucion> GetAll()
        {
            try
            {
                var InstitucionesResult = DB.ConsultarInstitucion().ToList();
                var Instituciones = mapper.Map<IEnumerable<ConsultarInstitucionResult>, IEnumerable<Institucion>>(InstitucionesResult);
                return Instituciones;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
