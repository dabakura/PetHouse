using PetHouse.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHouse.BLL.Services
{
    public interface ITratamientoMedicamentoService
    {
        IEnumerable<TratamientoMedicamento> GetAll();
        TratamientoMedicamento Get(string id);
        bool Insert(TratamientoMedicamento entity);
    }
}
