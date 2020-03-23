using PetHouse.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHouse.BLL.Services
{
    public interface IPersonaService
    {
        Persona Get(string cedula);
    }
}
