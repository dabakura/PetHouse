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
    public class BitacoraRepositorio : DBContext, IBitacoraService
    {
        public int Registar(Bitacora entity)
        {
            try
            {
                return DB.RegistrarBitacora(entity.Controlador, entity.Metodo, entity.Mensaje, entity.Usuario, entity.Tipo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
