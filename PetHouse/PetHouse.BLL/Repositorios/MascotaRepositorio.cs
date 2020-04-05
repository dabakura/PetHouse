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
    public class MascotaRepositorio : DBContext, IMascotaService
    {
        public bool Delete(string id)
        {
            try
            {
                DB.EliminarMascota(id);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Mascota Get(string id)
        {
            try
            {
                var MascotaResult = DB.BuscarMascota(id).SingleOrDefault();
                return mapper.Map<Mascota>(MascotaResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Mascota> GetAll()
        {
            try
            {
                var MascotasResult = DB.ConsultarMascota().ToList();
                var Mascotas = mapper.Map<IEnumerable<ConsultarMascotaResult>, IEnumerable<Mascota>>(MascotasResult);
                return Mascotas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Mascota> GetAllByAdoptanteId(int id)
        {
            try
            {
                var ids = (from adopcion in DB.ConsultarAdopcion() where adopcion.AdoptanteId == id select adopcion.Id).ToList();
                var MascotasResult = (from mascota in DB.ConsultarMascota() where mascota.AdopcionId.HasValue && ids.Contains(mascota.AdopcionId.Value) select mascota).ToList();
                var Mascotas = mapper.Map<IEnumerable<ConsultarMascotaResult>, IEnumerable<Mascota>>(MascotasResult);
                return Mascotas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Insert(Mascota entity)
        {
            try
            {
                var id = DB.InsertarMascota(entity.Identificacion, entity.Nombre, entity.Tipo,entity.Genero, entity.Raza, entity.Fecha_Nacimiento, entity.AdopcionId, entity.ExpedienteId).SingleOrDefault().Column1;
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(Mascota entity)
        {
            try
            {
                DB.ActualizarMascota(entity.Identificacion, entity.Nombre, entity.Tipo, entity.Genero, entity.Raza, entity.Fecha_Nacimiento, entity.AdopcionId, entity.ExpedienteId);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
