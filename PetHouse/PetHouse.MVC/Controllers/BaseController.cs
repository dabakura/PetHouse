using Newtonsoft.Json;
using PetHouse.API.Models;
using PetHouse.MVC.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PetHouse.MVC.Controllers
{
    public abstract class BaseController : Controller
    {
        private string URL_API = ConfigurationManager.AppSettings["API_URI"];
        public HttpClient Client => new HttpClient();

        public async Task<HttpResponseMessage> TokenAsync(string path, UserLogin user)
        {
            var parameters = new KeyValuePair<string, string>[] {
                new KeyValuePair<string, string>("grant_type", user.grant_type),
                new KeyValuePair<string, string>("password", user.password),
                new KeyValuePair<string, string>("username", user.username)
            };
            FormUrlEncodedContent formUrlContent = new FormUrlEncodedContent(parameters);
            var response = await Client.PostAsync(URL_API + path, formUrlContent);
            return response;
        }

        public async Task<HttpResponseMessage> PostAsync(string path, object content)
        {
            var client = SetToken();
            StringContent jsonContent = GetJsonContent(content);
            var response = await client.PostAsync(URL_API + path, jsonContent);
            return response;
        }

        public async Task<HttpResponseMessage> GetAsync(string path)
        {
            var client = SetToken();
            var response = await client.GetAsync(URL_API + path);
            return response;
        }

        public async Task<HttpResponseMessage> PutAsync(string path, object content)
        {
            var client = SetToken();
            StringContent jsonContent = GetJsonContent(content);
            var response = await client.PutAsync(URL_API + path, jsonContent);
            return response;
        }

        public async Task<HttpResponseMessage> DeleteAsync(string path)
        {
            var client = SetToken();
            var response = await client.DeleteAsync(URL_API + path);
            return response;
        }

        public async Task<string> ErrorAsync(string Controlador, string Metodo, string Mensaje, int? Tipo)
        {
            Bitacora bitacora = new Bitacora(Controlador, Metodo, Mensaje, "none", Tipo);
            if (Session["Token"] != null)
                bitacora.Usuario = ((Token)Session["Token"]).userName;
            StringContent bitacoraContent = GetJsonContent(bitacora);
            var response = await Client.PostAsync(URL_API + "api/Bitacora/Registrar", bitacoraContent);
            string error = Mensaje;
            if (!response.IsSuccessStatusCode)
                error = "Se ha presentado un error. Por favor notifique al administador.";
            return error;
        }

        private HttpClient SetToken()
        {
            var client = Client;
            if (Session["Token"] != null)
            {
                Token token = (Token)Session["Token"];
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.access_token);
            }
            return client;
        }

        private StringContent GetJsonContent(object content)
        {
            var json = JsonConvert.SerializeObject(content);
            StringContent jsonContent = new StringContent(json, Encoding.UTF8, "application/json");
            return jsonContent;
        }
    }
}