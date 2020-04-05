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
    public class AdopcionRepositorio : DBContext, IAdopcionService
    {
        public bool Delete(string id)
        {
            try
            {
                DB.EliminarAdopcion(Convert.ToInt32(id));
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Adopcion Get(string id)
        {
            try
            {
                var adopcionResult = DB.BuscarAdopcion(Convert.ToInt32(id)).SingleOrDefault();
                return mapper.Map<Adopcion>(adopcionResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Adopcion> GetAll()
        {
            try
            {
                var AdopcionesResult = DB.ConsultarAdopcion().ToList();
                var Adopciones = mapper.Map<IEnumerable<ConsultarAdopcionResult>, IEnumerable<Adopcion>>(AdopcionesResult);
                return Adopciones;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Insert(Adopcion entity)
        {
            try
            {
                var id = DB.InsertarAdopcion(entity.InstitucionId, entity.AdoptanteId, entity.MascotaId, entity.Fecha_Adopcion).SingleOrDefault().Column1;
                return id.Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(Adopcion entity)
        {
            try
            {
                DB.ActualizarAdopcion(entity.Id, entity.InstitucionId, entity.AdoptanteId, entity.MascotaId, entity.Fecha_Adopcion);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
