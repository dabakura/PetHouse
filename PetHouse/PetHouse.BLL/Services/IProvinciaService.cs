using PetHouse.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHouse.BLL.Services
{
    public interface IProvinciaService
    {
        IEnumerable<Provincia> GetAll();
        Provincia Get(string id);
        int Insert(Provincia entity);
        bool Update(Provincia entity);
    }
}
