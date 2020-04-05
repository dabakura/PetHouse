using PetHouse.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHouse.BLL.Services
{
    public interface IMascotaService
    {
        IEnumerable<Mascota> GetAll();
        IEnumerable<Mascota> GetAllByAdoptanteId(int id);
        Mascota Get(string id);
        string Insert(Mascota entity);
        bool Update(Mascota entity);
        bool Delete(string id);
    }
}
