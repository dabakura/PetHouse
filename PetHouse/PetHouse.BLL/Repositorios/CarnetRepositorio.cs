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
    public class CarnetRepositorio : DBContext, ICarnetService
    {
        public bool Delete(string idExpediente)
        {
            try
            {
                DB.EliminarCarnet(idExpediente);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteVacuna(string idExpediente, int idVacuna)
        {
            try
            {
                DB.EliminarVacunaCarnet(idExpediente,idVacuna);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Carnet> Get(string id)
        {
            try
            {
                var CarnetsResult = DB.BuscarCarnet(id).ToList();
                var Carnets = mapper.Map<IEnumerable<BuscarCarnetResult>, IEnumerable<Carnet>>(CarnetsResult);
                return Carnets;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Carnet> GetAll()
        {
            try
            {
                var CarnetsResult = DB.ConsultarCarnet().ToList();
                var Carnets = mapper.Map<IEnumerable<ConsultarCarnetResult>, IEnumerable<Carnet>>(CarnetsResult);
                return Carnets.Where(a => a.Activo.Value).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Carnet Insert(Carnet entity)
        {
            try
            {
                DB.InsertarCarnet(entity.ExpedienteId, entity.VacunaId, entity.Fecha_Vacunacion);
                var Carnet = mapper.Map<Carnet, Carnet>(entity);
                return Carnet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
