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
    [RoutePrefix("api/Procedimiento")]
    public class ProcedimientoController : ApiController
    {
        public IProcedimientoService ProcedimientoServicio { get; }

        public ProcedimientoController()
        {
            ProcedimientoServicio = new ProcedimientoRepositorio();
        }

        // GET: api/Procedimiento
        public IHttpActionResult Get()
        {
            try
            {
                var procedimientos = ProcedimientoServicio.GetAll();
                Uri uri = Url.Request.RequestUri;
                return Ok(ModelFactory.Create<ProcedimientoModel, Procedimiento>(procedimientos, uri));
            }
            catch
            {
                return NotFound();
            }
        }

        // GET: api/Procedimiento/5
        public IHttpActionResult Get(string id)
        {
            try
            {
                var procedimiento = ProcedimientoServicio.Get(id);
                Uri uri = Url.Request.RequestUri;
                return Ok(ModelFactory.Create<ProcedimientoModel, Procedimiento>(procedimiento, uri));
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST: api/Procedimiento
        public IHttpActionResult Post([FromBody]Procedimiento procedimiento)
        {
            try
            {
                procedimiento.Id = ProcedimientoServicio.Insert(procedimiento);
                Uri uri = new Uri(Url.Request.RequestUri + "/" + procedimiento.Id);
                return Created(uri, ModelFactory.Create<ProcedimientoModel, Procedimiento>(procedimiento, uri));
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT: api/Procedimiento/5
        public IHttpActionResult Put(string id, [FromBody]Procedimiento procedimiento)
        {
            try
            {
                procedimiento.Id = Convert.ToInt32(id);
                ProcedimientoServicio.Update(procedimiento);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
		
		// DELETE: api/Procedimiento/5
        public IHttpActionResult Delete(string id)
        {
            try
            {
                ProcedimientoServicio.Delete(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
