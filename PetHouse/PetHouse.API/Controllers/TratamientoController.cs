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
    [RoutePrefix("api/Tratamiento")]
    public class TratamientoController : ApiController
    {
        public ITratamientoService TratamientoServicio { get; }
        public ITratamientoMedicamentoService TratamientoMedicamentoServicio { get; }

        public TratamientoController()
        {
            TratamientoServicio = new TratamientoRepositorio();
            TratamientoMedicamentoServicio = new TratamientoMedicamentoRepositorio();
        }

        // GET: api/Tratamiento/5
        [HttpGet]
        public IHttpActionResult GetAll(string idExpediente)
        {
            try
            {
                var tratamientos = TratamientoServicio.GetAll(idExpediente);
                Uri uri = Url.Request.RequestUri;
                return Ok(ModelFactory.Create<TratamientoModel, Tratamiento>(tratamientos, uri));
            }
            catch (Exception ex)
            {
                Log.Error<TratamientoController>("GET Se ha producido un error en el llamado de la URI= " + Url.Request.RequestUri, ex);
                return NotFound();
            }
        }

        // GET: api/Tratamiento/5
        public IHttpActionResult Get(string id)
        {
            try
            {
                var tratamiento = TratamientoServicio.Get(id);
                Uri uri = Url.Request.RequestUri;
                return Ok(ModelFactory.Create<TratamientoModel, Tratamiento>(tratamiento, uri));
            }
            catch (Exception ex)
            {
                Log.Error<TratamientoController>("GET Se ha producido un error en el llamado de la URI= " + Url.Request.RequestUri, ex);
                return BadRequest();
            }
        }

        // POST: api/Tratamiento
        public IHttpActionResult Post([FromBody]TratamientoModel tratamientoModel)
        {
            try
            {
                var tratamiento = ModelFactory.Create<Tratamiento, TratamientoModel>(tratamientoModel);
                tratamiento.Id = TratamientoServicio.Insert(tratamiento);
                Uri uri = new Uri(Url.Request.RequestUri + "/" + tratamiento.Id);
                tratamientoModel.Medicamentos.ForEach( medicamento => {
                    var tratamedica = new TratamientoMedicamento
                    {
                        MedicamentoId = medicamento.Id,
                        Medicamento = medicamento,
                        TratamientoId = tratamiento.Id,
                        Tratamiento = tratamiento
                    };
                    TratamientoMedicamentoServicio.Insert(tratamedica);
                });
                return Created(uri, ModelFactory.Create<TratamientoModel, Tratamiento>(tratamiento, uri));
            }
            catch (Exception ex)
            {
                Log.Error<TratamientoController>("Post Se ha producido un error en el llamado de la URI= " + Url.Request.RequestUri, ex);
                return BadRequest();
            }
        }

        // PUT: api/Tratamiento/5
        public IHttpActionResult Put(string id, [FromBody]Tratamiento tratamiento)
        {
            try
            {
                tratamiento.Id = Convert.ToInt32(id);
                TratamientoServicio.Update(tratamiento);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error<TratamientoController>("Put Se ha producido un error en el llamado de la URI= " + Url.Request.RequestUri, ex);
                return BadRequest();
            }
        }
		
		// DELETE: api/Tratamiento/5
        public IHttpActionResult Delete(string id)
        {
            try
            {
                TratamientoServicio.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error<TratamientoController>("Delete Se ha producido un error en el llamado de la URI= " + Url.Request.RequestUri, ex);
                return BadRequest();
            }
        }
    }
}
