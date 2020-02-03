using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHouse.BLL.Interfaces
{
    public interface ICrud<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
    }
}
