using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Springboard.Startup))]
namespace Springboard
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
