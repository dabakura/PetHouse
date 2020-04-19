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
    public class TratamientoRepositorio : DBContext, ITratamientoService
    {
        public bool Delete(string id)
        {
            try
            {
                DB.EliminarTratamiento(Convert.ToInt32(id));
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Tratamiento Get(string id)
        {
            try
            {
                var TratamientoResult = DB.BuscarTratamiento(Convert.ToInt32(id)).SingleOrDefault();
                return mapper.Map<Tratamiento>(TratamientoResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Tratamiento> GetAll(string idExpediente)
        {
            try
            {
                var TratamientosResult = DB.ConsultarTratamiento(idExpediente).Where(a => a.Activo).ToList();
                var Tratamientos = mapper.Map<IEnumerable<ConsultarTratamientoResult>, IEnumerable<Tratamiento>>(TratamientosResult);
                return Tratamientos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Insert(Tratamiento entity)
        {
            try
            {
                var id = DB.InsertarTratamiento(entity.ExpedienteId, entity.EmpleadoId, entity.Descripcion, entity.Fecha).SingleOrDefault().Column1;
                return id.Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(Tratamiento entity)
        {
            try
            {
                DB.ActualizarTratamiento(entity.Id, entity.ExpedienteId, entity.EmpleadoId, entity.Descripcion, entity.Fecha);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
