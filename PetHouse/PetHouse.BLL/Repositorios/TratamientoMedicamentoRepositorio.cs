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
    public class TratamientoMedicamentoRepositorio : DBContext, ITratamientoMedicamentoService
    {
        public bool Delete(int idTratamiento, string idMedicamento)
        {
            try
            {
                DB.EliminarTratamientoMedicamento(idTratamiento, idMedicamento);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<TratamientoMedicamento> Get(string id)
        {
            try
            {
                var TratamientoMedicamentosResult = DB.BuscarTratamientoMedicamento(Convert.ToInt32(id)).ToList();
                return mapper.Map<IEnumerable<BuscarTratamientoMedicamentoResult>, IEnumerable<TratamientoMedicamento>>(TratamientoMedicamentosResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<TratamientoMedicamento> GetAll()
        {
            try
            {
                var TratamientoMedicamentosResult = DB.ConsultarTratamientoMedicamento().ToList();
                var TratamientoMedicamentos = mapper.Map<IEnumerable<ConsultarTratamientoMedicamentoResult>, IEnumerable<TratamientoMedicamento>>(TratamientoMedicamentosResult);
                return TratamientoMedicamentos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert(TratamientoMedicamento entity)
        {
            try
            {
                DB.InsertarTratamientoMedicamento(entity.TratamientoId, entity.MedicamentoId);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
