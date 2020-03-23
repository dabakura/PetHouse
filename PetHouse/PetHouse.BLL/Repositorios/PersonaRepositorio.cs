using PetHouse.BLL.Services;
using PetHouse.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHouse.BLL.Repositorios
{
    public class PersonaRepositorio : DBContext, IPersonaService
    {
        public Persona Get(string cedula)
        {
            try
            {
                var PernonaResult = DB.BuscarPersona(Convert.ToInt32(cedula)).SingleOrDefault();
                return mapper.Map<Persona>(PernonaResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
