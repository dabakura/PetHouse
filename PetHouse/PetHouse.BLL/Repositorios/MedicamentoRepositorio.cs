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
    public class MedicamentoRepositorio : DBContext, IMedicamentoService
    {
        public bool Delete(string id)
        {
            try
            {
                DB.EliminarMedicamento(id);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Medicamento Get(string id)
        {
            try
            {
                var MedicamentoResult = DB.BuscarMedicamento(id).SingleOrDefault();
                return mapper.Map<Medicamento>(MedicamentoResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Medicamento> GetAll()
        {
            try
            {
                var MedicamentosResult = DB.ConsultarMedicamento().ToList();
                var Medicamentos = mapper.Map<IEnumerable<ConsultarMedicamentoResult>, IEnumerable<Medicamento>>(MedicamentosResult);
                return Medicamentos.Where(a => a.Activo.Value).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Insert(Medicamento entity)
        {
            try
            {
                var id = DB.InsertarMedicamento(entity.Id, entity.Nombre, entity.Descripcion, entity.Tipo, entity.Precio).SingleOrDefault().Column1;
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(Medicamento entity)
        {
            try
            {
                DB.ActualizarMedicamento(entity.Id, entity.Nombre, entity.Descripcion, entity.Tipo, entity.Precio);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
