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
    public class ProcedimientoRepositorio : DBContext, IProcedimientoService
    {
        public bool Delete(string id)
        {
            try
            {
                DB.EliminarProcedimiento(Convert.ToInt32(id));
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Procedimiento Get(string id)
        {
            try
            {
                var ProcedimientoResult = DB.BuscarProcedimiento(Convert.ToInt32(id)).SingleOrDefault();
                return mapper.Map<Procedimiento>(ProcedimientoResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Procedimiento> GetAll()
        {
            try
            {
                var ProcedimientosResult = DB.ConsultarProcedimiento().ToList();
                var Procedimientos = mapper.Map<IEnumerable<ConsultarProcedimientoResult>, IEnumerable<Procedimiento>>(ProcedimientosResult);
                return Procedimientos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Procedimiento> GetAllByIdExpediente(string id)
        {
            try
            {
                var ProcedimientosResult = DB.ConsultarProcedimientoById(id).ToList();
                var Procedimientos = mapper.Map<IEnumerable<ConsultarProcedimientoByIdResult>, IEnumerable<Procedimiento>>(ProcedimientosResult);
                return Procedimientos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Procedimiento Insert(Procedimiento entity)
        {
            try
            {
                var id = DB.InsertarProcedimiento(entity.ExpedienteId, entity.EmpleadoId, entity.Nombre_Procedimiento, entity.Descripcion).SingleOrDefault().Column1;
                var ProcedimientoResult = DB.BuscarProcedimiento(Convert.ToInt32(id)).SingleOrDefault();
                var Procedimiento = mapper.Map<BuscarProcedimientoResult, Procedimiento>(ProcedimientoResult);
                return Procedimiento;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(Procedimiento entity)
        {
            try
            {
                DB.ActualizarProcedimiento(entity.Id, entity.ExpedienteId, entity.EmpleadoId, entity.Nombre_Procedimiento, entity.Descripcion);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
