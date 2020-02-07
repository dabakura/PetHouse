using PetHouse.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHouse.BLL.Services
{
    public interface ICantonService
    {
        IEnumerable<Canton> GetAll();
        Canton Get(string id);
        int Insert(Canton entity);
        bool Update(Canton entity);
    }
}
