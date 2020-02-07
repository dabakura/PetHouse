using PetHouse.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHouse.BLL.Services
{
    public interface IDistritoService
    {
        IEnumerable<Distrito> GetAll();
        Distrito Get(string id);
        int Insert(Distrito entity);
        bool Update(Distrito entity);
    }
}
