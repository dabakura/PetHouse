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
    public class InstitucionRepositorio : DBContext, IInstitucionService
    {
        public bool Delete(string id)
        {
            try
            {
                DB.EliminarInstitucion(Convert.ToInt32(id));
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Institucion Get(string id)
        {
            try
            {
                var InstitucionResult = DB.BuscarInstitucion(Convert.ToInt32(id)).SingleOrDefault();
                return mapper.Map<Institucion>(InstitucionResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Institucion> GetAll()
        {
            try
            {
                var InstitucionesResult = DB.ConsultarInstitucion().ToList();
                var Instituciones = mapper.Map<IEnumerable<ConsultarInstitucionResult>, IEnumerable<Institucion>>(InstitucionesResult);
                return Instituciones;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Insert(Institucion entity)
        {
            try
            {
                var id = DB.InsertarInstitucion(entity.Ced_Juridica, entity.Nombre, entity.Telefono, entity.Fax, entity.Pag_Web, entity.Correo, entity.DireccionId).SingleOrDefault().Column1;
                return id.Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(Institucion entity)
        {
            try
            {
                DB.ActualizarInstitucion(entity.Id, entity.Ced_Juridica, entity.Nombre, entity.Telefono, entity.Fax, entity.Pag_Web, entity.Correo, entity.DireccionId);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
