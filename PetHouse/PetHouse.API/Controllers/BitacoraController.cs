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
    [RoutePrefix("api/Bitacora")]
    public class BitacoraController : BaseApiController
    {
        public IBitacoraService BitacoraServicio { get; }

        public BitacoraController()
        {
            BitacoraServicio = new BitacoraRepositorio();
        }

        // GET: api/Bitacora/Registrar
        [Route("Registrar")]
        public IHttpActionResult Registrar([FromBody] Bitacora bitacora)
        {
            try
            {
                BitacoraServicio.Registar(bitacora);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error<BitacoraController>("Post Se ha producido un error en el llamado de la URI= " + Url.Request.RequestUri, ex);
                return BadRequest();
            }
        }
    }
}
