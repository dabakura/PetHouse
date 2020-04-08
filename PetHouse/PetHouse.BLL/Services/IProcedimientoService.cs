using PetHouse.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHouse.BLL.Services
{
    public interface IProcedimientoService
    {
        IEnumerable<Procedimiento> GetAll();
        Procedimiento Get(string id);
        Procedimiento Insert(Procedimiento entity);
        bool Update(Procedimiento entity);
        bool Delete(string id);
        IEnumerable<Procedimiento> GetAllByIdExpediente(string id);
    }
}
