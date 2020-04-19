using PetHouse.BLL.Services;
using PetHouse.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHouse.BLL.Repositorios
{
    public class EventoRepositorio : DBContext, IEventoService
    {
        public bool Delete(string id)
        {
            try
            {
                DB.EliminarEvento(Convert.ToInt32(id));
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Evento Get(string id)
        {
            try
            {
                var EventoResult = DB.BuscarEvento(Convert.ToInt32(id)).SingleOrDefault();
                return mapper.Map<Evento>(EventoResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Evento> GetAll()
        {
            try
            {
                var EventosResult = DB.ConsultarEvento().ToList();
                var Eventos = mapper.Map<IEnumerable<ConsultarEventoResult>, IEnumerable<Evento>>(EventosResult);
                return Eventos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Insert(Evento entity)
        {
            try
            {
                var id = DB.InsertarEvento(entity.Titulo, entity.Descripcion, entity.Inicio, entity.Fin, entity.ColorFondo).SingleOrDefault().Id;
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(Evento entity)
        {
            try
            {
                DB.ActualizarEvento(entity.Id, entity.Titulo, entity.Descripcion, entity.Inicio, entity.Fin, entity.ColorFondo);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
