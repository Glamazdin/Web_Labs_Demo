using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebLabs_V3.Startup))]
namespace WebLabs_V3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
