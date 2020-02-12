using PetHouse.BLL.Services;
using PetHouse.BLL.Mappers;
using PetHouse.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHouse.BLL.Repositorios
{
    public class PadronRepositorio : DBContext, IPadronService
    {
        public bool InsertPersona(int Cedula, string Nombre, string Primer_Apellido, string Segundo_Apellido, int Sexo, int ProvinciaId, int cantonId, int distritoId)
        {
            try
            {
                DB.InsertarActualizarPadron(ProvinciaId, cantonId, distritoId, Cedula, Sexo, Nombre, Primer_Apellido, Segundo_Apellido);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool InsertRegion(int ProvinciaId, int cantonId, int distritoId, string Provincia, string Canton, string Distrito)
        {
            try
            {
                DB.InsertarActualizarRegiones(ProvinciaId, cantonId, distritoId, Provincia, Canton, Distrito);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
