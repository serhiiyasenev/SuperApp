using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SuperApp.Backoffice.Startup))]
namespace SuperApp.Backoffice
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
