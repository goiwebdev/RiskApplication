﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RiskApplication.Startup))]
namespace RiskApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
