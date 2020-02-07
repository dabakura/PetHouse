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
    public class CantonRepositorio : DBContext, ICantonService
    {
        public Canton Get(string id)
        {
            try
            {
                var CantonResult = DB.BuscarCanton(Convert.ToInt32(id)).SingleOrDefault();
                return mapper.Map<Canton>(CantonResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Canton> GetAll()
        {
            try
            {
                var CantonesResult = DB.ConsultarCanton().ToList();
                var Cantones = mapper.Map<IEnumerable<ConsultarCantonResult>, IEnumerable<Canton>>(CantonesResult);
                return Cantones;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Insert(Canton entity)
        {
            try
            {
                var id = DB.InsertarCanton(entity.ProvinciaId, entity.Nombre).SingleOrDefault().Column1;
                return id.Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(Canton entity)
        {
            try
            {
                DB.ActualizarCanton(entity.Id, entity.ProvinciaId, entity.Nombre);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
