using PetHouse.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PetHouse.MVC.Models
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly string[] _allowedroles;
        public CustomAuthorizeAttribute(params string[] roles)
        {
            this._allowedroles = roles;
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return (SessionTokenExist(httpContext) && ((Token) httpContext.Session["Token"]).expires > DateTime.UtcNow);
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (!SessionTokenExist(filterContext.HttpContext))
                filterContext.Result = new RedirectToRouteResult(
                   new RouteValueDictionary
                   {
                        { "controller", "Error" },
                        { "action", "UnAuthorized" }
                   });
            else
                filterContext.Result = new RedirectToRouteResult(
                   new RouteValueDictionary
                   {
                        { "controller", "Account" },
                        { "action", "Login" }
                   });
        }

        private bool SessionTokenExist(HttpContextBase httpContex)
        {
            if (httpContex.Session == null)
                return false;
            return (httpContex.Session["Token"] != null);
        }
    }
}