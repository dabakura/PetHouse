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
    public class DistritoRepositorio : DBContext, IDistritoService
    {

        public Distrito Get(string id)
        {
            try
            {
                var DistritoResult = DB.BuscarDistrito(Convert.ToInt32(id)).SingleOrDefault();
                return mapper.Map<Distrito>(DistritoResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Distrito> GetAll()
        {
            try
            {
                var DistritosResult = DB.ConsultarDistrito().ToList();
                var Distritos = mapper.Map<IEnumerable<ConsultarDistritoResult>, IEnumerable<Distrito>>(DistritosResult);
                return Distritos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Insert(Distrito entity)
        {
            try
            {
                var id = DB.InsertarDistrito(entity.CantonId, entity.Nombre).SingleOrDefault().Column1;
                return id.Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(Distrito entity)
        {
            try
            {
                DB.ActualizarDistrito(entity.Id, entity.CantonId, entity.Nombre);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
