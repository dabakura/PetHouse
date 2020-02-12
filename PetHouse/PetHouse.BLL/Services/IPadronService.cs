using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHouse.BLL.Services
{
    public interface IPadronService
    {
        bool InsertRegion(int ProvinciaId, int cantonId, int distritoId, string Provincia, string Canton, string Distrito);
        bool InsertPersona(int Cedula, string Nombre, string Primer_Apellido, string Segundo_Apellido, int Sexo, int ProvinciaId, int cantonId, int distritoId);
    }
}
