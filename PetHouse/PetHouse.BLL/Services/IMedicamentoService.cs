using PetHouse.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHouse.BLL.Services
{
    public interface IMedicamentoService
    {
        IEnumerable<Medicamento> GetAll();
        Medicamento Get(string id);
        string Insert(Medicamento entity);
        bool Update(Medicamento entity);
        bool Delete(string id);
    }
}
