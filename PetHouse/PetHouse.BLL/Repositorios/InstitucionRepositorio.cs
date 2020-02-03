using PetHouse.BLL.Interfaces;
using PetHouse.BLL.Mappers;
using PetHouse.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace PetHouse.BLL.Repositorios
{
    public class InstitucionRepositorio : DBContext, IIntitucion
    {
        public async Task<IEnumerable<Institucion>> GetAllAsync()
        {
            try
            {
                var InstitucionesEntities = await DB.Instituciones
                .Include(i => i.Domicilio)
                .Include(i => i.Domicilio.Canton)
                .Include(i => i.Domicilio.Provincia)
                .Include(i => i.Domicilio.Distrito)
                .Where(InstitucionEntity => InstitucionEntity.Estado.Value)
                .ToListAsync();
                var Instituciones = from insti in InstitucionesEntities
                                    select InstitucionMapper.Map(insti);
                return Instituciones;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
