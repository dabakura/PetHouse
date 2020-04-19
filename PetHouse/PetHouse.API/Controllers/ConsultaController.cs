using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Http;
using PetHouse.API.BancoCentral;
using PetHouse.BLL;
using PetHouse.API.Models;
using PetHouse.DAL;

namespace PetHouse.API.Controllers
{
    [Authorize]
    [RoutePrefix("api/Consulta")]
    public class ConsultaController : ApiController
    {
        private readonly string token = ConfigurationManager.AppSettings["BancoCentralToken"];
        private readonly wsindicadoreseconomicosSoapClient bancocentral = new wsindicadoreseconomicosSoapClient("wsindicadoreseconomicosSoap12");

        [HttpPost]
        [Route("TipoCambio")]
        public IHttpActionResult TipoCambio(TipoCambio tipoCambio)
        {
            try
            {
                DataSet tipocambio = bancocentral.ObtenerIndicadoresEconomicos(tipoCambio.Indicador, tipoCambio.FechaInicio, tipoCambio.FechaFin, "Emilio Campos A", "N", "emiliocamp99@hotmail.com", token);
                var valor = tipocambio.Tables[0].Rows[0].ItemArray[2].ToString();
                return Ok(valor);
            }
            catch 
            {
                throw;
            }
        }
    }
}