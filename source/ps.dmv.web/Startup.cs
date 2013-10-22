using Microsoft.Owin;
using Owin;
using ps.dmv.web.Infrastructure.Security;

[assembly: OwinStartupAttribute(typeof(ps.dmv.web.Startup))]
namespace ps.dmv.web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            StartupCore.ConfigureAuth(app);
        }
    }
}
