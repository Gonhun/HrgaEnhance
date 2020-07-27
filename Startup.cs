using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HrgaEnhance.Startup))]
namespace HrgaEnhance
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
