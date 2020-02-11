using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Microsoft.Owin.Logging;
using Owin;
using PetHouse.API.Controllers;
using PetHouse.API.Models;

[assembly: OwinStartup(typeof(PetHouse.API.Startup))]

namespace PetHouse.API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            log4net.Config.XmlConfigurator.Configure();
            ConfigureAuth(app);
        }
    }
}
