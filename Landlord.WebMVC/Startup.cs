using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Landlord.WebMVC.Startup))]
namespace Landlord.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
