﻿using PetHouse.BLL.Services;
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
                return Mascotas.Where(a => a.Activo.Value).ToList();
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
                var ids = (from adopcion in DB.ConsultarAdopcion() where adopcion.AdoptanteId == id select adopcion.MascotaId).ToList();
                if (ids.Count() < 1)
                    return new List<Mascota>();
                var MascotasResult = (from mascota in DB.ConsultarMascota() where ids.Contains(mascota.Identificacion) select mascota).ToList();
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
                var id = DB.InsertarMascota(entity.Identificacion, entity.Nombre, entity.Tipo,entity.Genero, entity.Raza, entity.Fecha_Nacimiento, entity.ExpedienteId).SingleOrDefault().Column1;
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
                DB.ActualizarMascota(entity.Identificacion, entity.Nombre, entity.Tipo, entity.Genero, entity.Raza, entity.Fecha_Nacimiento, entity.ExpedienteId);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
