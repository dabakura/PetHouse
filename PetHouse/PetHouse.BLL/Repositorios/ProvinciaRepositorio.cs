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
    public class ProvinciaRepositorio : DBContext, IProvinciaService
    {
        public Provincia Get(string id)
        {
            try
            {
                var ProvinciaResult = DB.BuscarProvincia(Convert.ToInt32(id)).SingleOrDefault();
                return mapper.Map<Provincia>(ProvinciaResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Provincia> GetAll()
        {
            try
            {
                var ProvinciasResult = DB.ConsultarProvincia().ToList();
                var Provincias = mapper.Map<IEnumerable<ConsultarProvinciaResult>, IEnumerable<Provincia>>(ProvinciasResult);
                return Provincias;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Insert(Provincia entity)
        {
            try
            {
                var id = DB.InsertarProvincia(entity.Nombre).SingleOrDefault().Column1;
                return id.Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(Provincia entity)
        {
            try
            {
                DB.ActualizarProvincia(entity.Id, entity.Nombre);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
