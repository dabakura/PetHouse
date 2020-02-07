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
        public TratamientoMedicamento Get(string id)
        {
            try
            {
                var TratamientoMedicamentoResult = DB.BuscarTratamientoMedicamento(Convert.ToInt32(id)).SingleOrDefault();
                return mapper.Map<TratamientoMedicamento>(TratamientoMedicamentoResult);
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
                var id = DB.InsertarTratamientoMedicamento(entity.TratamientoId, entity.MedicamentoId);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
