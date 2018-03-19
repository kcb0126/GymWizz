using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GymWizz.Startup))]
namespace GymWizz
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
