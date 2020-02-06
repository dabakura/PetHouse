using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PetHouse.API.Controllers
{
    public class BaseApiController : ApiController
    {
        private ApplicationRoleManager _AppRoleManager;
        private ApplicationUserManager _AppUserManager;

        public BaseApiController()
        {
            _AppUserManager = Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            _AppRoleManager = Request.GetOwinContext().GetUserManager<ApplicationRoleManager>();
        }


        public ApplicationUserManager UserManager
        {
            get
            {
                return _AppUserManager;
            }
            private set
            {
                _AppUserManager = value;
            }
        }

        protected ApplicationRoleManager RoleManager
        {
            get
            {
                return _AppRoleManager;
            }
            private set
            {
                _AppRoleManager = value;
            }
        }
    }
}
