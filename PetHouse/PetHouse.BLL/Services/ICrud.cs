using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHouse.BLL.Services
{
    public interface ICrud<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(string id);
        int Insert(T entity);
        bool Update(T entity);
        bool Delete(string id);
    }
}
