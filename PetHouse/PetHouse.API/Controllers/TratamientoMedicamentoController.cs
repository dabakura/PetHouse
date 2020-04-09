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
    [RoutePrefix("api/TratamientoMedicamento")]
    [Authorize]
    public class TratamientoMedicamentoController : BaseApiController
    {
        public ITratamientoMedicamentoService TratamientoMedicamentoServicio { get; }

        public TratamientoMedicamentoController()
        {
            TratamientoMedicamentoServicio = new TratamientoMedicamentoRepositorio();
        }

        // GET: api/TratamientoMedicamento
        public IHttpActionResult Get()
        {
            try
            {
                var tratamientoMedicamentos = TratamientoMedicamentoServicio.GetAll();
                Uri uri = Url.Request.RequestUri;
                return Ok(ModelFactory.Create<TratamientoMedicamentoModel, TratamientoMedicamento>(tratamientoMedicamentos, uri));
            }
            catch (Exception ex)
            {
                Log.Error<TratamientoMedicamentoController>("GET Se ha producido un error en el llamado de la URI= " + Url.Request.RequestUri, ex);
                return NotFound();
            }
        }

        // GET: api/TratamientoMedicamento/5
        public IHttpActionResult Get(string id)
        {
            try
            {
                var tratamientoMedicamento = TratamientoMedicamentoServicio.Get(id);
                Uri uri = Url.Request.RequestUri;
                return Ok(ModelFactory.Create<TratamientoMedicamentoModel, TratamientoMedicamento>(tratamientoMedicamento, uri));
            }
            catch (Exception ex)
            {
                Log.Error<TratamientoMedicamentoController>("GET Se ha producido un error en el llamado de la URI= " + Url.Request.RequestUri, ex);
                return BadRequest();
            }
        }

  //      // POST: api/TratamientoMedicamento
  //      public IHttpActionResult Post([FromBody]TratamientoMedicamento tratamientoMedicamento)
  //      {
  //          try
  //          {
  //              tratamientoMedicamento.Id = TratamientoMedicamentoServicio.Insert(tratamientoMedicamento);
  //              Uri uri = new Uri(Url.Request.RequestUri + "/" +tratamientoMedicamento.Id);
  //              return Created(uri, ModelFactory.Create(tratamientoMedicamento, uri));
  //          }
  //          catch
  //          {
  //              return BadRequest();
  //          }
  //      }

  //      // PUT: api/TratamientoMedicamento/5
  //      public IHttpActionResult Put(string id, [FromBody]TratamientoMedicamento tratamientoMedicamento)
  //      {
  //          try
  //          {
  //              tratamientoMedicamento.Id = Convert.ToInt32(id);
  //              TratamientoMedicamentoServicio.Update(tratamientoMedicamento);
  //              return Ok();
  //          }
  //          catch
  //          {
  //              return BadRequest();
  //          }
  //      }
		
		//// DELETE: api/TratamientoMedicamento/5
  //      public IHttpActionResult Delete(string id)
  //      {
  //          try
  //          {
  //              TratamientoMedicamentoServicio.Delete(id);
  //              return Ok();
  //          }
  //          catch
  //          {
  //              return BadRequest();
  //          }
  //      }
    }
}
