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
    public class ExpedienteRepositorio : DBContext, IExpedienteService
    {
        public bool DeletePermanent(string id)
        {
            try
            {
                DB.EliminarExpedientePermanent(id);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(string id)
        {
            try
            {
                DB.EliminarExpediente(id);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Expediente Get(string id)
        {
            try
            {
                var ExpedienteResult = DB.BuscarExpediente(id).SingleOrDefault();
                return mapper.Map<Expediente>(ExpedienteResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Expediente> GetAll()
        {
            try
            {
                var ExpedientesResult = DB.ConsultarExpediente().ToList();
                var Expedientes = mapper.Map<IEnumerable<ConsultarExpedienteResult>, IEnumerable<Expediente>>(ExpedientesResult);
                return Expedientes.Where(a => a.Activo.Value).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Insert(Expediente entity)
        {
            try
            {
                var id = DB.InsertarExpediente(entity.Id, entity.Observaciones, entity.Edad, entity.Peso, entity.Castracion, entity.Fecha_Ingreso, entity.Fecha_Fallecimiento).SingleOrDefault().Column1;
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(Expediente entity)
        {
            try
            {
                DB.ActualizarExpediente(entity.Id, entity.Observaciones, entity.Edad, entity.Peso, entity.Castracion, entity.Fecha_Ingreso, entity.Fecha_Fallecimiento);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
