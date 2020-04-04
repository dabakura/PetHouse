using PetHouse.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetHouse.MVC.Models
{
    public class Permisos
    {
        public static bool HasLogin()
        {
            return HttpContext.Current.Session["Token"] != null;
        }

        public static string UserName()
        {
            if (HasLogin())
                return ((Token)HttpContext.Current.Session["Token"]).userName;
            else
                return "Inicia Sesión";
        }
    }
}