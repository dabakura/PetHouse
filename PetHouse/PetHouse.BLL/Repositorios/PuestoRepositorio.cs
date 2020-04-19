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
    public class PuestoRepositorio : DBContext, IPuestoService
    {
        public bool Delete(string id)
        {
            try
            {
                DB.EliminarPuesto(Convert.ToInt32(id));
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Puesto Get(string id)
        {
            try
            {
                var PuestoResult = DB.BuscarPuesto(Convert.ToInt32(id)).SingleOrDefault();
                return mapper.Map<Puesto>(PuestoResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Puesto> GetAll()
        {
            try
            {
                var PuestosResult = DB.ConsultarPuesto().ToList();
                var Puestos = mapper.Map<IEnumerable<ConsultarPuestoResult>, IEnumerable<Puesto>>(PuestosResult);
                return Puestos.Where(a => a.Activo.Value).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Insert(Puesto entity)
        {
            try
            {
                var id = DB.InsertarPuesto(entity.Nombre, entity.Descripcion).SingleOrDefault().Column1;
                return id.Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(Puesto entity)
        {
            try
            {
                DB.ActualizarPuesto(entity.Id, entity.Nombre, entity.Descripcion);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
