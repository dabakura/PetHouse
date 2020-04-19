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
    public class EmpleadoRepositorio : DBContext, IEmpleadoService
    {
        public bool Delete(string id)
        {
            try
            {
                DB.EliminarEmpleado(Convert.ToInt32(id));
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Empleado Get(string id)
        {
            try
            {
                var EmpleadoResult = DB.BuscarEmpleado(Convert.ToInt32(id)).SingleOrDefault();
                return mapper.Map<Empleado>(EmpleadoResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Empleado> GetAll()
        {
            try
            {
                var EmpleadosResult = DB.ConsultarEmpleado().ToList();
                var Empleados = mapper.Map<IEnumerable<ConsultarEmpleadoResult>, IEnumerable<Empleado>>(EmpleadosResult);
                return Empleados.Where(a => a.Activo.Value).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Insert(Empleado entity)
        {
            try
            {
                var id = DB.InsertarEmpleado(entity.Identificacion, entity.Nombre, entity.Primer_Apellido, entity.Segundo_Apellido, entity.Fecha_Nacimiento, entity.Telefono, entity.Correo, entity.DomicilioId, entity.PuestoID, entity.InstitucionId, entity.UserId).SingleOrDefault().Column1;
                return id.Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(Empleado entity)
        {
            try
            {
                DB.ActualizarEmpleado(entity.Identificacion, entity.Nombre, entity.Primer_Apellido, entity.Segundo_Apellido, entity.Fecha_Nacimiento, entity.Telefono, entity.Correo, entity.DomicilioId, entity.PuestoID, entity.InstitucionId, entity.UserId);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
