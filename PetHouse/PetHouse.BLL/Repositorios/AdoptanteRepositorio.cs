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
    public class AdoptanteRepositorio : DBContext, IAdoptanteService
    {
        public bool Delete(string id)
        {
            try
            {
                DB.EliminarAdoptante(Convert.ToInt32(id));
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Adoptante Get(string id)
        {
            try
            {
                var adoptanteResult = DB.BuscarAdoptante(Convert.ToInt32(id)).SingleOrDefault();
                return mapper.Map<Adoptante>(adoptanteResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Adoptante> GetAll()
        {
            try
            {
                var AdoptantesResult = DB.ConsultarAdoptante().ToList();
                var Adoptantes = mapper.Map<IEnumerable<ConsultarAdoptanteResult>, IEnumerable<Adoptante>>(AdoptantesResult);
                return Adoptantes.Where(a => a.Activo.Value).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Insert(Adoptante entity)
        {
            try
            {
                var id = DB.InsertarAdoptante(entity.Identificacion, entity.Nombre, entity.Primer_Apellido, entity.Segundo_Apellido, entity.Fecha_Nacimiento, entity.Telefono, entity.Correo, entity.DomicilioId).SingleOrDefault().Column1;
                return id.Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(Adoptante entity)
        {
            try
            {
                DB.ActualizarAdoptante(entity.Identificacion, entity.Nombre, entity.Primer_Apellido, entity.Segundo_Apellido, entity.Fecha_Nacimiento, entity.Telefono, entity.Correo, entity.DomicilioId);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
