using PetHouse.API.Models;
using PetHouse.BLL.Repositorios;
using PetHouse.BLL.Services;
using PetHouse.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PetHouse.API.Controllers
{
    [RoutePrefix("api/Empleado")]
    public class EmpleadoController : ApiController
    {
        public IEmpleadoService EmpleadoServicio { get; }

        public EmpleadoController()
        {
            EmpleadoServicio = new EmpleadoRepositorio();
        }

        // GET: api/Empleado
        public IHttpActionResult Get()
        {
            try
            {
                var empleados = EmpleadoServicio.GetAll();
                Uri uri = Url.Request.RequestUri;
                return Ok(ModelFactory.Create<EmpleadoModel,Empleado>(empleados, uri));
            }
            catch
            {
                return NotFound();
            }
        }

        // GET: api/Empleado/5
        public IHttpActionResult Get(string id)
        {
            try
            {
                var empleado = EmpleadoServicio.Get(id);
                Uri uri = Url.Request.RequestUri;
                return Ok(ModelFactory.Create<EmpleadoModel, Empleado>(empleado, uri));
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST: api/Empleado
        public IHttpActionResult Post([FromBody]Empleado empleado)
        {
            try
            {
                empleado.Identificacion = EmpleadoServicio.Insert(empleado);
                Uri uri = new Uri(Url.Request.RequestUri + "/" + empleado.Identificacion);
                return Created(uri, ModelFactory.Create<EmpleadoModel, Empleado>(empleado, uri));
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT: api/Empleado/5
        public IHttpActionResult Put(string id, [FromBody]Empleado empleado)
        {
            try
            {
                empleado.Identificacion = Convert.ToInt32(id);
                EmpleadoServicio.Update(empleado);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
		
		// DELETE: api/Empleado/5
        public IHttpActionResult Delete(string id)
        {
            try
            {
                EmpleadoServicio.Delete(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
