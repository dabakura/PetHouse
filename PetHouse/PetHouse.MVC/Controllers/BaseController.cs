using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using PetHouse.API.Models;
using PetHouse.MVC.Models;

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

        public async Task<HttpResponseMessage> PostAsync(string path, Object content)
        {
            if (Session["Token"] != null)
            {
                Token token = (Token) Session["Token"];
                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.access_token);
            }
            var json = JsonConvert.SerializeObject(content);
            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await Client.PostAsync(URL_API + path, stringContent);
            return response;
        }

        public async Task<HttpResponseMessage> GetAsync(string path)
        {
            if (Session["Token"] != null)
            {
                Token token = (Token)Session["Token"];
                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.access_token);
            }
            var response = await Client.GetAsync(URL_API + path);
            return response;
        }
    }
}