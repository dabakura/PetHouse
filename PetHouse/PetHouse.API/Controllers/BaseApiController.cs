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

        public BaseApiController() { }

        public BaseApiController(ApplicationUserManager userManager,
            ApplicationRoleManager roleManager)
        {
            _AppUserManager = userManager;
            _AppRoleManager = roleManager;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _AppUserManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _AppUserManager = value;
            }
        }

        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _AppRoleManager ?? Request.GetOwinContext().GetUserManager<ApplicationRoleManager>();
            }
            private set
            {
                _AppRoleManager = value;
            }
        }
    }
}
