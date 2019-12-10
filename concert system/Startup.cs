using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(concert_system.Startup))]
namespace concert_system
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
