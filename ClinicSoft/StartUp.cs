using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ClinicSoft.App_Start.StartUp))]
namespace ClinicSoft.App_Start
{
    public partial class StartUp
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}