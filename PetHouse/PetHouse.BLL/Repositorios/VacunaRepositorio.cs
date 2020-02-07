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
    public class VacunaRepositorio : DBContext, IVacunaService
    {
        public bool Delete(string id)
        {
            try
            {
                DB.EliminarVacuna(Convert.ToInt32(id));
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Vacuna Get(string id)
        {
            try
            {
                var VacunaResult = DB.BuscarVacuna(Convert.ToInt32(id)).SingleOrDefault();
                return mapper.Map<Vacuna>(VacunaResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Vacuna> GetAll()
        {
            try
            {
                var VacunasResult = DB.ConsultarVacuna().ToList();
                var Vacunas = mapper.Map<IEnumerable<ConsultarVacunaResult>, IEnumerable<Vacuna>>(VacunasResult);
                return Vacunas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Insert(Vacuna entity)
        {
            try
            {
                var id = DB.InsertarVacuna(entity.Nombre, entity.Descripcion).SingleOrDefault().Column1;
                return id.Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(Vacuna entity)
        {
            try
            {
                DB.ActualizarVacuna(entity.Id, entity.Nombre, entity.Descripcion);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
