using System;
using System.Collections.Generic;
using PetHouse.BLL.Repositorios;
using PetHouse.BLL.Services;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PetHouse.API.Models;
using PetHouse.DAL.Entities;

namespace PetHouse.API.Controllers
{
    public class PersonaController : BaseApiController
    {
        public IPersonaService PersonaServicio { get; }

        public PersonaController()
        {
            PersonaServicio = new PersonaRepositorio();
        }

        // GET: api/Persona/5
        public IHttpActionResult Get(string id)
        {
            try
            {
                var persona = PersonaServicio.Get(id);
                Uri uri = Url.Request.RequestUri;
                return Ok(ModelFactory.Create<PersonaModel, Persona>(persona, uri));
            }
            catch (Exception ex)
            {
                Log.Error<PersonaController>("GET Se ha producido un error en el llamado de la URI= " + Url.Request.RequestUri, ex);
                return BadRequest();
            }
        }
    }
}
