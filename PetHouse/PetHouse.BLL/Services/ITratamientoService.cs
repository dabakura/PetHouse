using PetHouse.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHouse.BLL.Services
{
    public interface ITratamientoService
    {
        IEnumerable<Tratamiento> GetAll(string idExpediente);
        Tratamiento Get(string id);
        int Insert(Tratamiento entity);
        bool Update(Tratamiento entity);
        bool Delete(string id);
    }
}
