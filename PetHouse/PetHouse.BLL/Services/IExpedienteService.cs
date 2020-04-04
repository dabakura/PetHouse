using PetHouse.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHouse.BLL.Services
{
    public interface IExpedienteService
    {
        IEnumerable<Expediente> GetAll();
        Expediente Get(string id);
        string Insert(Expediente entity);
        bool Update(Expediente entity);
        bool Delete(string id);
        bool DeletePermanent(string id);
    }
}
