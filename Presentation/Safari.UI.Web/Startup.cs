using IoControl.App_Start;
using Microsoft.Owin;
using Owin;
using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof(StructuremapMvc), "Start")]
[assembly: ApplicationShutdownMethod(typeof(StructuremapMvc), "End")]

[assembly: OwinStartupAttribute(typeof(Safari.UI.Web.Startup))]
namespace Safari.UI.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
