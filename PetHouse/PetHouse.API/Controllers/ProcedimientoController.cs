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
    [Authorize]
    public class ProcedimientoController : BaseApiController
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
            catch (Exception ex)
            {
                Log.Error<ProcedimientoController>("GET Se ha producido un error en el llamado de la URI= " + Url.Request.RequestUri, ex);
                return NotFound();
            }
        }

        // GET: api/Procedimiento/ByExpediente/{id}
        [Route("ByExpediente/{id}")]
        [HttpGet]
        public IHttpActionResult ByExpediente(string id)
        {
            try
            {
                var procedimientos = ProcedimientoServicio.GetAllByIdExpediente(id);
                Uri uri = Url.Request.RequestUri;
                return Ok(ModelFactory.Create<ProcedimientoModel, Procedimiento>(procedimientos, uri));
            }
            catch (Exception ex)
            {
                Log.Error<ProcedimientoController>("GET Se ha producido un error en el llamado de la URI= " + Url.Request.RequestUri, ex);
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
            catch (Exception ex)
            {
                Log.Error<ProcedimientoController>("GET Se ha producido un error en el llamado de la URI= " + Url.Request.RequestUri, ex);
                return BadRequest();
            }
        }

        // POST: api/Procedimiento
        public IHttpActionResult Post([FromBody]Procedimiento procedimiento)
        {
            try
            {
                procedimiento = ProcedimientoServicio.Insert(procedimiento);
                Uri uri = new Uri(Url.Request.RequestUri + "/" + procedimiento.Id);
                return Created(uri, ModelFactory.Create<ProcedimientoModel, Procedimiento>(procedimiento, uri));
            }
            catch (Exception ex)
            {
                Log.Error<ProcedimientoController>("Post Se ha producido un error en el llamado de la URI= " + Url.Request.RequestUri, ex);
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
            catch (Exception ex)
            {
                Log.Error<ProcedimientoController>("Put Se ha producido un error en el llamado de la URI= " + Url.Request.RequestUri, ex);
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
            catch (Exception ex)
            {
                Log.Error<ProcedimientoController>("Delete Se ha producido un error en el llamado de la URI= " + Url.Request.RequestUri, ex);
                return BadRequest();
            }
        }
    }
}
