using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Routing;

namespace PetHouse.API.Models
{
    public class ModelFactory
    {
        //Code removed for brevity
        public RoleReturnModel Create(IdentityRole appRole, Uri uri)
        {
            return new RoleReturnModel
            {
                Url = uri.AbsolutePath,
                Id = appRole.Id,
                Name = appRole.Name
            };
        }
    }

    public class RoleReturnModel
    {
        public string Url { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
    }
}