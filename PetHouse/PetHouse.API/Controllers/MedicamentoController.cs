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
    [RoutePrefix("api/Medicamento")]
    public class MedicamentoController : ApiController
    {
        public IMedicamentoService MedicamentoServicio { get; }

        public MedicamentoController()
        {
            MedicamentoServicio = new MedicamentoRepositorio();
        }

        // GET: api/Medicamento
        public IHttpActionResult Get()
        {
            try
            {
                var medicamentos = MedicamentoServicio.GetAll();
                return Ok(ModelFactory.Create(medicamentos));
            }
            catch
            {
                return NotFound();
            }
        }

        // GET: api/Medicamento/5
        public IHttpActionResult Get(string id)
        {
            try
            {
                var medicamento = MedicamentoServicio.Get(id);
                Uri uri = Url.Request.RequestUri;
                return Ok(ModelFactory.Create(medicamento, uri));
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST: api/Medicamento
        public IHttpActionResult Post([FromBody]Medicamento medicamento)
        {
            try
            {
                medicamento.Id = MedicamentoServicio.Insert(medicamento);
                Uri uri = new Uri(Url.Request.RequestUri + "/" +medicamento.Id);
                return Created(uri, ModelFactory.Create(medicamento, uri));
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT: api/Medicamento/5
        public IHttpActionResult Put(string id, [FromBody]Medicamento medicamento)
        {
            try
            {
                medicamento.Id = id;
                MedicamentoServicio.Update(medicamento);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
		
		// DELETE: api/Medicamento/5
        public IHttpActionResult Delete(string id)
        {
            try
            {
                MedicamentoServicio.Delete(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
