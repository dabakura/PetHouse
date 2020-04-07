using PetHouse.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHouse.BLL.Services
{
    public interface ICarnetService
    {
        IEnumerable<Carnet> GetAll();
        IEnumerable<Carnet> Get(string id);
        Carnet Insert(Carnet entity);
        bool Delete(string idExpediente);
        bool DeleteVacuna(string idExpediente, int idVacuna);
    }
}
