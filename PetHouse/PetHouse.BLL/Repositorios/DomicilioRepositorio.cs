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
    public class DomicilioRepositorio : DBContext, IDomicilioService
    {
        public bool Delete(string id)
        {
            try
            {
                DB.EliminarDomicilio(Convert.ToInt32(id));
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Domicilio Get(string id)
        {
            try
            {
                var DomicilioResult = DB.BuscarDomicilio(Convert.ToInt32(id)).SingleOrDefault();
                return mapper.Map<Domicilio>(DomicilioResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Domicilio> GetAll()
        {
            try
            {
                var DomiciliosResult = DB.ConsultarDomicilio().ToList();
                var Domicilios = mapper.Map<IEnumerable<ConsultarDomicilioResult>, IEnumerable<Domicilio>>(DomiciliosResult);
                return Domicilios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Insert(Domicilio entity)
        {
            try
            {
                var id = DB.InsertarDomicilio(entity.ProvinciaId, entity.CantonId, entity.DistritoId, entity.Direccion).SingleOrDefault().Column1;
                return id.Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(Domicilio entity)
        {
            try
            {
                DB.ActualizarDomicilio(entity.Id, entity.ProvinciaId, entity.CantonId, entity.DistritoId, entity.Direccion);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
